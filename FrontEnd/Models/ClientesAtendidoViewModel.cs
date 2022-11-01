namespace FrontEnd.Models
{
    public class ClientesAtendidoViewModel
    {
        public int IdCliente { get; set; }
        public string CedulaCliente { get; set; } = null!;
        public string? NombreCliente { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCompra { get; set; }
    }
}
