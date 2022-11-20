using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/Carrito");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<CarritoViewModel> carrito = JsonConvert.DeserializeObject<List<CarritoViewModel>>(content); //lista

                return View(carrito);
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
        public ActionResult Create(CarritoViewModel producto)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Carrito", producto);
                response.EnsureSuccessStatusCode();
                CarritoViewModel CarritoViewModel = response.Content.ReadAsAsync<CarritoViewModel>().Result;
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

        public ActionResult VaciarCarrito()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Carrito/");
                response.EnsureSuccessStatusCode();
                bool Eliminado = response.Content.ReadAsAsync<bool>().Result;

                if (Eliminado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        //public ActionResult EliminarProductoCarrito(CarritoViewModel carro)
        //{
        //    ServiceRepository serviceObj = new ServiceRepository();
        //    HttpResponseMessage response = serviceObj.DeleteResponse("api/Carrito/" + carro.IdProd.ToString());
        //    response.EnsureSuccessStatusCode();
        //    bool Eliminado = response.Content.ReadAsAsync<bool>().Result;

        //    if (Eliminado)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        throw new Exception();
        //    }

            public ActionResult EliminarProductoCarrito(int IdProd)
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Carrito/" + IdProd);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");

            }

    }
}