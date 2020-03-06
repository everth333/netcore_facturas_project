using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore.Entities;

namespace NetCore.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<Producto> Producto { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Producto>().HasData
            //(
            //    new Producto { Id = 100, Name = "First User", Age = 19 },
            //    new Producto { Id = 101, Name = "Second User", Age = 24 },
            //    new Producto { Id = 102, Name = "Thirg User", Age = 37 }
            //);
        }
    }
}
