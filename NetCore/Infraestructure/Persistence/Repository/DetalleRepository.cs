using NetCore.Domain;
using NetCore.Framework;
using NetCore.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.Persistence.Repository
{
    public class DetalleRepository : IBussines<Detalle>
    {
        NetCoreContext _dbContext;
        public DetalleRepository(NetCoreContext context)
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
                    Detalle edetalle = this._dbContext.Detalle.FirstOrDefault(e => e.Id == id);
                    this._dbContext.Detalle.Remove(edetalle);
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

        public Detalle GetEntity(int id)
        {
            try
            {
                return this._dbContext.Detalle.FirstOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Detalle> GetLista()
        {
            try
            {
                return this._dbContext.Detalle.OrderByDescending(e => e.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(Detalle eEntidad)
        {
            using (var oTrans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //registrando persona
                    this._dbContext.Detalle.Add(eEntidad);
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

        public bool Modificar(Detalle eEntidad)
        {
            using (var oTrans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //modificando persona
                    this._dbContext.Detalle.Update(eEntidad);
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
