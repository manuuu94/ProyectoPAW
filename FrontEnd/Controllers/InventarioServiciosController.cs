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

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventarioServiciosViewModel inventario)
        {
            try
            {



                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/InventarioServicios", inventario);
                response.EnsureSuccessStatusCode();
                InventarioServiciosViewModel InventarioServiciosViewModel = response.Content.ReadAsAsync<InventarioServiciosViewModel>().Result;
                return RedirectToAction("Index");
            }
            catch (HttpRequestException
          )
            {
                return RedirectToAction("Error", "Home");
            }

            catch (Exception
            )
            {

                throw;
            }
        }

    }
}
