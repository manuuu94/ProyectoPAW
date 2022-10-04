using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private IEmpleadoDAL empleadoDAL;
        //constructor
        public EmpleadoController()
        {
            empleadoDAL = new EmpleadoDALImpl(new Entities.PROYECTO_PAWContext());
        }

        //#region Consultar
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    IEnumerable<Empleado> empleados;
        //    empleados = empleadoDAL.GetAll();

        //    return new JsonResult(empleados);
        //}
        //#endregion

        #region Consultar
        [HttpGet]
        public JsonResult Get()
        {
            List<Empleado> empleados;
            empleados = empleadoDAL.Get();
            return new JsonResult(empleados);
        }
        #endregion

        [HttpGet("{id}", Name = "Get2")]
        public JsonResult Get(int id)
        {
            Empleado empleado;
            empleado = empleadoDAL.Get(id);
            return new JsonResult(empleado);
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public EmpleadoNuevo Post([FromBody] EmpleadoNuevo empleado)
        {
            try
            {
                empleadoDAL.AñadeEmpleado(empleado);
                return empleado;
            }
            catch(Exception)
            {
                throw;
            }
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        #region Eliminar
        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Empleado empleado = new Empleado { IdEmpleado = id };
                empleadoDAL.Remove(empleado);
                return new JsonResult(empleado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    #endregion


    }
}
