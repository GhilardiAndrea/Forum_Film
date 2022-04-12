using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_App_Forum_Film.Areas.Identity
{
    public class MyUser : IdentityUser
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public DateTime Data_Nascita { get; set; }
        [Required]
        public string Nazione { get; set; }
    }
}
