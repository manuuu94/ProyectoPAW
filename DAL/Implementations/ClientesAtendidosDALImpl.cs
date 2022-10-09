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
    public class ClientesAtendidosDALImpl : IClientesAtendidosDAL
    {

        PROYECTO_PAWContext context;

        //constructor vacio (sin argumento o parametro)
        public ClientesAtendidosDALImpl()
        {
            context = new PROYECTO_PAWContext();
        }
        public ClientesAtendidosDALImpl(PROYECTO_PAWContext proyectoPAWContext)
        {
            this.context = proyectoPAWContext;
        }

        public bool Add(ClientesAtendido entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<ClientesAtendido> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientesAtendido> Find(Expression<Func<ClientesAtendido, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ClientesAtendido Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientesAtendido> GetAll()
        {
            try
            {
                IEnumerable<ClientesAtendido> clientesatendidos;
                using (UnidadDeTrabajo<ClientesAtendido> unidad = new UnidadDeTrabajo<ClientesAtendido>(context))
                {
                    clientesatendidos = unidad.genericDAL.GetAll();
                }
                return clientesatendidos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(ClientesAtendido entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ClientesAtendido> entities)
        {
            throw new NotImplementedException();
        }

        public ClientesAtendido SingleOrDefault(Expression<Func<ClientesAtendido, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(ClientesAtendido entity)
        {
            throw new NotImplementedException();
        }
    }

  
    }     

