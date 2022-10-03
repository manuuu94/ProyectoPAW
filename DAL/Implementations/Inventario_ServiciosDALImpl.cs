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
    public class Inventario_ServiciosDALImpl : IInventario_ServiciosDAL
    {
        //conexion
        PROYECTO_PAWContext context;

        //constructor vacio (sin argumento o parametro)
        public Inventario_ServiciosDALImpl()
        {
            context = new PROYECTO_PAWContext();
        }
        //constructor - ambos son para instanciar un nuevo objeto NORTHWINDContext - se usa cualquiera
        public Inventario_ServiciosDALImpl(PROYECTO_PAWContext proyectoPAWContext)
        {
            this.context = proyectoPAWContext;
        }


        public bool Add(InventarioServicio entity)
        {
            try
            {
                //la unidad de trabajo, que es generica. tipo category en este caso. cualquier nombre "unidad" para la instancia.
                //Dentro del parametro va un context (nombre de la conexion) creado antes. por esto el context requiere un constructor. 
                using (UnidadDeTrabajo<InventarioServicio> unidad = new UnidadDeTrabajo<InventarioServicio>(context))
                {
                    //instancia IDALGenerica (i.e: genericDAL.add(entity))
                    unidad.genericDAL.Add(entity);
                    //save changes
                    return unidad.Complete();
                }//aqui sucede el dispose por el using a UnidadDeTrabajo con el context (conexion)
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<InventarioServicio> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventarioServicio> Find(Expression<Func<InventarioServicio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public InventarioServicio Get(int idProducto)
        {
            try
            {
                //variable tipo category
                InventarioServicio producto;
                //using la unidaddetrabajo con entity tipo Category y context
                using (UnidadDeTrabajo<InventarioServicio> unidad = new UnidadDeTrabajo<InventarioServicio>(context))
                {
                    //instancia el metodo de IDAL get a partir de unidaddetrabajo
                    producto = unidad.genericDAL.Get(idProducto);
                }
                return producto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<InventarioServicio> Get()
        {
            try
            {
                IEnumerable<InventarioServicio> categories;
                using (UnidadDeTrabajo<InventarioServicio> unidad = new UnidadDeTrabajo<InventarioServicio>(context))
                {
                    categories = unidad.genericDAL.GetAll();
                }
                return categories.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<InventarioServicio> GetAll()
        {
            try
            {
                IEnumerable<InventarioServicio> categories;
                using (UnidadDeTrabajo<InventarioServicio> unidad = new UnidadDeTrabajo<InventarioServicio>(context))
                {
                    categories = unidad.genericDAL.GetAll();
                }
                return categories;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<InventarioServicio> GetByName(string Descripcion)
        {
            List<InventarioServicio> lista;

            using (context = new PROYECTO_PAWContext())
            {
                lista = (from c in context.InventarioServicios
                         where c.Descripcion.Contains(Descripcion)
                         select c).ToList();
            }
            return lista;

        }



        public bool Remove(InventarioServicio entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<InventarioServicio> unidad = new UnidadDeTrabajo<InventarioServicio>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<InventarioServicio> entities)
        {
            throw new NotImplementedException();
        }

        public InventarioServicio SingleOrDefault(Expression<Func<InventarioServicio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(InventarioServicio producto)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<InventarioServicio> unidad = new UnidadDeTrabajo<InventarioServicio>(context))
                {
                    unidad.genericDAL.Update(producto);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }


    }
}