using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioDAL usuarioDAL;
        //constructor
        public UsuarioController()
        {
            usuarioDAL = new UsuarioDALImpl(new Entities.PROYECTO_PAWContext());
        }

        #region Consultar
        [Route("ValidarUsuario")]
        [HttpPost]
        public JsonResult Post([FromBody] Usuario usuario)
        {
            IEnumerable<Usuario> result;
            result = usuarioDAL.ValidarUsuario(usuario);
            return new JsonResult(result);
        }
        #endregion



    }
}
