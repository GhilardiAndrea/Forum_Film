using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_App_Forum_Film.Areas.Identity;

namespace Web_App_Forum_Film.Services.Classi
{
    public class ForumPost
    {
        [Required]
        public MyUser User_Creatore { get; set; }

        [Required]
        public Topic Topic { get; set; }

        [Required]
        public List<Messaggio_Class> Messaggi { get; set; }

    }
}
