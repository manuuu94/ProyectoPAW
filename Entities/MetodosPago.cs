using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class MetodosPago
    {
        public MetodosPago()
        {
            RegistroCompras = new HashSet<RegistroCompra>();
        }

        public int IdMetodo { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<RegistroCompra> RegistroCompras { get; set; }
    }
}
