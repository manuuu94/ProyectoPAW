using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class Carrito
    {
        public int IdProd { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal? Total { get; set; }
        public int? IdProducto { get; set; }
        [NotMapped]
        public int Id { get; set; }


        public virtual InventarioServicio? IdProductoNavigation { get; set; } /*= null!;*/
    }
}
