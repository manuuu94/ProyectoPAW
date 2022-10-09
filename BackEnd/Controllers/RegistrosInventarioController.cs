using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosInventarioController : ControllerBase
    {

        private IResgistrosInventarioDAL resgistrosInventarioDAL;
        //constructor
        public RegistrosInventarioController()
        {
            resgistrosInventarioDAL = new RegistrosInventarioDALImpl(new Entities.PROYECTO_PAWContext());
        }

        #region Consultar
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<RegistrosInventario> RegistrosInventarios;
            RegistrosInventarios = resgistrosInventarioDAL.GetAll();

            return new JsonResult(RegistrosInventarios);
        }
        #endregion

    }
}
