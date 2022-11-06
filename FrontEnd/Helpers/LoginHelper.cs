using FrontEnd.Models;

namespace FrontEnd.Helpers
{
    public class LoginHelper
    {

        public void changePass(LoginViewModel user)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("/api/Usuario/cambiaContraseña", user);
            response.EnsureSuccessStatusCode();
        }
    }
}
