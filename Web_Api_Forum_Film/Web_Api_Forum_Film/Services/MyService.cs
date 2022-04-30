using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Forum_Film.Services.Class;
using Web_Api_Forum_Film.Services.Class.Dtos;

namespace Web_Api_Forum_Film.Services
{
    public class MyService : IMyService
    {
        public async Task<ResponseFilms> GetAllFilm()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponsePosts> GetAllPostInTopic(int topicId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponsePosts> GetAllPostOfUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseTopics> GetTopicsFromName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponsePostFilm> PostFilm(RequestFilm request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponsePostPost> PostPost(RequestPost request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponsePostTopic> PostTopic(RequestTopic request)
        {
            throw new NotImplementedException();
        }
    }

}
