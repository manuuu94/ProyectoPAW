using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodosPagoController : ControllerBase
    {

        private IMetodosPagoDAL metodopagoDAL;
        //constructor
        public MetodosPagoController()
        {
            metodopagoDAL = new MetodosPagoDALImpl(new Entities.PROYECTO_PAWContext());
        }

        #region Consultar
        [HttpGet]
        public JsonResult Get()
        {
            List<MetodosPago> metodopago;
            metodopago = metodopagoDAL.Get();
            return new JsonResult(metodopago);
        }
        #endregion

    }
}
