using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioServiciosController : ControllerBase
    {

        //instancia la interfaz de la entidad
        private IInventario_ServiciosDAL inventarioDAL;
        //constructor
        public InventarioServiciosController()
        {
            inventarioDAL = new Inventario_ServiciosDALImpl(new Entities.PROYECTO_PAWContext());
        }

        #region Consultar
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<InventarioServicio> productos;
            productos = inventarioDAL.GetAll();

            return new JsonResult(productos);
        }

        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {
            InventarioServicio producto;
            producto = inventarioDAL.Get(id);
            return new JsonResult(producto);
        }
        #endregion

        #region Agregar
        [HttpPost]
        public JsonResult Post([FromBody] InventarioServicio producto)
        {
            try
            {
                inventarioDAL.Add(producto);
                return new JsonResult(producto);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Actualizar
        [HttpPut]
        public JsonResult Put([FromBody] InventarioServicio producto)
        {
            try
            {
                inventarioDAL.Update(producto);
                return new JsonResult(producto);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                InventarioServicio producto = new InventarioServicio { IdProducto = id };
                inventarioDAL.Remove(producto);
                return new JsonResult(producto);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}


// DB - DONE
//API:
//CRUD Inventario - DONE
//CRUD Empleados - DONE
//AñadeCarrito con funcionalidad al inventario - DONE
//VaciarCarrito 1x1 o Todo con funcionalidad al inventario - DONE
//SP AñadeEmpleado - DONE
//SP ValidaUsuario - InProgress

//RegistraCompra a partir del Carrito (Total), datos del cliente y met.pago- NOTYET
//Añade a ClientesAtendidos a partir del RegistroCompra (datos del cliente) - NOTYET
//GETAll RegistrosInventario - NOTYET
//GETAll ClientesAtendidos - NOTYET