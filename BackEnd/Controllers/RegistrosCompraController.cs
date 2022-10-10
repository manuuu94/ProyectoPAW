using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosCompraController : ControllerBase
    {
        RegistrosCompraDALImpl modelo = new RegistrosCompraDALImpl();

        private IResgistrosCompraDAL resgistrosCompraDAL;
        //constructor
        public RegistrosCompraController()
        {
            resgistrosCompraDAL = new RegistrosCompraDALImpl(new Entities.PROYECTO_PAWContext());
        }


        [HttpPost]
        public string ConfirmaCompra(RegistroCompra registros)
        {
            try
            {
                return modelo.AgregarRegistro(registros);
            }
            catch (Exception)
            {
                return "Ingrese cédula del cliente y su ID de empleado";
            }
        }

        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<RegistroCompra> registrocompras;
            registrocompras = resgistrosCompraDAL.GetAll();

            return new JsonResult(registrocompras);
        }



    }
}
