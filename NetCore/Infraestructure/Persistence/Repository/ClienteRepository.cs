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
    public class ClienteRepository : IBussines<Cliente>
    {
        NetCoreContext _dbContext;
        public ClienteRepository(NetCoreContext context)
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
                    Cliente ecliente = this._dbContext.Cliente.FirstOrDefault(e => e.Id == id);
                    this._dbContext.Cliente.Remove(ecliente);
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

        public Cliente GetEntity(int id)
        {
            try
            {
                return this._dbContext.Cliente.FirstOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Cliente> GetLista()
        {
            try
            {
                return this._dbContext.Cliente.OrderByDescending(e => e.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(Cliente eEntidad)
        {
            using (var oTrans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //registrando persona
                    this._dbContext.Cliente.Add(eEntidad);
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

        public bool Modificar(Cliente eEntidad)
        {
            using (var oTrans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //modificando persona
                    this._dbContext.Cliente.Update(eEntidad);
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
