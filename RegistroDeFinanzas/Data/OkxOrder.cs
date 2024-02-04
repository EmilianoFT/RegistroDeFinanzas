using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeFinanzas.Data

{
    public class OkxOrder
    {
        public long NumeroOrden { get; set; }
        public string TipoOrden { get; set; }
        public string Criptomoneda { get; set; }
        public string Moneda { get; set; }
        public string FuenteOrden { get; set; }
        public string MetodoPago { get; set; }
        public decimal Precio { get; set; }
        public decimal Volumen { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
        public string Contraparte { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizada { get; set; }
    }
}
