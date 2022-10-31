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

        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/InventarioServicios/" + id.ToString());
            response.EnsureSuccessStatusCode();
            InventarioServiciosViewModel InventarioServiciosViewModel = response.Content.ReadAsAsync<InventarioServiciosViewModel>().Result;
     
            return View(InventarioServiciosViewModel);
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


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/InventarioServicios/" + id.ToString());
            response.EnsureSuccessStatusCode();
            InventarioServiciosViewModel InventarioServiciosViewModel = response.Content.ReadAsAsync<InventarioServiciosViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(InventarioServiciosViewModel);
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


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/inventarioServicios/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.InventarioServiciosViewModel InventarioServiciosViewModel = response.Content.ReadAsAsync<Models.InventarioServiciosViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(InventarioServiciosViewModel);
        }


    }


}
