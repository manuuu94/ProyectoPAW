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
    public class MetodosPagoDALImpl : IMetodosPagoDAL
    {

        PROYECTO_PAWContext context;

        //constructor vacio (sin argumento o parametro)
        public MetodosPagoDALImpl()
        {
            context = new PROYECTO_PAWContext();
        }
        public MetodosPagoDALImpl(PROYECTO_PAWContext proyectoPAWContext)
        {
            this.context = proyectoPAWContext;
        }

        public bool Add(MetodosPago entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<MetodosPago> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MetodosPago> Find(Expression<Func<MetodosPago, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<MetodosPago> Get()
        {
            using (var conexion = new PROYECTO_PAWContext())
            {
                try
                {
                    var datos = (from x in conexion.MetodosPagos
                                 select x).ToList();
                    List<MetodosPago> lista = new List<MetodosPago>();
                    foreach (var dato in datos)
                    {
                        lista.Add(new MetodosPago
                        {
                            IdMetodo = dato.IdMetodo,
                            Descripcion = dato.Descripcion
                        });
                        
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        }

        public MetodosPago Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MetodosPago> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(MetodosPago entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<MetodosPago> entities)
        {
            throw new NotImplementedException();
        }

        public MetodosPago SingleOrDefault(Expression<Func<MetodosPago, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(MetodosPago entity)
        {
            throw new NotImplementedException();
        }
    }
}
