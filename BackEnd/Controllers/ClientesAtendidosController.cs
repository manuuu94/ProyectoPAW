using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesAtendidosController : ControllerBase
    {

        private IClientesAtendidosDAL clientesatendidosDAL;
        //constructor
        public ClientesAtendidosController()
        {
            clientesatendidosDAL = new ClientesAtendidosDALImpl(new Entities.PROYECTO_PAWContext());
        }

        #region Consultar
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<ClientesAtendido> clientesatendidos;
            clientesatendidos = clientesatendidosDAL.GetAll();

            return new JsonResult(clientesatendidos);
        }
        #endregion

    }
}
