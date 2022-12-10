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

        public ServicioViewModel GetServicio(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Servicio/" + id.ToString());
            response.EnsureSuccessStatusCode();
            ServicioViewModel ServicioViewModel = response.Content.ReadAsAsync<ServicioViewModel>().Result;

            return ServicioViewModel;

        }
    }
}
