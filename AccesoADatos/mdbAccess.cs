namespace AccesoADatos
{
    using AccesoADatos.commons;
    using ADODB;
    using System;
    using System.Data;
    using System.Text;

    public class mdbAccess
    {
        public List<string> errors { get; set; }
        public Connection connection { get; set; }
        public string connectionString { get; set; }
        public string databasePath { get; set; }

        public mdbAccess(string ruta, string name)
        {
            errors = new List<string>();
            connection = new Connection();
            // Especifica la ruta del archivo de la base de datos de Access
            databasePath = Path.Combine(ruta, name + ".mdb");
            connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Jet OLEDB:Engine Type=5";

            // Verifica si el archivo de base de datos ya existe
            try
            {
                if (!System.IO.File.Exists(databasePath))
                {
                    // Crea la base de datos utilizando ADO
                    ADOX.Catalog catalog = new ADOX.Catalog();
                    ADOX.Table table = new ADOX.Table();
                    table.Name = "Table1";
                    table.Columns.Append("Field1");
                    table.Columns.Append("Field2");

                    catalog.Create(connectionString);
                    catalog.Tables.Append(table);
                }

                if (!Connect())
                {
                    errors.Add("No se puede conectar a la BD");
                }
            }
            catch (Exception ex)
            {
                errors.Add($"Error: {ex.Message}");
            }
        }
        public bool Connect()
        {
            connection.Open(connectionString);
            return IsConnected();
        }

        public void Disconnect()
        {
            connection.Close();
        }
        public bool IsConnected()
        {
            return connection.State.Equals(1);
        }

        public ADODB.Recordset? Select(string query)
        {
            if (!IsConnected())
            {
                if (!Connect())
                {
                    errors.Add("No se puede conectar a la BD");
                    return null;
                }
            }

            ADODB.Recordset recordset = new ADODB.Recordset();
            recordset.Open(query, connection);
            return recordset;
        }

        public bool TableExists(string tableName)
        {
            try
            {
                // Consulta para verificar la existencia de la tabla
                string query = $"SELECT COUNT(*) FROM MSysObjects WHERE Name = '{tableName}' AND Type=1";
                ADODB.Recordset? recordset = Select(query);
                if (recordset == null)
                {
                    return false;
                }
                int tableCount = Convert.ToInt32(recordset.Fields[0].Value);
                recordset.Close();
                return tableCount > 0;
            }
            catch (Exception ex)
            {
                errors.Add($"Error al crear la tabla {tableName}: {ex.Message}");
                return false;
            }
        }

        /*
         ejemplo:
            List<(string FieldName, string FieldType)> tableFields = new List<(string, string)>
            {
                ("ID", "INT"),
                ("Name", "VARCHAR(255)")
            };
         */
        public object? CreateSampleTable(string tableName, Type classType)
        {
            object rsAffected;
            try
            {
                 
                    if (!IsConnected())
                    {
                        if (!Connect())
                        {
                            errors.Add("No se puede conectar a la BD");
                            return false;
                        }
                    }
                    // Construye la parte de la consulta para la definición de los campos
                    string fieldsDefinition = ClassToDefinition.getInstance(classType).GenerarStringColumnsDefList();

                    if (String.IsNullOrEmpty(fieldsDefinition))
                    {
                        return null;
                    }

                    // Crea una tabla de ejemplo
                    string createTableQuery = $"CREATE TABLE {tableName} ({fieldsDefinition})";
                    connection.Execute(createTableQuery, out rsAffected);
                    return rsAffected;
                
            }
            catch (Exception ex)
            {
                errors.Add($"Error al crear la tabla: {ex.Message}");
                return null;
            }     
        }

        public object? InsertData(string tableName, Type classType, object data)
        {
            object rsAffected;
            try
            {
                if (!IsConnected())
                {
                    if (!Connect())
                    {
                        errors.Add("No se puede conectar a la BD");
                        return false;
                    }
                }

                // Obtener los campos y tipos de la clase
                List<Tuple<string, string>>? fields = ClassToDefinition.getInstance(classType).GenerarStringColumnsList(); ;

                if (fields != null)
                {
                    // Construir la cláusula WHERE
                    var whereClauseBuilder = new StringBuilder();
                    foreach (var field in fields)
                    {
                        var value = data.GetType().GetProperty(field.Item1)?.GetValue(data);
                        whereClauseBuilder.Append($"{field.Item1} = {FormatValueForQuery(value)} AND ");
                    }

                    // Eliminar el último "AND" de la cláusula WHERE
                    string whereClause = whereClauseBuilder.ToString().Substring(0, whereClauseBuilder.ToString().Length - 4).Replace(",",".").Replace("\"","");

                    // Construir la consulta de validación
                    string checkDuplicateQuery = $"SELECT COUNT(*) FROM {tableName} WHERE {whereClause}";

                    // Crear un objeto de Recordset y ejecutar la consulta de validación
                    ADODB.Recordset rs = new ADODB.Recordset();
                    rs.Open(checkDuplicateQuery, connection, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly);

                    int count = Convert.ToInt32(rs.Fields[0].Value);
                    rs.Close();

                    if (count == 0)
                    {
                        // Construir la parte de la consulta para los nombres de los campos
                        string fieldNames = string.Join(", ", fields.Select(f => f.Item1));

                        // Construir la parte de la consulta para los valores
                        string fieldValues = string.Join(", ", fields.Select(f => $"@{f.Item1}"));

                        // Construir la consulta de inserción
                        string insertQuery = $"INSERT INTO {tableName} ({fieldNames}) VALUES ({fieldValues})";

                        // Crear un nuevo objeto de comando y ejecutar la consulta de inserción
                        Command cmd = new ADODB.Command();
                        cmd.ActiveConnection = connection; // Asigna tu objeto de conexión ADODB aquí
                        cmd.CommandText = insertQuery;

                        // Asignar los parámetros de la consulta de inserción
                        foreach (var field in fields)
                        {
                            var parameter = cmd.CreateParameter();
                            parameter.Name = "@" + field.Item1;
                            parameter.Value = (data.GetType().GetProperty(field.Item1)?.GetValue(data)) != null ? (data.GetType().GetProperty(field.Item1)?.GetValue(data)) : TypeMapper.MapearValorParam(data.GetType().GetProperty(field.Item1).GetType());
                            parameter.Type = TypeMapper.MapearTipoParam(field.Item2);
                            parameter.Size = TypeMapper.MapearSizeValorParam(parameter.Value);
                            cmd.Parameters.Append(parameter);
                        }

                        // Ejecutar la consulta de inserción
                        rsAffected = cmd.Execute(out rsAffected);
                        return rsAffected;
                    }
                    else
                    {
                        errors.Add("Registro duplicado. No se pudo realizar la inserción.");
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                errors.Add($"Error al insertar datos en la tabla: {ex.Message}");
                return null;
            }
        }

        private string FormatValueForQuery(object? value)
        {
            if (value == null)
            {
                return "NULL";
            }
            else if (value is string || value is DateTime)
            {
                if (value is string)
                {
                    return $"'{value}'".Replace(",", ".").Replace("\"", "");
                }
                return $"#{((DateTime) value).Date}#";
            }
            else
            {
                return $"{value}".Replace(",", ".");
            }
        }


    }
}