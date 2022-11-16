using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class RegistroCompraController : Controller
    {

        public ActionResult ConfirmarCompra()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/Carrito");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<CarritoViewModel> carrito = JsonConvert.DeserializeObject<List<CarritoViewModel>>(content); //lista
                decimal total = 0;
                foreach (var item in carrito)
                {
                    total = total + item.Total;
                }
                RegistroCompraViewModel registroCompraViewModel = new RegistroCompraViewModel();
                registroCompraViewModel.TotalCompra = total;

                return View(registroCompraViewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
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
                    //RegistroCompraViewModel RegistroCompraViewModel = response.Content.ReadAsAsync<RegistroCompraViewModel>().Result;
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

