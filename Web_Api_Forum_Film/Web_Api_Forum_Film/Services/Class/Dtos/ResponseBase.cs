using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Forum_Film.Services.Class.Dtos
{
    public class ResponseBase
    {
        [Required]
        public bool Success { get; set; }

        public List<string> Errors { get; set; }
    }
    public class ResponsePosts : ResponseBase
    {
        public List<ForumPost> List { get; set; }
    }

    public class ResponseTopics : ResponseBase
    {
        public List<Topic> List { get; set; }
    }

    public class ResponseFilms : ResponseBase
    {
        public List<Film> List { get; set; }
    }

    public class ResponsePostPost : ResponseBase
    {
        public ForumPost Post { get; set; }
    }

    public class ResponsePostTopic : ResponseBase
    {
        public Topic Topic { get; set; }
    }

    public class ResponsePostFilm : ResponseBase
    {
        public Film Film { get; set; }
    }
}
