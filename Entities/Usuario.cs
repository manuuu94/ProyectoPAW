using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

        [Keyless]
        public class Usuario
        {
        //[NotMapped]
        public int? Id_Empleado { get; set; } 
        public string Username { get; set; } = null!;

        [NotMapped]
        public string? Password { get; set; }/* = null!;*/
        }

        [Keyless]
        public class Usuario2
        {
        //[NotMapped]
        public int? Id_Empleado { get; set; }
        public string Username { get; set; } = null!;

        [NotMapped]
        public string? Password { get; set; }/* = null!;*/

        public string? Correo { get; set; }

        }


}
