using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace NetCore.WebAPI.Controllers.Resources
{
    public class FacturaResource
    {

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Importe { get; set; }

        [Required]
        public int Nit { get; set; }

        [Required]
        [MaxLength(100)]
        public string Razon_Social { get; set; }

        [Required]
        [MaxLength(100)]
        public string Codigo_Control { get; set; }

        [Required]
        public int Modo_Pago { get; set; }
       

        public int Codigo_Tarjeta { get; set; }
    }
}
