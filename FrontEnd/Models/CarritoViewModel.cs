using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class CarritoViewModel
    {
        [Display(Name = "Id")]
        public int IdProd { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }
        [Display(Name = "Id Producto")]
        public int IdProducto { get; set; }

    }

}
