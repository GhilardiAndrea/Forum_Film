using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Forum_Film.Services.Class.Dtos
{
    public class RequestGetFilms
    {
        [Required]
        public List<Film> ListaFilm { get; set; }
    }
    public class RequestPost
    {
        [Required]
        public string EmailUser { get; set; }

        [Required]
        public int IdTopic { get; set; }

        [Required]
        public string Message { get; set; }
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

    public class RequestMessaggio
    {
        [Required]
        public string Messaggio { get; set; }

        [Required]
        public int IdPost { get; set; }

        [Required]
        public string EmailUser { get; set; }
    }


    public class RequestPutMessaggio
    {
        [Required]
        public string Messaggio { get; set; }

        [Required]
        public int IdMessaggio { get; set; }

    }
    public class RequestPutTopic
    {
        [Required]
        public string Titolo { get; set; }

        [Required]
        public int IdTopic { get; set; }

    }

    public class RequestPostUser
    {
        [Required]
        public MyUser User { get; set; }
    }
    public class RequestPutUser
    {
        [Required]
        public MyUser User { get; set; }

    }

}
