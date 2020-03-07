using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace NetCore.WebAPI.Controllers.Resources
{
    public class DetalleResource
    {
        [Required]
        public int IdFactura { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}
