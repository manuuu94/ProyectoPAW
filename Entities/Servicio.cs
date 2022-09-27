using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Servicio
    {
        public Servicio()
        {
            Empleados = new HashSet<Empleado>();
            InventarioServicios = new HashSet<InventarioServicio>();
            RegistrosInventarios = new HashSet<RegistrosInventario>();
            Roles = new HashSet<Role>();
        }

        public int IdServicio { get; set; }
        public string NombreServicio { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<InventarioServicio> InventarioServicios { get; set; }
        public virtual ICollection<RegistrosInventario> RegistrosInventarios { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
