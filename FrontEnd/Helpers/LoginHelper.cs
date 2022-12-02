using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc.Filters;

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

    //public class SessionTimeoutAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        HttpContext ctx = HttpContext.Curent;
    //        if (HttpContext.Current.Session["ID"] == null)
    //        {
    //            filterContext.Result = new RedirectResult("~/Home/Login");
    //            return;
    //        }
    //        base.OnActionExecuting(filterContext);
    //    }
    //}
}

