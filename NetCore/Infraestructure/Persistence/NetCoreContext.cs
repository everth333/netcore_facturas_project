﻿using Microsoft.EntityFrameworkCore;
using NetCore.Infraestructure.Persistence.Configuration;
using NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Infraestructure.Persistence
{
    public class NetCoreContext : DbContext
    {
        public NetCoreContext(DbContextOptions<NetCoreContext> options)
                : base(options) {

        }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Detalle> Detalle { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClienteConfiguration());
        }
    }
}
