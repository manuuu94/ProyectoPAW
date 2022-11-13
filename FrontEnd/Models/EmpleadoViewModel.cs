namespace FrontEnd.Models;

public class EmpleadoViewModel
{




    public int IdEmpleado { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido1 { get; set; } = null!;
    public string Apellido2 { get; set; } = null!;
    public string Username { get; set; } = null!;
    public byte[]? Passhash { get; set; } = null!;
    public DateTime FechaIngreso { get; set; }
    public string Correo { get; set; } = null!;
    public int IdRol { get; set; }
}
