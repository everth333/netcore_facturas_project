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
        [Required]
        [MaxLength(100)]
        public string Nombre { get; private set; }
        [Required]
        [MaxLength(150)]
        public string Apellidos { get; private set; }
        [Required]
        public DateTime FechaNaciemiento { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; private set; }
        [Required]
        [MaxLength(50)]
        public string Telefono { get; private set; }
        
        public Direccion Direccion { get; private set; }

        public DateTime DateCreated { get; private set; }
        public DateTime? DateUpdated { get; private set; }

    }
}
