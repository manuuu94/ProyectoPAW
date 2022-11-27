using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class MetodosPagoController : Controller
    {
            public IActionResult Index()
            {
                try
                {
                    ServiceRepository Repository = new ServiceRepository();
                    HttpResponseMessage responseMessage = Repository.GetResponse("api/MetodosPago");
                    responseMessage.EnsureSuccessStatusCode();
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    List<MetodoPagoViewModel> metodopago = JsonConvert.DeserializeObject<List<MetodoPagoViewModel>>(content); //lista

                    return View(metodopago);
                }
                catch (Exception)
                {
                    throw;
                }
            }

    }

    }

