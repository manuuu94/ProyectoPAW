using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class MetodoPagoHelper
    {

        public List<MetodoPagoViewModel> GetMetodos()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/MetodosPago/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<MetodoPagoViewModel> metodospago =
                JsonConvert.DeserializeObject<List<MetodoPagoViewModel>>(content);
            return metodospago;

        }

    }
}
