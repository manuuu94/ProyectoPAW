namespace FrontEnd.Models
{
    public class EmpleadoNuevoViewModel
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public int IdRol { get; set; }

        public RoleViewModel Role { get; set; }

        public List<RoleViewModel> Roles { get; set; }

    }
}
