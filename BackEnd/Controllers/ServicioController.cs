using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ServicioController : Controller
    {

        //instancia la interfaz de la entidad
        private IServicioDAL ServicioDAL;
        //constructor
        public ServicioController()
        {
            ServicioDAL = new ServicioDALImpl(new Entities.PROYECTO_PAWContext());
        }

        #region Consultar
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Servicio> servicios;
            servicios = ServicioDAL.GetAll();

            return new JsonResult(servicios);
        }


        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Servicio Servicio;
            Servicio = ServicioDAL.Get(id);
            return new JsonResult(Servicio);
        }
    }
}
#endregion
