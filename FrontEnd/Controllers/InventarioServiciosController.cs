using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class InventarioServiciosController : Controller
    {


      
        private List<ServicioViewModel> GetServicio()
        {
            ServicioHelper ServicioHelper = new ServicioHelper();
            List<ServicioViewModel> servicio = ServicioHelper.GetAll();


            return servicio;


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCarrito(InventarioServiciosViewModel producto)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Carrito", producto);
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

        private ServicioViewModel GetServicio(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/servicio/" + id.ToString());
                response.EnsureSuccessStatusCode();
                ServicioViewModel ServicioViewModel =
                    response.Content.ReadAsAsync<ServicioViewModel>().Result;
                //ViewBag.Title = "All Products";

                return ServicioViewModel;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public IActionResult Index()
        {
            try
            {
                if ((int)HttpContext.Session.GetInt32("SessionUser") != null)
                {
                    ServiceRepository Repository = new ServiceRepository();
                    HttpResponseMessage responseMessage = Repository.GetResponse("api/InventarioServicios");
                    responseMessage.EnsureSuccessStatusCode();
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    List<InventarioServiciosViewModel> inventario = JsonConvert.DeserializeObject<List<InventarioServiciosViewModel>>(content); //lista

                    List<InventarioServiciosViewModel> resultado = new List<InventarioServiciosViewModel>();

                    InventarioServiciosViewModel prueba = new InventarioServiciosViewModel();     
                    foreach (InventarioServiciosViewModel item in inventario)
                    {

                        item.Servicio = this.GetServicio(item.IdServicio);
                       
                        resultado.Add(item);

                        prueba.Servicios = this.GetServicio();
                    }


                    return View(inventario);
                }
                return RedirectToAction("Index", "Login");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Create()
        {
            try
            {
                if ((int)HttpContext.Session.GetInt32("SessionUser") != null)
                {

                    InventarioServiciosViewModel InventarioServiciosViewModel = new InventarioServiciosViewModel();

                    //registroCompraViewModel.TotalCompra = total;
                    InventarioServiciosViewModel.Servicios = this.GetServicio();

                    return View(InventarioServiciosViewModel);
                
            }

                return View();
            }

            catch (Exception)
            {
                return RedirectToAction("Index", "Login");

            }
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

        public ActionResult Edit(int id)
        {
            try
            {
                if ((int)HttpContext.Session.GetInt32("SessionUser") != null)
                {
                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.GetResponse("api/InventarioServicios/" + id.ToString());
                    response.EnsureSuccessStatusCode();
                    InventarioServiciosViewModel InventarioServiciosViewModel = response.Content.ReadAsAsync<InventarioServiciosViewModel>().Result;

                    return View(InventarioServiciosViewModel);
                }
                return RedirectToAction("Index", "Login");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: InventarioServiciosController/Edit/5
        [HttpPost]
        public ActionResult Edit(InventarioServiciosViewModel inventarioServicios)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/InventarioServicios", inventarioServicios);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Details", new { id = inventarioServicios.IdProducto });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                if ((int)HttpContext.Session.GetInt32("SessionUser") != null)
                {
                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.GetResponse("api/InventarioServicios/" + id.ToString());
                    response.EnsureSuccessStatusCode();
                    InventarioServiciosViewModel InventarioServiciosViewModel = response.Content.ReadAsAsync<InventarioServiciosViewModel>().Result;
                    //ViewBag.Title = "All Products";
                    return View(InventarioServiciosViewModel);
                }
                return RedirectToAction("Index", "Login");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
        }


        [HttpPost]
        public ActionResult Delete(InventarioServiciosViewModel inventarioServicios)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/inventarioServicios/" + inventarioServicios.IdProducto.ToString());
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

        public ActionResult Details(int id)
        {
            try
            {
                if ((int)HttpContext.Session.GetInt32("SessionUser") != null)
                {
                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.GetResponse("api/inventarioServicios/" + id.ToString());
                    response.EnsureSuccessStatusCode();
                    Models.InventarioServiciosViewModel InventarioServiciosViewModel = response.Content.ReadAsAsync<Models.InventarioServiciosViewModel>().Result;
                    //ViewBag.Title = "All Products";
                    return View(InventarioServiciosViewModel);
                }
                return RedirectToAction("Index", "Login");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
        }


    }
}
