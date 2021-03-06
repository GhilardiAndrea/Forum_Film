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

        public Task<ResponseTopics> GetTopic(int id);

        public Task<ResponseTopics> GetRandomTopics();

        public Task<ResponseTopics> GetTopicsFromFilms(RequestGetFilms request);

        public Task<ResponseFilms> GetFilmsFromName(string name);

        public Task<ResponsePosts> GetAllPostOfUser(string email);

        public Task<ResponseFilms> GetAllFilm();

        public Task<ResponsePostuser> PostUser(RequestPostUser request);

        public Task<ResponsePostPost> PostPost(RequestPost request);

        public Task<ResponsePostTopic> PostTopic(RequestTopic request);

        public Task<ResponsePostFilm> PostFilm(RequestFilm request);

        public Task<ResponsePostMessaggio> PostMessaggio(RequestMessaggio request);


        public Task<ResponsePostMessaggio> PutMessaggio(RequestPutMessaggio request);

        public Task<ResponsePostTopic> PutTopic(RequestPutTopic request);

        public Task<ResponsePostuser> PutUser(RequestPutUser request);


        public Task<ResponsePostPost> DeletePost(int id);

        public Task<ResponsePostTopic> DeleteTopic(int id);

    }
}
