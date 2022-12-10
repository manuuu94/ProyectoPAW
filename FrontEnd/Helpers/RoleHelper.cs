using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class RoleHelper
    {
        public List<RoleViewModel> GetAll()
        {
            ServiceRepository Repository = new ServiceRepository();
            HttpResponseMessage responseMessage = Repository.GetResponse("api/Role");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<RoleViewModel> roles =
                JsonConvert.DeserializeObject<List<RoleViewModel>>(content);

            return roles;

        }

        public RoleViewModel GetRole(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Role/" + id.ToString());
            response.EnsureSuccessStatusCode();
            RoleViewModel RoleViewModel = response.Content.ReadAsAsync<RoleViewModel>().Result;

            return RoleViewModel;

        }
    }
}
