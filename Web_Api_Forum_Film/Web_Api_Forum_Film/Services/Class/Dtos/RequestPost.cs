using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Forum_Film.Services.Class.Dtos
{
    public class RequestPost
    {
        [Required]
        public int IdUser { get; set; }

        [Required]
        public int IdTopic { get; set; }

        [Required]
        public string FirstMessage { get; set; }
    }

    public class RequestTopic
    {
        [Required]
        public int IdFilm { get; set; }

        [Required]
        public string Titolo { get; set; }

    }

    public class RequestFilm
    {
        [Required]
        public string Titolo { get; set; }
    }
}
