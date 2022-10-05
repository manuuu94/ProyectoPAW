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
    public class UsuarioDALImpl : IUsuarioDAL
    {
        PROYECTO_PAWContext context;

        //constructor vacio (sin argumento o parametro)
        public UsuarioDALImpl()
        {
            context = new PROYECTO_PAWContext();
        }
        public UsuarioDALImpl(PROYECTO_PAWContext proyectoPAWContext)
        {
            this.context = proyectoPAWContext;
        }


        public bool Add(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Find(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public Usuario SingleOrDefault(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ValidarUsuario(Usuario usuario)
        {
            using (var conexion = new PROYECTO_PAWContext())
            {
                try
                {
                    List<Usuario> result;
                    string sql = "[dbo].[validarUsuario] @PUSERNAME, @PPASSWORD";
                    var param = new SqlParameter[]
                    {
                        new SqlParameter()
                        {
                            ParameterName = "@PUSERNAME",
                            SqlDbType = System.Data.SqlDbType.VarChar,
                            Size = 20,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = usuario.Username
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@PPASSWORD",
                            SqlDbType = System.Data.SqlDbType.VarChar,
                            Size = 20,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = usuario.Password
                        }
                    };
                    result = context.usuario.FromSqlRaw(sql, param).ToListAsync().Result;
                    List<Usuario> lista = new List<Usuario>();
                    foreach(var item in result)
                    {
                        lista.Add(
                            new Usuario
                            {
                                Username = item.Username,
                                Password = null
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


        public bool CambiaContraseña(Usuario usuario)
        {
            try
            {
                string sql = "[dbo].[cambiarContraseña] @PUSERNAME,@PPASSWORD";
                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                    ParameterName = "@PUSERNAME",
                    //tipo de variable en el sql
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 20,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = usuario.Username
                    },
                    new SqlParameter()
                    {
                    ParameterName = "@PPASSWORD",
                    //tipo de variable en el sql
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 20,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = usuario.Password
                    }
                };

                context.Database.ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }








    }
}

