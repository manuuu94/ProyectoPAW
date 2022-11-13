using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ServicioDALImpl : IServicioDAL
    {

        PROYECTO_PAWContext context;

        //constructor vacio (sin argumento o parametro)
        public ServicioDALImpl()
        {
            context = new PROYECTO_PAWContext();
        }
        public ServicioDALImpl(PROYECTO_PAWContext proyectoPAWContext)
        {
            this.context = proyectoPAWContext;
        }

        public bool Add(RegistrosInventario entity)
        {
            throw new NotImplementedException();
        }

        public bool Add(Servicio entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<RegistrosInventario> entities)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Servicio> entities)
        {
            throw new NotImplementedException();
        }

     

        public IEnumerable<Servicio> Find(Expression<Func<Servicio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Servicio Get(int idServicio)
        {
            try
            {
                //variable tipo category
                Servicio Servicio;
                //using la unidaddetrabajo con entity tipo Category y context
                using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(context))
                {
                    //instancia el metodo de IDAL get a partir de unidaddetrabajo
                    Servicio = unidad.genericDAL.Get(idServicio);
                }
                return Servicio;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Servicio> GetAll()
        {
            try
            {
                IEnumerable<Servicio> Servicio;
                using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(context))
                {
                    Servicio = unidad.genericDAL.GetAll();
                }
                return Servicio;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Servicio entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Servicio> entities)
        {
            throw new NotImplementedException();
        }

        public Servicio SingleOrDefault(Expression<Func<Servicio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        

        public bool Update(Servicio entity)
        {
            throw new NotImplementedException();
        }
    }
}
