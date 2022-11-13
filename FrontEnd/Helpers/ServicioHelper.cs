using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ServicioHelper
    {

        public List<ServicioViewModel> GetAll()
        {
            ServiceRepository Repository = new ServiceRepository();
            HttpResponseMessage responseMessage = Repository.GetResponse("api/servicio");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<ServicioViewModel> servicios =
                JsonConvert.DeserializeObject<List<ServicioViewModel>>(content);

            return servicios;

        }
    }
}
