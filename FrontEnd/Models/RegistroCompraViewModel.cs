using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class RegistroCompraViewModel
    {
        [Display(Name = "Id Compra")]
        public int IdCompra { get; set; }

        [Display(Name = "Cedula cliente")]
        public string CedulaCliente { get; set; } = null!;

        [Display(Name = "Nombre cliente")]
        public string? NombreCliente { get; set; }

        [Display(Name = "Correo")]
        public string? Correo { get; set; }

        [Display(Name = "Telefono")]
        public string? Telefono { get; set; }

        [Display(Name = "Fecha")]
        public DateTime? Fecha { get; set; }

        [Display(Name = "Total de compra")]
        public decimal? TotalCompra { get; set; }

        [Display(Name = "Metodo de pago")]
        public int IdMetodo { get; set; }

        [Display(Name = "Empleado")]
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
