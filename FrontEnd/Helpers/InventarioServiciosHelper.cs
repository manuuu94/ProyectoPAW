using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class InventarioServiciosHelper
    {

        public List<InventarioServiciosViewModel> GetInventarioServicios()
        {
            ServiceRepository Repository = new ServiceRepository();
            HttpResponseMessage responseMessage = Repository.GetResponse("api/InventarioServicios");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<InventarioServiciosViewModel> invenatarioservicios =
                JsonConvert.DeserializeObject<List<InventarioServiciosViewModel>>(content);

            return invenatarioservicios;

        }

        public InventarioServiciosViewModel GetInventarioServicio(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/InventarioServicios/" + id.ToString());
            response.EnsureSuccessStatusCode();
            InventarioServiciosViewModel inventarioservicio = response.Content.ReadAsAsync<InventarioServiciosViewModel>().Result;

            return inventarioservicio;

        }
    }
}
