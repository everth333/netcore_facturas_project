using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.WebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADM_Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(type: "sysdatetime()", nullable: false, defaultValueSql: "sysdatetime()"),
                    DateUpdated = table.Column<DateTime>(type: "sysdatetime()", nullable: true),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Apellidos = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    FechaNaciemiento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Barrio = table.Column<string>(maxLength: 100, nullable: true, defaultValue: ""),
                    Calle = table.Column<string>(maxLength: 100, nullable: true, defaultValue: ""),
                    Numero = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADM_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADM_Detalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdFactura = table.Column<int>(type: "INT", nullable: false),
                    IdProducto = table.Column<int>(type: "INT", nullable: false),
                    Precio = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADM_Detalle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADM_Factura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCliente = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Importe = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Nit = table.Column<int>(type: "INT", nullable: false),
                    Razon_Social = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Codigo_Control = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Modo_Pago = table.Column<int>(type: "INT", nullable: false),
                    Codigo_Tarjeta = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADM_Factura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADM_Persona",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    ApellidoPaterno = table.Column<string>(nullable: true),
                    ApellidoMaterno = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADM_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADM_Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Costo = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Precio = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Stock = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADM_Producto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADM_Cliente");

            migrationBuilder.DropTable(
                name: "ADM_Detalle");

            migrationBuilder.DropTable(
                name: "ADM_Factura");

            migrationBuilder.DropTable(
                name: "ADM_Persona");

            migrationBuilder.DropTable(
                name: "ADM_Producto");
        }
    }
}
