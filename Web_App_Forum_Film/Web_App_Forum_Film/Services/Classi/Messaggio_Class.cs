using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Forum_Film.Services;

namespace Web_Api_Forum_Film.Services.Class
{
    public class Messaggio_Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public MyUser User { get; set; }

        [Required, MaxLength(500,ErrorMessage = "Il messaggio deve essere lungo al massimo 500")]
        public string Messaggio { get; set; }

        [Required]
        public DateTime Data_Creazione { get; set; }

        [Required]
        public ForumPost Id_Post;
    }
}
