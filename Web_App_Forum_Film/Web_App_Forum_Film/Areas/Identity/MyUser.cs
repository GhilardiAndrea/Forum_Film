using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_App_Forum_Film.Areas.Identity
{
    public class MyUser : IdentityUser
    {
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public DateTime Data_Nascita { get; set; }

        public string Nazione { get; set; }
    }
}
