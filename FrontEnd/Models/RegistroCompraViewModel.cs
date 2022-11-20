using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEnd.Models
{
    public class RegistroCompraViewModel
    {
        public int IdCompra { get; set; }
        public string CedulaCliente { get; set; } = null!;
        public string? NombreCliente { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? TotalCompra { get; set; }
        public int? IdMetodo { get; set; }
        public int IdEmpleado { get; set; }
        public string? NombreEmpleado { get; set; }
        
        [NotMapped]
        public string? TotalCompraStr { get; set; }

        public MetodoPagoViewModel MetodoPago { get; set; }
        //public string Descripcion { get; set; } 
        public List<MetodoPagoViewModel> MetodosPago { get; set; }
        public EmpleadoViewModel Empleado { get; set; }
        //public string Nombre { get; set; }

        public List<EmpleadoViewModel> Empleados { get; set; }


    }
}
