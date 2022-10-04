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
    public class EmpleadoDALImpl : IEmpleadoDAL
    {

        PROYECTO_PAWContext context;

        //constructor vacio (sin argumento o parametro)
        public EmpleadoDALImpl()
        {
            context = new PROYECTO_PAWContext();
        }
        public EmpleadoDALImpl(PROYECTO_PAWContext proyectoPAWContext)
        {
            this.context = proyectoPAWContext;
        }

        public bool Add(Empleado entity)
        {
            throw new NotImplementedException();
        }

        public bool AñadeEmpleado(Empleado empleado)
        {
            try
            {
                Empleado result;
                string sql = "[dbo].[añadeEmpleado] @PNOMBRE,@PAPELLIDO1," +
                    "@PAPELLIDO2, @PUSERNAME,@PPASSWORD," +
                    "@PFECHAINGRESO,@PCORREO,@PIDROL";
                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                    ParameterName = "@PNOMBRE",
                    //tipo de variable en el sql
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 20,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = empleado.Nombre
                    },
                    new SqlParameter()
                    {
                    ParameterName = "@PAPELLIDO1",
                    //tipo de variable en el sql
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 20,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = empleado.Apellido1
                    },
                    new SqlParameter()
                    {
                    ParameterName = "@PAPELLIDO2",
                    //tipo de variable en el sql
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 20,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = empleado.Apellido2
                    },
                    new SqlParameter()
                    {
                    ParameterName = "@PUSERNAME",
                    //tipo de variable en el sql
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 20,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = empleado.Username
                    },
                    //new SqlParameter()
                    //{
                    //ParameterName = "@PPASSWORD",
                    ////tipo de variable en el sql
                    //SqlDbType = System.Data.SqlDbType.VarChar,
                    //Size = 20,
                    //Direction = System.Data.ParameterDirection.Input,
                    //Value = empleado.Password
                    //},
                    new SqlParameter()
                    {
                    ParameterName = "@PCORREO",
                    //tipo de variable en el sql
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 40,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = empleado.Correo
                    },
                    new SqlParameter()
                    {
                    ParameterName = "@IDROL",
                    //tipo de variable en el sql
                    SqlDbType = System.Data.SqlDbType.Int,
                    Size = 20,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = empleado.IdRol
                    }
                };

                result = context.Empleados.FromSqlRaw(sql, param, param, param,
                    param, param, param, param).FirstAsync().Result;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //public bool Add(Empleado entity)
        //{
        //    try
        //    {
        //        using (UnidadDeTrabajo<Empleado> unidad = new UnidadDeTrabajo<Empleado>(context))
        //        {

        //            unidad.genericDAL.Add(entity);
        //            return unidad.Complete();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        public void AddRange(IEnumerable<Empleado> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empleado> Find(Expression<Func<Empleado, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Empleado Get(int id)
        {
            try
            {
               Empleado empleado;
               using (UnidadDeTrabajo<Empleado> unidad = new UnidadDeTrabajo<Empleado>(context))
                {
                    //instancia el metodo de IDAL get a partir de unidaddetrabajo
                    empleado = unidad.genericDAL.Get(id);
                }
                return empleado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Empleado> Get()
        {
            using (var conexion = new PROYECTO_PAWContext())
            {
                try
                {
                    var datos = (from x in conexion.Empleados
                                 select x).ToList();
                    List<Empleado> lista = new List<Empleado>();
                    foreach (var dato in datos)
                    {
                        lista.Add(new Empleado
                        {
                            IdEmpleado = dato.IdEmpleado,
                            Nombre = dato.Nombre,
                            Apellido1 = dato.Apellido1,
                            Apellido2 = dato.Apellido2,
                            Username = dato.Username,
                            Passhash = null,
                            FechaIngreso = dato.FechaIngreso,
                            IdRol = dato.IdRol,
                            Correo = dato.Correo
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

        public IEnumerable<Empleado> GetAll()
        {
            try
            {
                IEnumerable<Empleado> empleados;
                using (UnidadDeTrabajo<Empleado> unidad = new UnidadDeTrabajo<Empleado>(context))
                {
                    empleados = unidad.genericDAL.GetAll();
                }
                return empleados;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Empleado entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Empleado> entities)
        {
            throw new NotImplementedException();
        }

        public Empleado SingleOrDefault(Expression<Func<Empleado, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Empleado entity)
        {
            throw new NotImplementedException();
        }


    }
}
