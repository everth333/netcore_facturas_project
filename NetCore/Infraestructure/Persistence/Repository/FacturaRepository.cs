﻿using NetCore.Domain;
using NetCore.Framework;
using NetCore.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.Persistence.Repository
{
    public class FacturaRepository : IBussines<Factura>
    {
        NetCoreContext _dbContext;
        public FacturaRepository(NetCoreContext context)
        {
            _dbContext = context;
        }

        public bool Eliminar(int id)
        {
            using (var oTrans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //eliminando persona
                    Factura efactura = this._dbContext.Factura.FirstOrDefault(e => e.Id == id);
                    this._dbContext.Factura.Remove(efactura);
                    this._dbContext.SaveChanges();

                    oTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
            }
        }

        public Factura GetEntity(int id)
        {
            try
            {
                return this._dbContext.Factura.FirstOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Factura> GetLista()
        {
            try
            {
                return this._dbContext.Factura.OrderByDescending(e => e.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(Factura eEntidad)
        {
            using (var oTrans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //registrando persona
                    this._dbContext.Factura.Add(eEntidad);
                    this._dbContext.SaveChanges();

                    oTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
            }
        }

        public bool Modificar(Factura eEntidad)
        {
            using (var oTrans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //modificando persona
                    this._dbContext.Factura.Update(eEntidad);
                    this._dbContext.SaveChanges();

                    oTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
            }
        }
    }
}
