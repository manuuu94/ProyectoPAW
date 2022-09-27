using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class InventarioServicio
    {
        public InventarioServicio()
        {
            Carritos = new HashSet<Carrito>();
        }

        public int IdProducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public int CantidadDisponible { get; set; }
        public string? UrlImage { get; set; }
        public int IdServicio { get; set; }

        public virtual Servicio IdServicioNavigation { get; set; } = null!;
        public virtual ICollection<Carrito> Carritos { get; set; }
    }
}
