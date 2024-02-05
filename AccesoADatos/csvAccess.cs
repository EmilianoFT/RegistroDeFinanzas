using AccesoADatos.commons;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace AccesoADatos
{
    public class csvAccess<T> where T : new()
    {
        public List<string>? errors { get; set; }
        CultureInfo cultureInfo = new CultureInfo("en-US");

        public csvAccess()
        {
            errors = new List<string>();
        }
        public List<T> ReadAll(string filePath)
        {
            List<T> dataList = new List<T>();
            
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    var columns = lines[0].Split(',');

                    for (int i = 1; i < lines.Length; i++)
                    {
                        List<string> values = SplitCsvLine(lines[i]);

                        T item = new T();

                        for (int j = 0; j < columns.Length; j++)
                        {
                            string columnName = columns[j].Trim();

                            PropertyInfo? property = typeof(T).GetProperties()
                                .FirstOrDefault(prop => prop.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                                    .Cast<DisplayNameAttribute>().Any(attr => attr.DisplayName == columnName));

                            if (property != null)
                            {
                                Type propertyType = property.PropertyType;
                                object typedValue = Convert.ChangeType(values[j].Trim(), propertyType, cultureInfo);
                                property.SetValue(item, typedValue);
                            }
                        }

                        dataList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                errors.Add("Error al procesar el archivo CSV: " + ex.Message);
            }

            return dataList;
        }

        List<string> SplitCsvLine(string line)
        {
            List<string> values = new List<string>();
            bool insideQuotes = false;
            StringBuilder currentValue = new StringBuilder();

            foreach (char c in line)
            {
                if (c == ',' && !insideQuotes)
                {
                    values.Add(currentValue.ToString().Replace(",", ""));
                    currentValue.Clear();
                }
                else if (c == '\"')
                {
                    insideQuotes = !insideQuotes;
                }
                else
                {
                    currentValue.Append(c);
                }
            }

            values.Add(currentValue.ToString().Replace(",", ""));
            return values;
        }

        public void WriteAll(string filePath, List<T> dataList, bool append = false)
        {
            try
            {
                string? directoryPath = Path.GetDirectoryName(filePath);

                if (directoryPath != null && !Directory.Exists(directoryPath))
                {
                   Directory.CreateDirectory(directoryPath);
                }

                if (append && File.Exists(filePath))
                {
                    List<T> existingData = ReadAll(filePath);

                    dataList = dataList
                        .Where(newItem => !existingData.Any(existingItem =>
                            typeof(T).GetProperties().All(property =>
                                object.Equals(property.GetValue(newItem), property.GetValue(existingItem)))))
                        .ToList();

                    if (dataList.Count == 0)
                    {
                        errors.Add("Todos los registros ya existen en el archivo CSV y no se agregarán nuevamente.");
                        return;
                    }
                }

                using (StreamWriter writer = new StreamWriter(filePath, append))
                {
                    if (dataList.Count > 0)
                    {
                        PropertyInfo[] properties = typeof(T).GetProperties();

                        if (writer.BaseStream.Length == 0)
                        {
                            string header = ClassToDefinition.getInstance(typeof(T)).GenerarStringColumnsList(true);
                            writer.WriteLine(header);
                        }

                        foreach (T data in dataList)
                        {
                            string line = string.Join(",", properties.Select(p => FormatValue(p.GetValue(data))));
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errors.Add("Error al agregar al archivo CSV: " + ex.Message);
            }
        }

        private string? FormatValue(object? value)
        {
            if (value is float floatValue)
            {
                return floatValue.ToString("F2").Replace(",", ".");
            }
            else if(value is decimal decimalValue)
            {
                return decimalValue.ToString("F2").Replace(",", ".");
            }
            else if (value is DateTime dateTimeValue)
            {
                return dateTimeValue.ToString("yyyy-MM-dd HH:mm:ss", cultureInfo);
            }
            else
            {
                return value?.ToString();
            }
        }

        public void ApendAll(string filePath, List<T> dataList)
        {
            WriteAll(filePath, dataList, true);
        }

        public void RemoveLine(string filePath, string columnName, object filterValue)
        {
            try
            {
                Dictionary<string, object?> filters = new Dictionary<string, object?>
                {
                    { columnName, filterValue }
                };

                RemoveLines(filePath, filters);
            }
            catch (Exception ex)
            {
                errors.Add("Error al remover línea del archivo CSV: " + ex.Message);
            }
        }

        public void RemoveLines(string filePath, Dictionary<string, object?> filters)
        {
            try
            {
                List<T> dataList = ReadAll(filePath);

                Predicate<T> predicate = BuildPredicate(filters);
                dataList.RemoveAll(predicate);

                WriteAll(filePath, dataList);
            }
            catch (Exception ex)
            {
                errors.Add("Error al remover líneas del archivo CSV: " + ex.Message);
            }
        }

        private Predicate<T> BuildPredicate(Dictionary<string, object?> filters)
        {
            return item =>
            {
                foreach (var filter in filters)
                {
                    string columnName = filter.Key;
                    PropertyInfo? property = typeof(T).GetProperties()
                        .FirstOrDefault(prop => prop.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                            .Cast<DisplayNameAttribute>().Any(attr => attr.DisplayName == columnName));

                    if (property == null || !object.Equals(property.GetValue(item), filter.Value))
                    {
                        return false;
                    }
                }

                return true;
            };
        }

        public T? Find(string filePath, string columnName, object filterValue)
        {
            try
            {
                List<T> dataList = ReadAll(filePath);

                string trimmedColumnName = columnName.Trim();
                PropertyInfo? property = typeof(T).GetProperties()
                    .FirstOrDefault(prop => prop.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                        .Cast<DisplayNameAttribute>().Any(attr => attr.DisplayName == trimmedColumnName));

                if (property != null)
                {
                    T? foundItem = dataList.FirstOrDefault(item => object.Equals(property.GetValue(item), filterValue));

                    if (foundItem != null)
                    {
                        return foundItem;
                    }
                    else
                    {
                        errors.Add($"No se encontró una línea donde la columna '{columnName}' coincide con el valor '{filterValue}'.");
                        return default;
                    }
                }
                else
                {
                    errors.Add($"La columna '{columnName}' no existe en la clase genérica.");
                    return default;
                }
            }
            catch (Exception ex)
            {
                errors.Add("Error al buscar la línea en el archivo CSV: " + ex.Message);
                return default;
            }
        }

        public List<T>? FindByColumns(string filePath, Dictionary<string, object?> filters)
        {
            try
            {
                List<T> dataList = ReadAll(filePath);

                foreach (var filter in filters)
                {
                    string trimmedColumnName = filter.Key.Trim();
                    PropertyInfo? property = typeof(T).GetProperties()
                        .FirstOrDefault(prop => prop.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                            .Cast<DisplayNameAttribute>().Any(attr => attr.DisplayName == trimmedColumnName));

                    if (property == null)
                    {
                        errors.Add($"La columna '{filter.Key}' no existe en la clase genérica.");
                        return new List<T>();
                    }

                    dataList = dataList.Where(item => object.Equals(property.GetValue(item), filter.Value)).ToList();
                }

                if (dataList.Count == 0)
                {
                    errors.Add("No se encontraron líneas que coincidan con los filtros proporcionados.");
                }

                return dataList;
            }
            catch (Exception ex)
            {
                errors.Add("Error al buscar líneas en el archivo CSV: " + ex.Message);
                return new List<T>();
            }
        }
    }
}
