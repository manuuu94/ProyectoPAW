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
            using (var conexion = new PROYECTO_PAWContext())
            {
                try
                {
                    var datos = (from x in conexion.InventarioServicios
                                 where x.IdProducto == entity.Id
                                 select x).FirstOrDefault();
                    if (datos.CantidadDisponible >= entity.Cantidad && datos != null &&
                        datos.CantidadDisponible != 0 && entity.Cantidad > 0)
                    {
                        datos.CantidadDisponible = datos.CantidadDisponible - entity.Cantidad;

                        Carrito carro = new Carrito();
                        carro.Descripcion = datos.Descripcion;
                        carro.Precio = datos.Precio;
                        carro.Cantidad = entity.Cantidad;
                        carro.Total = carro.Precio * carro.Cantidad;
                        carro.IdProducto = datos.IdProducto;
                        conexion.Carritos.Add(carro);
                        conexion.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        }
        //cycle error for some reason but it works 
        //{
        //    try
        //    {
        //        using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
        //        //using (context = new PROYECTO_PAWContext())
        //        {
        //            var datos = (from x in context.InventarioServicios
        //                         where x.IdProducto == entity.IdProducto
        //                         select x).FirstOrDefault();
        //            if (datos.CantidadDisponible >= entity.Cantidad && datos != null &&
        //                datos.CantidadDisponible != 0 && entity.Cantidad > 0)
        //            {
        //                datos.CantidadDisponible = datos.CantidadDisponible - entity.Cantidad;
        //                //context.SaveChanges();
        //                //context.Dispose();

        //                //using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
        //                //{
        //                    entity.Total = entity.Cantidad * entity.Precio;
        //                    unidad.genericDAL.Add(entity);
        //                    return unidad.Complete();
        //                //}
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

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
            using (var conexion = new PROYECTO_PAWContext())
            {
                try
                {
                    var datos = (from x in conexion.Carritos
                                 where x.IdProd == entity.IdProd
                                 select x).FirstOrDefault();
                    if (datos != null)
                    {
                        var datosx = (from x in conexion.InventarioServicios
                                      where x.IdProducto == datos.IdProducto
                                      select x).FirstOrDefault();
                        datosx.CantidadDisponible = datosx.CantidadDisponible + datos.Cantidad;
                        conexion.Carritos.Remove(datos);
                        conexion.SaveChanges();
                        //conexion.Dispose();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    conexion.Dispose();
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        }
        //{
        //    bool result = false;
        //    try
        //    {
        //        using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
        //        {
        //            unidad.genericDAL.Remove(entity);
        //            result = unidad.Complete();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        result = false;
        //    }
        //    return result;
        //}


        public bool RemoveAll()
        {
            using (var conexion = new PROYECTO_PAWContext())
            {
                try
                {
                    var datos = (from x in conexion.Carritos
                                 select x).ToList();
                    if (datos.Count != 0)
                    {
                        foreach (var dato in datos)
                        {
                            var datosx = (from x in conexion.InventarioServicios
                                          where x.IdProducto == dato.IdProducto
                                          select x).FirstOrDefault();
                            datosx.CantidadDisponible = datosx.CantidadDisponible + dato.Cantidad;
                            conexion.Carritos.Remove(dato);
                        }
                        conexion.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
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
