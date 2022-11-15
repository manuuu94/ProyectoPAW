using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class RegistroCompraController : Controller
    {

        public IActionResult Index()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/RegistrosCompra");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<RegistroCompraViewModel> registrocompra = JsonConvert.DeserializeObject<List<RegistroCompraViewModel>>(content); //lista

                return View(registrocompra);
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
            public ActionResult Create(RegistroCompraViewModel registrocompra)
            {
                try
                {

                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.PostResponse("api/RegistrosCompra", registrocompra);
                    response.EnsureSuccessStatusCode();
                    RegistroCompraViewModel RegistroCompraViewModel = response.Content.ReadAsAsync<RegistroCompraViewModel>().Result;
                    return RedirectToAction("Index" , "Carrito");
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

