using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmpleadoDAL : IDALGenerico<Empleado>
    {
        bool AñadeEmpleado(EmpleadoNuevo empleado);
        List<Empleado> Get();

        //List<Empleado> GetUser(string user);

        //Usuario ValidarUsuario(Usuario usuario);
    }
}
