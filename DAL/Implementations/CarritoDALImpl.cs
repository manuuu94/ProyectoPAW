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
    public class CarritoDALImpl : ICarritoDAL
    {
        //conexion
        PROYECTO_PAWContext context;

        //constructor vacio (sin argumento o parametro)
        public CarritoDALImpl()
        {
            context = new PROYECTO_PAWContext();
        }
        public CarritoDALImpl(PROYECTO_PAWContext proyectoPAWContext)
        {
            this.context = proyectoPAWContext;
        }


        public bool Add(Carrito entity)
        {
            try
            {
                using (context = new PROYECTO_PAWContext())
                {
                    var datos = (from x in context.InventarioServicios
                                 where x.IdProducto == entity.IdProducto
                                 select x).FirstOrDefault();
                    if (datos.CantidadDisponible >= entity.Cantidad && datos != null &&
                        datos.CantidadDisponible != 0 && entity.Cantidad > 0)
                    {
                        datos.CantidadDisponible = datos.CantidadDisponible - entity.Cantidad;
                        context.SaveChanges();
                        context.Dispose();
                        using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
                        {
                            entity.Total = entity.Cantidad * entity.Precio;
                            return unidad.Complete();
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Carrito> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carrito> Find(Expression<Func<Carrito, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Carrito Get(int id)
        {
            throw new NotImplementedException();
        }
        public List<Carrito> Get()
        {
            try
            {
                IEnumerable<Carrito> carrito;
                using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
                {
                    carrito = unidad.genericDAL.GetAll();
                }
                return carrito.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Carrito> GetAll()
        {
            try
            {
                IEnumerable<Carrito> carrito;
                using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
                {
                    carrito = unidad.genericDAL.GetAll();
                }
                return carrito;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Carrito entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Carrito> entities)
        {
            throw new NotImplementedException();
        }

        public Carrito SingleOrDefault(Expression<Func<Carrito, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Carrito entity)
        {
            throw new NotImplementedException();
        }
    }
}
