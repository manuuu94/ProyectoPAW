using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class LoginViewModel
    {
        public int? Id_Empleado { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }

    public class Login2ViewModel
    {
        //[NotMapped]
        public int? Id_Empleado { get; set; }
        [Required]
        public string Username { get; set; } = null!;

        public string? Password { get; set; }/* = null!;*/

        public string? Correo { get; set; }

    }



}
