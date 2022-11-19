using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class EmpleadoNuevoController : Controller
    {


        public IActionResult Index()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/Empleado");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<EmpleadoNuevoViewModel> empleado = JsonConvert.DeserializeObject<List<EmpleadoNuevoViewModel>>(content); //lista

                return View(empleado);
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
        public ActionResult Create(EmpleadoNuevoViewModel empleadoNuevo)
        {
            try
            {



                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Empleado", empleadoNuevo);
                response.EnsureSuccessStatusCode();
                EmpleadoNuevoViewModel EmpleadoNuevoViewModel = response.Content.ReadAsAsync<EmpleadoNuevoViewModel>().Result;
                return RedirectToAction("Index","Empleado");
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
            HttpResponseMessage response = serviceObj.GetResponse("api/Empleado/" + id.ToString());
            response.EnsureSuccessStatusCode();
            EmpleadoNuevoViewModel EmpleadoNuevoViewModel = response.Content.ReadAsAsync<EmpleadoNuevoViewModel>().Result;

            return View(EmpleadoNuevoViewModel);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        public ActionResult Edit(EmpleadoNuevoViewModel empleados)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Empleado", empleados);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index","Empleado",new { id = empleados.IdEmpleado });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Empleado/" + id.ToString());
            response.EnsureSuccessStatusCode();
            EmpleadoNuevoViewModel EmpleadoNuevoViewModel = response.Content.ReadAsAsync<EmpleadoNuevoViewModel>().Result;
            //ViewBag.Title = "All Empleados";
            return View(EmpleadoNuevoViewModel);
        }


        [HttpPost]
        public ActionResult Delete(EmpleadoNuevoViewModel empleados)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/empleado/" + empleados.IdEmpleado.ToString());
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
        public ActionResult Details()
        {
            int sessionUser = (int)HttpContext.Session.GetInt32("SessionUser");

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/empleado/" + sessionUser.ToString());
            response.EnsureSuccessStatusCode();
            Models.EmpleadoNuevoViewModel EmpleadoNuevoViewModel = response.Content.ReadAsAsync<Models.EmpleadoNuevoViewModel>().Result;
            //ViewBag.Title = "All Empleados";
            return View(EmpleadoNuevoViewModel);
        }

    }
}
