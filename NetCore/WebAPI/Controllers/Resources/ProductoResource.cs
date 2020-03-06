using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NetCore.WebAPI.Controllers.Resources
{
    public class ProductoResource
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }


        [Required]        
        public decimal Costo { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public decimal Stock { get; set; }
    }
}
