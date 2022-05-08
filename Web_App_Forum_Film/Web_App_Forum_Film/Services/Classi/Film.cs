using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Forum_Film.Services.Class
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titolo_Originale { get; set; }

        public int Budget { get; set; }

        public string Genere { get; set; }

        public string Lingua_Originale { get; set; }

        public string OverView { get; set; }

        public string Poster_Path { get; set; }

        // da completare
    }
}
