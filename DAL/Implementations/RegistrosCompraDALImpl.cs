using DAL.Interfaces;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class RegistrosCompraDALImpl : IResgistrosCompraDAL
    {

        PROYECTO_PAWContext context;

        //constructor vacio (sin argumento o parametro)
        public RegistrosCompraDALImpl()
        {
            context = new PROYECTO_PAWContext();
        }
        public RegistrosCompraDALImpl(PROYECTO_PAWContext proyectoPAWContext)
        {
            this.context = proyectoPAWContext;
        }

        public bool Add(RegistroCompra entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<RegistroCompra> entities)
        {
            throw new NotImplementedException();
        }

        public string AgregarRegistro(RegistroCompra registroCompra)
        {
            if (validarCarrito())
            {
                if (registroCompra.CedulaCliente != null && registroCompra.IdEmpleado != 0)
                {
                    using (var conexion = new PROYECTO_PAWContext())
                    {
                        try
                        {
                            //if que valide si la cedula existe. si existe, permitir campos en blanco.
                            //si no existe, pedir NOMBRE CORREO TELEFONO del cliente.
                            var datosclientes = (from x in conexion.ClientesAtendidos
                                                 where x.CedulaCliente == registroCompra.CedulaCliente
                            select x).ToList();
                            if (datosclientes.Count == 0 && registroCompra.NombreCliente != null && registroCompra.Correo != null
                            && registroCompra.Telefono != null && (registroCompra.IdMetodo == 1 || registroCompra.IdMetodo == 2))
                            {
                                var datos = (from x in conexion.Carritos
                                             select x).ToList();
                                if (datos != null)
                                {
                                    decimal TOTAL_COMPRA = 0;
                                    foreach (var dato in datos)
                                    {
                                        TOTAL_COMPRA = TOTAL_COMPRA + dato.Total;
                                    }
                                    RegistroCompra registro = new RegistroCompra();
                                    registro.CedulaCliente = registroCompra.CedulaCliente;
                                    registro.NombreCliente = registroCompra.NombreCliente;
                                    registro.Correo = registroCompra.Correo;
                                    registro.Telefono = registroCompra.Telefono;
                                    registro.Fecha = DateTime.Now;
                                    registro.TotalCompra = TOTAL_COMPRA;
                                    registro.IdMetodo = registroCompra.IdMetodo;
                                    registro.IdEmpleado = registroCompra.IdEmpleado;
                                    registro.NombreEmpleado = registroCompra.NombreEmpleado;
                                    conexion.RegistroCompras.Add(registro);
                                    conexion.SaveChanges();

                                    ClientesAtendido clientes_atendidos = new ClientesAtendido();
                                    clientes_atendidos.CedulaCliente = registro.CedulaCliente;
                                    clientes_atendidos.NombreCliente = registro.NombreCliente;
                                    clientes_atendidos.Correo = registro.Correo;
                                    clientes_atendidos.Telefono = registro.Telefono;
                                    clientes_atendidos.Fecha = DateTime.Now;
                                    clientes_atendidos.IdCompra = registro.IdCompra;
                                    conexion.ClientesAtendidos.Add(clientes_atendidos);
                                    conexion.SaveChanges();
                                    vaciarCarrito();
                                    return "Compra Confirmada - cliente registrado con éxito";
                                }
                            }
                            if (datosclientes.Count > 0 && (registroCompra.IdMetodo == 1 || registroCompra.IdMetodo == 2))
                            {
                                var datos = (from x in conexion.Carritos
                                             select x).ToList();
                                if (datos != null)
                                {
                                    decimal TOTAL_COMPRA = 0;
                                    foreach (var dato in datos)
                                    {
                                        TOTAL_COMPRA = TOTAL_COMPRA + dato.Total;
                                    }

                                    RegistroCompra registro = new RegistroCompra();
                                    registro.CedulaCliente = registroCompra.CedulaCliente;
                                    registro.NombreCliente = registroCompra.NombreCliente;
                                    registro.Correo = registroCompra.Correo;
                                    registro.Telefono = registroCompra.Telefono;
                                    registro.Fecha = DateTime.Now;
                                    registro.TotalCompra = TOTAL_COMPRA;
                                    registro.IdMetodo = registroCompra.IdMetodo;
                                    registro.IdEmpleado = registroCompra.IdEmpleado;
                                    registro.NombreEmpleado = registroCompra.NombreEmpleado;
                                    conexion.RegistroCompras.Add(registro);
                                    conexion.SaveChanges();


                                    ClientesAtendido clientes_atendidos = new ClientesAtendido();
                                    clientes_atendidos.CedulaCliente = registro.CedulaCliente;
                                    clientes_atendidos.NombreCliente = registro.NombreCliente;
                                    clientes_atendidos.Correo = registro.Correo;
                                    clientes_atendidos.Telefono = registro.Telefono;
                                    clientes_atendidos.Fecha = DateTime.Now;
                                    clientes_atendidos.IdCompra = registro.IdCompra;
                                    conexion.ClientesAtendidos.Add(clientes_atendidos);
                                    conexion.SaveChanges();
                                    vaciarCarrito();
                                    return "Compra Confirmada - cliente existente";
                                }
                            }
                            if (datosclientes.Count == 0 && registroCompra.NombreCliente == null || registroCompra.Correo == null
                            || registroCompra.Telefono == null || registroCompra.IdMetodo != 1 || registroCompra.IdMetodo != 2)
                            {
                                return "Complete Nombre, Correo, " +
                                    "Teléfono del cliente y un Método de pago, para confirmar la compra";
                            }
                            else
                            {
                                return "Ingrese cédula del cliente y su ID de empleado";
                            }
                        }
                        catch (Exception ex)
                        {
                            conexion.Dispose();
                            throw ex;
                        }
                    }
                }
                else
                {
                    return "Ingrese cédula del cliente y su ID de empleado";
                }
            }
            else
            {
                return "El carrito está vacío";
            }
        }

        public IEnumerable<RegistroCompra> Find(Expression<Func<RegistroCompra, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RegistroCompra Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroCompra> GetAll()
        {
            try
            {
                IEnumerable<RegistroCompra> registroscomp;
                using (UnidadDeTrabajo<RegistroCompra> unidad = new UnidadDeTrabajo<RegistroCompra>(context))
                {
                    registroscomp = unidad.genericDAL.GetAll();
                }
                return registroscomp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(RegistroCompra entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<RegistroCompra> entities)
        {
            throw new NotImplementedException();
        }

        public RegistroCompra SingleOrDefault(Expression<Func<RegistroCompra, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(RegistroCompra entity)
        {
            throw new NotImplementedException();
        }

        public void vaciarCarrito()
        {
            using (var conexion = new PROYECTO_PAWContext())
            {
                try
                {
                    var datos = (from x in conexion.Carritos
                                 select x).ToList();
                    foreach (var dato in datos)
                    {
                        conexion.Carritos.Remove(dato);
                    }
                    conexion.SaveChanges();
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        }

        public bool validarCarrito()
        {

            using (var conexion = new PROYECTO_PAWContext())
            {
                try
                {
                    var datos = (from x in conexion.Carritos
                                 select x).ToList();
                    if (datos.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }

        }
    }     
}
