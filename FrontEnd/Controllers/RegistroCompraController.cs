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

        private EmpleadoViewModel GetEmpleado(int id)
        {
            EmpleadoHelper empleadohelper = new EmpleadoHelper();
            EmpleadoViewModel empleado = empleadohelper.GetEmpleado(id);

            return empleado;
        }

        private List<MetodoPagoViewModel> GetMetodos()
        {
            MetodoPagoHelper metodoPagoHelper = new MetodoPagoHelper();
            List<MetodoPagoViewModel> metodospago = metodoPagoHelper.GetMetodos();

            return metodospago;
        }

        private MetodoPagoViewModel GetMetodo(int id)
        {
            MetodoPagoHelper metodoPagoHelper = new MetodoPagoHelper();
            MetodoPagoViewModel metodopago = metodoPagoHelper.GetMetodo(id);

            return metodopago;
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

                List<RegistroCompraViewModel>resultado = new List<RegistroCompraViewModel>();

                foreach (RegistroCompraViewModel item in registroCompras)
                {
                    item.Empleado = this.GetEmpleado(item.IdEmpleado);
                    item.MetodoPago = this.GetMetodo(item.IdMetodo);
                    resultado.Add(item);    
                }

                return View(resultado);
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
                registroCompraViewModel.MetodosPago = this.GetMetodos();

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

