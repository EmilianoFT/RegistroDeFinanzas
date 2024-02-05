using AccesoADatos;
using RegistroDeFinanzas.Data;
using System.Globalization;

namespace RegistroDeFinanzas.commons
{
    public static class OkxCsvProcessor
    {
        static csvAccess<OkxOrder> okxCsvAccess = new csvAccess<OkxOrder>();
        public static List<string>? errors { get; set; }
        public static List<OkxOrder>? Abrir(string filePath)
        {
            try 
            { 
                return okxCsvAccess.ReadAll(filePath);
            }
            catch (Exception ex)
            {
                errors.Add("Error al procesar el archivo CSV: " + ex.Message);
            }

            return null;
        }

        public static List<OkxOrder>? AbrirDirectorio(string directoryPath)
        {
            List<OkxOrder> consolidatedData = new List<OkxOrder>();

            try
            {
                if (Directory.Exists(directoryPath))
                {
                    string[] csvFiles = Directory.GetFiles(directoryPath, "*.csv");
                    foreach (string csvFile in csvFiles)
                    {
                        List<OkxOrder>? fileData = Abrir(csvFile);
                        if (fileData != null)
                        {
                            consolidatedData.AddRange(fileData);
                        }
                    }
                }
                else
                {
                    errors.Add($"El directorio '{directoryPath}' no existe.");
                }
            }
            catch (Exception ex)
            {
                errors.Add("Error al procesar los archivos CSV en el directorio: " + ex.Message);
            }

            return consolidatedData.Count > 0 ? consolidatedData : null;
        }

        public static void guardar(string filePath, List<OkxOrder> datalist)
        {
            try
            {
                okxCsvAccess.ApendAll(filePath, datalist);
            }
            catch (Exception ex)
            {
                errors.Add("Error al guardar el archivo CSV: " + ex.Message);
            }
        }
    }
}
