using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pandami2.Models
{
    public class Login
    {
        [Required(ErrorMessage = "champ obligatoire")]
        public string username { get; set; }

        [Required(ErrorMessage = "champ obligatoire")]
        public string passeword { get; set; }
    }
}

