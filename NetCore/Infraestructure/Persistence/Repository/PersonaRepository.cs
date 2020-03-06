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
    public class PersonaRepository : IBussines<Persona>
    {
        NetCoreContext _dbContext;
        public PersonaRepository(NetCoreContext context)
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
                    Persona epersona = this._dbContext.Persona.FirstOrDefault(e => e.Id == id);
                    this._dbContext.Persona.Remove(epersona);
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

        public Persona GetEntity(int id)
        {
            try
            {
                return this._dbContext.Persona.FirstOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Persona> GetLista()
        {
            try
            {
                return this._dbContext.Persona.OrderByDescending(e => e.Id);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public bool Guardar(Persona eEntidad)
        {
            using (var oTrans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //registrando persona
                    this._dbContext.Persona.Add(eEntidad);
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

        public bool Modificar(Persona eEntidad)
        {
            using (var oTrans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //modificando persona
                    this._dbContext.Persona.Update(eEntidad);
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
