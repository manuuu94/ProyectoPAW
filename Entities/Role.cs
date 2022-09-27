using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Role
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? IdServicio { get; set; }

        public virtual Servicio? IdServicioNavigation { get; set; }
    }
}
