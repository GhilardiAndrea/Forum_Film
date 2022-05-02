using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Forum_Film.Data;
using Web_Api_Forum_Film.Services.Class;
using Web_Api_Forum_Film.Services.Class.Dtos;

namespace Web_Api_Forum_Film.Services
{
    public class MyService : IMyService
    {
        private readonly MyDbContext _context;
        public MyService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseFilms> GetAllFilm()
        {
            ResponseFilms response = new ResponseFilms();
            
            response.List = await _context.Films.ToListAsync();
            response.Success = true;
            response.Errors = null;

            return response;
        }

        public async Task<ResponsePosts> GetAllPostInTopic(int topicId)
        {
            ResponsePosts response = new ResponsePosts();

            var Topic = await _context.Topics.FirstOrDefaultAsync(t => t.Id == topicId);

            var lista = await _context.Posts.Where(p => p.Topic.Id == topicId).ToListAsync();
            if(lista == null)
            {
                response.List = null;
                response.Errors = new List<string>() { "Non sono stati trovati post nel topic selezionato" };
                response.Success = false;
            }
            else
            {
                foreach(var user in _context.Users)
                {
                    
                }
                response.List = lista;
                response.Errors = null;
                response.Success = true;
            }
            return response;
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
