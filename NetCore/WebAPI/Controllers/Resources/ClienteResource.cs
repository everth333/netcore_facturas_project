using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using NetCore.Domain.ValueObject;

namespace NetCore.WebAPI.Controllers.Resources
{
    public class ClienteResource
    {
     //   [Required]
        [MaxLength(100)]
        public string Nombre { get;  set; }
     //   [Required]
        [MaxLength(150)]
        public string Apellidos { get;  set; }
      //  [Required]
        public DateTime FechaNaciemiento { get;  set; }
      //  [Required]
        [MaxLength(100)]
        public string Email { get;  set; }
       // [Required]
        [MaxLength(50)]
        public string Telefono { get;  set; }
        
        public Direccion Direccion { get;  set; }

        public DateTime DateCreated { get;  set; }
        public DateTime? DateUpdated { get;  set; }

    }
}
