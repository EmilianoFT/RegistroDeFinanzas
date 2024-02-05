using System.ComponentModel;
using System.Reflection;


namespace AccesoADatos.commons
{
    public class ClassToDefinitionHelper<T>
    {
        static List<Tuple<Type, object?>> instancias = new List<Tuple<Type, object?>>();
        
        public ClassToDefinitionHelper<T>? getInstance(Type classType)
        {
            if (classType != null)
            {
                Tuple<Type, object?>? tupla = null;

                if (instancias.Count == 0 || !instanceExist(classType))
                {
                    Type genericType = typeof(ClassToDefinitionHelper<>).MakeGenericType(classType);
                    object? instance = Activator.CreateInstance(genericType);
                    tupla = new Tuple<Type, object?>(classType, instance);
                    instancias.Add(tupla);
                }
                else
                {
                    tupla = findInstance(classType);
                }

                if (tupla != null)
                {
                    return (ClassToDefinitionHelper<T>?)tupla.Item2;
                }
            }

            return null;
        }
        public List<Tuple<string, string>>? GenerarTuplasByNames()
        {
            if (typeof(T) != null)
            {
                List<Tuple<string, string>> tabla = new List<Tuple<string, string>>();
                var propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var propiedad in propiedades)
                {
                    var campo = propiedad.GetGetMethod();
                    if (campo != null)
                    {
                        string nombre = propiedad.Name;
                        string tipoSQL = TypeMapper.MapearTipoSQL(campo.ReturnType);
                        tabla.Add(new Tuple<string, string>(nombre, tipoSQL));
                    }
                }
                return tabla;
            }
            return null;
        }

        public List<Tuple<string, string>>? GenerarTuplasByDysplayNames()
        {
            if (typeof(T) != null)
            {
                List<Tuple<string, string>> tabla = new List<Tuple<string, string>>();
                var propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var propiedad in propiedades)
                {
                    var campo = propiedad.GetGetMethod();
                    if (campo != null)
                    {
                        string nombre = GetDisplayName(propiedad);
                        string tipoSQL = TypeMapper.MapearTipoSQL(campo.ReturnType);
                        tabla.Add(new Tuple<string, string>(nombre, tipoSQL));
                    }
                }

                return tabla;
            }

            return null;
        }

        private string GetDisplayName(PropertyInfo property)
        {
            var displayNameAttribute = property.GetCustomAttribute<DisplayNameAttribute>();
            return displayNameAttribute?.DisplayName ?? property.Name;
        }

        public string GenerarStringColumnsList(bool useDisplayNames = false)
        {
            List<Tuple<string, string>>? fields;

            if (useDisplayNames) 
            {
                fields = GenerarTuplasByDysplayNames();
            } 
            else
            {
                fields = GenerarTuplasByNames();
            }

            if (fields != null)
            {
                string fieldsDefinition = getDef(fields, false);
                fields.Clear();
                return fieldsDefinition;
            }
            else
            {
                return string.Empty;
            }
        }

        public string GenerarStringColumnsDefList(bool useDisplayNames = false)
        {
            List<Tuple<string, string>>? fields;

            if (useDisplayNames)
            {
                fields = GenerarTuplasByDysplayNames();
            }
            else
            {
                fields = GenerarTuplasByNames();
            }

            if (fields != null)
            {
                string fieldsDefinition = getDef(fields, true);
                fields.Clear();
                return fieldsDefinition;
            }
            else
            {
                return string.Empty;
            }
        }

        private string getDef(List<Tuple<string, string>> fields, bool useTypes)
        {
            return useTypes ? string.Join(", ", fields.Select(f => $"{f.Item1} {f.Item2}")) : string.Join(", ", fields.Select(f => $"{f.Item1}"));
        }

        private bool instanceExist(Type classType)
        {
            if (instancias.Count != 0)
            {
                foreach (var instancia in instancias)
                {
                    if (instancia.Item1 == classType)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private Tuple<Type, object?>? findInstance(Type? classType)
        {
            if (instancias.Count != 0 && classType != null)
            {
                foreach (var instancia in instancias)
                {
                    if (instancia.Item1 == classType)
                    {
                        return instancia;
                    }
                }
            }

            return null;
        }
    }
}
