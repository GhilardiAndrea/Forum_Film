using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_App_Forum_Film.Areas.Identity;

namespace Web_App_Forum_Film.Services.Classi
{
    public class Messaggio_Class
    {
        [Required]
        public MyUser User { get; set; }

        [Required, MaxLength(500,ErrorMessage = "Il messaggio deve essere lungo al massimo 500")]
        public string Messaggio { get; set; }

        [Required]
        public DateTime Data_Creazione { get; set; }
    }
}
