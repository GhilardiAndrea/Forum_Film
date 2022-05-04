using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Forum_Film.Services.Class;
using Web_Api_Forum_Film.Services.Class.Dtos;

namespace Web_Api_Forum_Film.Services
{
    public interface IMyService
    {
        public Task<ResponsePosts> GetAllPostInTopic(int topicId);

        public Task<ResponseTopics> GetTopicsFromName(string name);

        public Task<ResponseFilms> GetFilmsFromName(string name);

        public Task<ResponsePosts> GetAllPostOfUser(int userId);

        public Task<ResponseFilms> GetAllFilm();


        public Task<ResponsePostPost> PostPost(RequestPost request);

        public Task<ResponsePostTopic> PostTopic(RequestTopic request);

        public Task<ResponsePostFilm> PostFilm(RequestFilm request);

        public Task<ResponsePostMessaggio> PostMessaggio(RequestMessaggio request);


        public Task<ResponsePostMessaggio> PutMessaggio(RequestPutMessaggio request);

        public Task<ResponsePostTopic> PutTopic(RequestPutTopic request);

    }
}
