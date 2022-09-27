using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Carrito
    {
        public int IdProd { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public int IdProducto { get; set; }

        public virtual InventarioServicio IdProductoNavigation { get; set; } = null!;
    }
}
