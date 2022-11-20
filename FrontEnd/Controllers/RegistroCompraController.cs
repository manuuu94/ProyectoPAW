using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class RegistroCompraController : Controller
    {

        private List<EmpleadoViewModel> GetEmpleados()
        { 
        EmpleadoHelper empleadohelper = new EmpleadoHelper();
            List<EmpleadoViewModel> empleados = empleadohelper.GetEmpleados();

            return empleados;

        }

        public IActionResult Index()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/RegistrosCompra");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<RegistroCompraViewModel> registroCompras = JsonConvert.DeserializeObject<List<RegistroCompraViewModel>>(content); //lista

                return View(registroCompras);
            }
            catch (Exception)
            {
                throw;
            }
        }


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
                registroCompraViewModel.TotalCompraStr = total.ToString();
                //registroCompraViewModel.TotalCompra = total;
                registroCompraViewModel.Empleados = this.GetEmpleados();

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
                    registrocompra.TotalCompra = Decimal.Parse(registrocompra.TotalCompraStr);
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

