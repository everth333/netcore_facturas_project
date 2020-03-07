﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Entities;
using MediatR;

namespace NetCore.Infraestructure.Commands.Facturas
{
    public class CreateDetalleCommand : IRequest<Factura>
    {

        public int IdCliente { get; private set; }
        public DateTime Fecha { get; private set; }
        public decimal Importe { get; private set; }
        public int Nit { get; private set; }
        public string Razon_Social { get; private set; }
        public string Codigo_Control { get; private set; }
        public int Modo_Pago { get; private set; }
        public int Codigo_Tarjeta { get; private set; }


        public CreateDetalleCommand(int idCliente,DateTime fecha,  decimal importe, int nit, string razon_Social, string codigo_Control, int modo_Pago, int codigo_Tarjeta)
        {
            this.IdCliente = idCliente;
            this.Fecha = fecha;
            this.Importe = importe;
            this.Nit = nit;
            this.Razon_Social = razon_Social;
            this.Codigo_Control = codigo_Control;
            this.Modo_Pago = modo_Pago;
            this.Codigo_Tarjeta = codigo_Tarjeta;

        }


    }
}
