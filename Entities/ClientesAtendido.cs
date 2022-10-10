using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ClientesAtendido
    {
        public int IdCliente { get; set; }
        public string CedulaCliente { get; set; } = null!;
        public string? NombreCliente { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCompra { get; set; }

        public virtual RegistroCompra? IdCompraNavigation { get; set; } /*= null!;*/
    }
}
