using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IResgistrosCompraDAL : IDALGenerico<RegistroCompra>
    {
        public string AgregarRegistro(RegistroCompra registroCompra);

        bool validarCarrito();

        public void vaciarCarrito();

    }
}
