using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Forum_Film.Services;

namespace Web_Api_Forum_Film.Services.Class
{
    public class ForumPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public MyUser User { get; set; }

        [Required]
        public Topic Topic { get; set; }

        [Required]
        public List<Messaggio_Class> Messaggi { get; set; }

    }
}
