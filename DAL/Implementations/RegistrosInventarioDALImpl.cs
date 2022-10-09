using DAL.Interfaces;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class RegistrosInventarioDALImpl : IResgistrosInventarioDAL
    {

        PROYECTO_PAWContext context;

        //constructor vacio (sin argumento o parametro)
        public RegistrosInventarioDALImpl()
        {
            context = new PROYECTO_PAWContext();
        }
        public RegistrosInventarioDALImpl(PROYECTO_PAWContext proyectoPAWContext)
        {
            this.context = proyectoPAWContext;
        }

        public bool Add(RegistrosInventario entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<RegistrosInventario> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistrosInventario> Find(Expression<Func<RegistrosInventario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RegistrosInventario Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistrosInventario> GetAll()
        {
            try
            {
                IEnumerable<RegistrosInventario> registrosinv;
                using (UnidadDeTrabajo<RegistrosInventario> unidad = new UnidadDeTrabajo<RegistrosInventario>(context))
                {
                    registrosinv = unidad.genericDAL.GetAll();
                }
                return registrosinv;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(RegistrosInventario entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<RegistrosInventario> entities)
        {
            throw new NotImplementedException();
        }

        public RegistrosInventario SingleOrDefault(Expression<Func<RegistrosInventario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(RegistrosInventario entity)
        {
            throw new NotImplementedException();
        }
    }     
}
