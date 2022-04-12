using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_App_Forum_Film.Services.Classi
{
    public class Topic
    {
        [Required]
        public string Titolo { get; set; }

        [Required]
        public Film Film { get; set; }
    }
}
