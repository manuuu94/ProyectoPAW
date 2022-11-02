using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class EmpleadoNuevoController : Controller
    {
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
    }
    }
