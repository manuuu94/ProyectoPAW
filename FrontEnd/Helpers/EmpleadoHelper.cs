using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class EmpleadoHelper
    {

        public List<EmpleadoViewModel> GetEmpleados()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Empleado/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<EmpleadoViewModel> empleados =
                JsonConvert.DeserializeObject<List<EmpleadoViewModel>>(content);
            return empleados;

        }

    }
}
