using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class InventarioServiciosController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/InventarioServicios");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<InventarioServiciosViewModel> inventario = JsonConvert.DeserializeObject<List<InventarioServiciosViewModel>>(content); //lista

                return View(inventario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
