using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class RegistroCompra
    {
        public RegistroCompra()
        {
            ClientesAtendidos = new HashSet<ClientesAtendido>();
        }

        public int IdCompra { get; set; }
        public string CedulaCliente { get; set; } = null!;
        public string? NombreCliente { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? TotalCompra { get; set; }
        public int? IdMetodo { get; set; }
        public int IdEmpleado { get; set; }
        public string? NombreEmpleado { get; set; }

        public virtual Empleado? IdEmpleadoNavigation { get; set; } // = null!;
        public virtual MetodosPago? IdMetodoNavigation { get; set; }
        public virtual ICollection<ClientesAtendido> ClientesAtendidos { get; set; }
    }
}
