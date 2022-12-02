using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class EmpleadoController : Controller
    {
            public IActionResult Index()
            {
                try
                {
                if ((int)HttpContext.Session.GetInt32("SessionUser") != null)
                {
                    ServiceRepository Repository = new ServiceRepository();
                    HttpResponseMessage responseMessage = Repository.GetResponse("api/Empleado");
                    responseMessage.EnsureSuccessStatusCode();
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    List<EmpleadoViewModel> empleado = JsonConvert.DeserializeObject<List<EmpleadoViewModel>>(content); //lista

                    return View(empleado);
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

                    return View();
                }
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return RedirectToAction("Index", "Login");

            }
        }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(EmpleadoViewModel empleado)
            {
                try
                {

                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.PostResponse("api/Empleado", empleado);
                    response.EnsureSuccessStatusCode();
                    EmpleadoViewModel EmpleadoViewModel = response.Content.ReadAsAsync<EmpleadoViewModel>().Result;
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
                HttpResponseMessage response = serviceObj.GetResponse("api/Empleado/" + id.ToString());
                response.EnsureSuccessStatusCode();
                EmpleadoViewModel EmpleadoViewModel = response.Content.ReadAsAsync<EmpleadoViewModel>().Result;

                return View(EmpleadoViewModel);
                }
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return RedirectToAction("Index", "Login");

            }
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
            public ActionResult Edit(EmpleadoViewModel empleados)
            {


                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Empleado", empleados);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Details", new { id = empleados.IdEmpleado });
            }

            [HttpGet]
            public ActionResult Delete(int id)
            {
            try
            {
                if ((int)HttpContext.Session.GetInt32("SessionUser") != null)
                {
                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.GetResponse("api/empleado/" + id.ToString());
                    response.EnsureSuccessStatusCode();
                    EmpleadoViewModel EmpleadoViewModel = response.Content.ReadAsAsync<EmpleadoViewModel>().Result;
                    //ViewBag.Title = "All Empleados";
                    return View(EmpleadoViewModel);
                }
                    return RedirectToAction("Index", "Login");
                }
            catch
            {
                return RedirectToAction("Index", "Login");

            }
        }


        [HttpPost]
            public ActionResult Delete(EmpleadoViewModel empleados)
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
            try
            {
                if ((int)HttpContext.Session.GetInt32("SessionUser") != null)
                {
                    int sessionUser = (int)HttpContext.Session.GetInt32("SessionUser");

                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.GetResponse("api/empleado/" + sessionUser.ToString());
                    response.EnsureSuccessStatusCode();
                    Models.EmpleadoViewModel EmpleadoViewModel = response.Content.ReadAsAsync<Models.EmpleadoViewModel>().Result;
                    //ViewBag.Title = "All Empleados";
                    return View(EmpleadoViewModel);
                }
                return RedirectToAction("Index", "Login");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }

    }

}

