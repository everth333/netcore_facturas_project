using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Infraestructure.Communication;
using NetCore.Domain;
using MediatR;
using NetCore.Domain.Entities;
using NetCore.Domain.ValueObject;

namespace NetCore.Infraestructure.Commands.Clientes
{
    public class UpdateClienteCommand : IRequest<Response<Cliente>>
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellidos { get; private set; }
        public DateTime FechaNaciemiento { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public Direccion Direccion { get; private set; }

        public DateTime DateCreated { get; private set; }
        public DateTime? DateUpdated { get; private set; }

        public UpdateClienteCommand(int id,string nombre, string apellidos, DateTime fecnac, string email, string telefono, Direccion direccion, DateTime datecreate, DateTime? dateupdate)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.FechaNaciemiento = fecnac;
            this.Email = email;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.DateCreated = datecreate;
            this.DateUpdated = dateupdate;
        }

    }
}
