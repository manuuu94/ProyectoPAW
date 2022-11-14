using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioDAL usuarioDAL;
        //constructor
        public UsuarioController()
        {
            usuarioDAL = new UsuarioDALImpl(new Entities.PROYECTO_PAWContext());
        }

        #region Consultar
        [Route("ValidarUsuario")]
        [HttpPost]
        public JsonResult Post([FromBody] Usuario usuario)
        {
            IEnumerable<Usuario> result;
            result = usuarioDAL.ValidarUsuario(usuario);

            return new JsonResult(result);

        }
        #endregion

        [Route("cambiaContraseña")]
        [HttpPost]
        public bool cambiaContraseña([FromBody] Usuario usuario)
        {
            try
            {
                usuarioDAL.CambiaContraseña(usuario);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("forgotPass")]
        [HttpPost]
        public bool forgotPass([FromBody] Usuario2 usuario)
        {
            try
            {
                usuarioDAL.forgotPassword(usuario);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("validarUsuario2")]
        public bool validarUsuario2(Usuario2 usuario)
        {
            try
            {
                //return usuarioDAL.ValidarUsuario2(usuario);

                if (usuarioDAL.ValidarUsuario2(usuario) != null)
                {
                    string correo = usuarioDAL.ValidarUsuario2(usuario).Correo;
                    var email = new MimeMessage();
                    //email.From.Add(MailboxAddress.Parse("fidelitasproyectoPA@hotmail.com"));
                    email.From.Add(MailboxAddress.Parse("maymie.schneider@ethereal.email"));
                    email.To.Add(MailboxAddress.Parse(correo));
                    email.Subject = "Contraseña Nueva";
                    UsuarioDALImpl contraseña = new UsuarioDALImpl();
                    string contraseñaNueva = contraseña.CreatePassword();
                    email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = /*body*/ "Su nueva contraseña es " + contraseñaNueva };

                    usuario.Password = contraseñaNueva;
                    usuarioDAL.forgotPassword(usuario);

                    using var smtp = new SmtpClient();
                    //smtp.gmail live office365 ethereal etc .email"
                    smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    //smtp.Authenticate("fidelitasproyectoPA@hotmail.com", "123fidelitas456");
                    smtp.Authenticate("maymie.schneider@ethereal.email", "Z9Pye8E7QQtrKNXQMw");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("SendEmail")]
        public IActionResult SendEmail(/*string body*/)
        {
            //https://ethereal.email/create (inbound outbound test recipient)
            //https://ethereal.email/messages/6372aa48e752b86afcf99053/6 (created account)

            var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("fidelitasproyectoPA@hotmail.com"));
            email.From.Add(MailboxAddress.Parse("maymie.schneider@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("manu_4_94@hotmail.com"));
            email.Subject = "Contraseña Nueva";
            UsuarioDALImpl contraseña = new UsuarioDALImpl();
            string contraseñaNueva = contraseña.CreatePassword();
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = /*body*/ "Su nueva contraseña es "+ contraseñaNueva };

            using var smtp = new SmtpClient();
            //smtp.gmail live office365 ethereal etc .email"
            smtp.Connect("smtp.ethereal.email",587,MailKit.Security.SecureSocketOptions.StartTls);
            //smtp.Authenticate("fidelitasproyectoPA@hotmail.com", "123fidelitas456");
            smtp.Authenticate("maymie.schneider@ethereal.email", "Z9Pye8E7QQtrKNXQMw");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }

    }
}
