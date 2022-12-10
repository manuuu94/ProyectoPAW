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
    public class RoleDalImpl : IRoleDAL
    {

        PROYECTO_PAWContext context;

        //constructor vacio (sin argumento o parametro)
        public RoleDalImpl()
        {
            context = new PROYECTO_PAWContext();
        }
        public RoleDalImpl(PROYECTO_PAWContext proyectoPAWContext)
        {
            this.context = proyectoPAWContext;
        }

        public bool Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Role> entities)
        {
            throw new NotImplementedException();
        }





        public IEnumerable<Role> Find(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Role Get(int IdRol)
        {
            try
            {
                //variable tipo category
                Role Role;
                //using la unidaddetrabajo con entity tipo Category y context
                using (UnidadDeTrabajo<Role> unidad = new UnidadDeTrabajo<Role>(context))
                {
                    //instancia el metodo de IDAL get a partir de unidaddetrabajo
                    Role = unidad.genericDAL.Get(IdRol);
                }
                return Role;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Role> GetAll()
        {
            try
            {
                IEnumerable<Role> Role;
                using (UnidadDeTrabajo<Role> unidad = new UnidadDeTrabajo<Role>(context))
                {
                    Role = unidad.genericDAL.GetAll();
                }
                return Role;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Role entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Role> entities)
        {
            throw new NotImplementedException();
        }

        public Servicio SingleOrDefault(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }



        public bool Update(Role entity)
        {
            throw new NotImplementedException();
        }

        Role IDALGenerico<Role>.SingleOrDefault(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
