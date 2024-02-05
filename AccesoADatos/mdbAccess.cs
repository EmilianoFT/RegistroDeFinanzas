namespace AccesoADatos
{
    using AccesoADatos.commons;
    using ADODB;
    using System;
    using System.Data;
    using System.Text;

    //TODO: Acomodar: La cadena de conexión esta hardcodeada, habría que buscar un método para ponerla por config.
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
            databasePath = Path.Combine(ruta, name + ".mdb");
            connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Jet OLEDB:Engine Type=5";

            try
            {
                if (!System.IO.File.Exists(databasePath))
                {
                    ADOX.Catalog catalog = new ADOX.Catalog();
                    ADOX.Table table = new ADOX.Table();
                    // TODO: habría que ver si es necesario crear una tabla para que cree la bd...
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
                    string fieldsDefinition = ClassToDefinition.getInstance(classType).GenerarStringColumnsDefList();

                    if (String.IsNullOrEmpty(fieldsDefinition))
                    {
                        return null;
                    }

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

        //TODO: Reparar: El insert no anda por inconsistencias en los tipos de datos.
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

                List<Tuple<string, string>>? fields = ClassToDefinition.getInstance(classType).GenerarStringColumnsList();

                if (fields != null)
                {

                    var whereClauseBuilder = new StringBuilder();
                    foreach (var field in fields)
                    {
                        var value = data.GetType().GetProperty(field.Item1)?.GetValue(data);
                        whereClauseBuilder.Append($"{field.Item1} = {FormatValueForQuery(value)} AND ");
                    }

                    string whereClause = whereClauseBuilder.ToString().Substring(0, whereClauseBuilder.ToString().Length - 4).Replace(",",".").Replace("\"","");

                    string checkDuplicateQuery = $"SELECT COUNT(*) FROM {tableName} WHERE {whereClause}";

                    ADODB.Recordset rs = new ADODB.Recordset();
                    rs.Open(checkDuplicateQuery, connection, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly);

                    int count = Convert.ToInt32(rs.Fields[0].Value);
                    rs.Close();

                    if (count == 0)
                    {

                        string fieldNames = string.Join(", ", fields.Select(f => f.Item1));
                        string fieldValues = string.Join(", ", fields.Select(f => $"@{f.Item1}"));
                        string insertQuery = $"INSERT INTO {tableName} ({fieldNames}) VALUES ({fieldValues})";

                        Command cmd = new ADODB.Command();
                        cmd.ActiveConnection = connection;
                        cmd.CommandText = insertQuery;

                        foreach (var field in fields)
                        {
                            var parameter = cmd.CreateParameter();
                            parameter.Name = "@" + field.Item1;
                            parameter.Value = (data.GetType().GetProperty(field.Item1)?.GetValue(data)) != null ? (data.GetType().GetProperty(field.Item1)?.GetValue(data)) : TypeMapper.MapearValorParam(data.GetType().GetProperty(field.Item1).GetType());
                            parameter.Type = TypeMapper.MapearTipoParam(field.Item2);
                            parameter.Size = TypeMapper.MapearSizeValorParam(parameter.Value);
                            cmd.Parameters.Append(parameter);
                        }

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