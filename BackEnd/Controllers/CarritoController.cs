using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {

        //instancia la interfaz de la entidad
        private ICarritoDAL carritoDAL;
        //constructor
        public CarritoController()
        {
            carritoDAL = new CarritoDALImpl(new Entities.PROYECTO_PAWContext());
        }

        // GET: api/<CarritoController>
        [HttpGet]
        public JsonResult Get()
        {

            IEnumerable<Carrito> carrito;
            carrito = carritoDAL.GetAll();

            return new JsonResult(carrito);
        }

        // GET api/<CarritoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }






        // POST api/<CarritoController>
        #region Agregar
        [HttpPost]
        public JsonResult Post([FromBody] Carrito carrito)
        {
            try
            {
                carritoDAL.Add(carrito);
                return new JsonResult(carrito);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion



        // PUT api/<CarritoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        #region Eliminar
        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Carrito carrito = new Carrito { IdProd = id };
                carritoDAL.Remove(carrito);
                return new JsonResult(carrito);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region EliminarTodos
        // DELETE api/<CarritoController>
        [HttpDelete]
        public bool DeleteAll(int id)
        {
            try
            {
                carritoDAL.RemoveAll();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
