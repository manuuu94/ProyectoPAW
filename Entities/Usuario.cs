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
            public string Username { get; set; } = null!;

        [NotMapped]
        public string? Password { get; set; }/* = null!;*/
        }
  
}
