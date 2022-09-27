using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class RegistrosInventario
    {
        public int Id { get; set; }
        public string? Accion { get; set; }
        public string? Descripcion { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdServicio { get; set; }

        public virtual Servicio? IdServicioNavigation { get; set; }
    }
}
