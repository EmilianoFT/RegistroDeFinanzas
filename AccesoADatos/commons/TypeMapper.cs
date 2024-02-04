using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.commons
{
    public static class TypeMapper
    {
        public static object MapearValorParam(Type tipo)
        {
            switch (Type.GetTypeCode(tipo))
            {
                case TypeCode.Int32:
                    return (object)int.MinValue;
                case TypeCode.String:
                    return (object)string.Empty;
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return (object)double.NaN;
                case TypeCode.Boolean:
                    return (object)false;
                case TypeCode.DateTime:
                    return (object)DateTime.MinValue;
                case TypeCode.Int64:
                    return (object)Int64.MinValue;
                default:
                    return (object)string.Empty;
            }
        }

        public static long MapearSizeValorParam(object data)
        {
            TypeCode typeCode = Type.GetTypeCode(data.GetType());

            switch (typeCode)
            {
                case TypeCode.Int32:
                    return sizeof(int);
                case TypeCode.String:
                    return Encoding.Default.GetByteCount((string)data) + 1;
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return sizeof(double);
                case TypeCode.Boolean:
                    return sizeof(bool);
                case TypeCode.DateTime:
                    return sizeof(long);
                case TypeCode.Int64:
                    return sizeof(long);
                default:
                    return Encoding.Default.GetByteCount((string)data);
            }
        }

        public static string MapearTipoSQL(Type tipo)
        {
            switch (Type.GetTypeCode(tipo))
            {
                case TypeCode.Int32:
                    return "SMALLINT";
                case TypeCode.String:
                    return "VARCHAR";
                case TypeCode.DateTime:
                    return "DATETIME";
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return "FLOAT";
                case TypeCode.Boolean:
                    return "BIT";
                case TypeCode.Int64:
                    return "INTEGER";
                default:
                    return tipo.Name.ToUpper();
            }
        }

        public static DataTypeEnum MapearTipoParam(String tipo)
        {
            switch (tipo)
            {
                case "SMALLINT":
                    return DataTypeEnum.adInteger;
                case "VARCHAR":
                    return DataTypeEnum.adVarChar;
                case "DATETIME":
                    return DataTypeEnum.adDate;
                case "FLOAT":
                    return DataTypeEnum.adDouble;
                case "BIT":
                    return DataTypeEnum.adBoolean;
                case "INTEGER":
                    return DataTypeEnum.adBigInt;
                default:
                    return DataTypeEnum.adLongVarWChar;
            }
        }
    }

}
