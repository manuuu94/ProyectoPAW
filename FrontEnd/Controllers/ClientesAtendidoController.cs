using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class ClientesAtendidoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/ClientesAtendidos");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<ClientesAtendidoViewModel> clientesatendidos = JsonConvert.DeserializeObject<List<ClientesAtendidoViewModel>>(content); //lista

                return View(clientesatendidos);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


