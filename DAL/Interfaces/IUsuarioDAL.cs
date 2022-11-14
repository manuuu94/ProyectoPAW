using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsuarioDAL : IDALGenerico<Usuario>
    {
        List<Usuario> ValidarUsuario(Usuario usuario);

        bool CambiaContraseña(Usuario usuario);

        bool forgotPassword(Usuario2 usuario);

        Usuario2 ValidarUsuario2(Usuario2 usuario);

    }
}
