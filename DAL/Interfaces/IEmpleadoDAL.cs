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
        bool AñadeEmpleado(Empleado empleado);
        List<Empleado> Get();
    }
}
