using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.commons
{
    public static class ClassToDefinition
    {
        static dynamic? classToDefinitionHelperInstance = null;
        public static dynamic? getInstance(Type classType)
        {
            if (classToDefinitionHelperInstance == null)
            {
                classToDefinitionHelperInstance = Activator.CreateInstance(typeof(ClassToDefinitionHelper<>).MakeGenericType(classType));
            }
            return classToDefinitionHelperInstance.getInstance(classType);  
        }
    }
}
