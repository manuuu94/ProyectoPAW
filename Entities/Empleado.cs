using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Empleado
    {
        public Empleado()
        {
            RegistroCompras = new HashSet<RegistroCompra>();
        }

        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public string Username { get; set; } = null!;
        public byte[]? Passhash { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public string Correo { get; set; } = null!;
        public int IdRol { get; set; }

        public virtual Servicio? IdRolNavigation { get; set; } /*= null!;*/
        public virtual ICollection<RegistroCompra> RegistroCompras { get; set; }

        //public string? Password { get; set; } = null!;

    }

    [Keyless]
    public class EmpleadoNuevo
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public int IdRol { get; set; }
    }

}


