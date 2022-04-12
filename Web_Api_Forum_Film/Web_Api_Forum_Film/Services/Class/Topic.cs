using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Forum_Film.Services.Class
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titolo { get; set; }

        [Required]
        public Film Film { get; set; }
    }
}
