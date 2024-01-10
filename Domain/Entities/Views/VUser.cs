using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class VUser
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
