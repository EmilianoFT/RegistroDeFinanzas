using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeFinanzas.Data

{
    public class OkxOrder
    {
        [DisplayName("N.o de orden")]
        public long NumeroOrden { get; set; }

        [DisplayName("Tipo de orden")]
        public string? TipoOrden { get; set; }

        [DisplayName("Criptomoneda")]
        public string? Criptomoneda { get; set; }

        [DisplayName("Moneda")]
        public string? Moneda { get; set; }

        [DisplayName("Fuente de orden")]
        public string? FuenteOrden { get; set; }

        [DisplayName("Método de pago")]
        public string? MetodoPago { get; set; }

        [DisplayName("Precio")]
        public decimal Precio { get; set; }

        [DisplayName("Volumen")]
        public decimal Volumen { get; set; }

        [DisplayName("Monto")]
        public decimal Monto { get; set; }

        [DisplayName("Estado")]
        public string? Estado { get; set; }

        [DisplayName("Contraparte")]
        public string? Contraparte { get; set; }

        [DisplayName("Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

        [DisplayName("Fecha actualizada")]
        public DateTime FechaActualizada { get; set; }
    }
}
