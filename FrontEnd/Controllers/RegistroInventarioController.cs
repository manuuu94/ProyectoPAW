using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class RegistroInventarioController : Controller
    {

        private List<ServicioViewModel> GetServicio()
        {
            ServicioHelper ServicioHelper = new ServicioHelper();
            List<ServicioViewModel> servicio = ServicioHelper.GetAll();


            return servicio;


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
                    HttpResponseMessage responseMessage = Repository.GetResponse("api/RegistrosInventario");
                    responseMessage.EnsureSuccessStatusCode();
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    List<RegistroInventarioViewModel> inventario = JsonConvert.DeserializeObject<List<RegistroInventarioViewModel>>(content); //lista

                    List<RegistroInventarioViewModel> resultado = new List<RegistroInventarioViewModel>();

                    foreach (RegistroInventarioViewModel item in inventario)
                    {

                        item.Servicio = this.GetServicio(item.IdServicio);
                        resultado.Add(item);
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
    }
}