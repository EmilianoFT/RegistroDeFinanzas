using RegistroDeFinanzas.Data;
using System.Globalization;

namespace RegistroDeFinanzas.commons
{
    public class OkxCsvProcessor
    {
        public static List<OkxOrder> Abrir(string filePath)
        {
            List<OkxOrder> ordenes = new List<OkxOrder>();
            CultureInfo cultureInfo = new CultureInfo("en-US");

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                //TODO: pasar el código de lectura, parseo y guardado de csv a AccesoADatos usando las clases genericas...
                // Ignorar la primera línea ya que contiene los nombres de las columnas
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');

                    OkxOrder orden = new OkxOrder
                    {
                        NumeroOrden = long.Parse(values[0]),
                        TipoOrden = values[1],
                        Criptomoneda = values[2],
                        Moneda = values[3],
                        FuenteOrden = values[4],
                        MetodoPago = values[5],
                        Precio = decimal.Parse(values[6], cultureInfo),
                        Volumen = decimal.Parse(values[7], cultureInfo),
                        Monto = decimal.Parse(values[8], cultureInfo),
                        Estado = values[9],
                        Contraparte = values[10],
                        FechaCreacion = DateTime.Parse(values[11]),
                        FechaActualizada = DateTime.Parse(values[12])
                    };

                    ordenes.Add(orden);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar el archivo CSV: " + ex.Message);
            }

            return ordenes;
        }
    }
}
