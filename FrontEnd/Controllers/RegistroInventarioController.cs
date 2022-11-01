using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class RegistroInventarioController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/RegistrosInventario");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<RegistroInventarioViewModel> registroinventario = JsonConvert.DeserializeObject<List<RegistroInventarioViewModel>>(content); //lista

                return View(registroinventario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
