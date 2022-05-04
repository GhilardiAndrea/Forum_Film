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

        #region Gets

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

            var lista = await _context.Posts.Where(p => p.Topic.Id == topicId).ToListAsync();

            await (from p in _context.Posts
             select new
             {
                 p.Id,
                 p.Topic,
                 p.User,
                 p.Messaggi
             }).ToListAsync();

            if (lista == null)
            {
                response.List = null;
                response.Errors = new List<string>() { "Non sono stati trovati post nel topic selezionato" };
                response.Success = false;
            }
            else
            {
                response.List = lista;
                response.Errors = null;
                response.Success = true;
            }
            return response;
        }

        public async Task<ResponsePosts> GetAllPostOfUser(int userId)
        {
            ResponsePosts response = new ResponsePosts();

            var lista = await _context.Posts.Where(p => p.User.Id == userId).ToListAsync();

            await (from p in _context.Posts
                   select new
                   {
                       p.Id,
                       p.Topic,
                       p.User,
                       p.Messaggi
                   }).ToListAsync();

            if (lista == null)
            {
                response.List = null;
                response.Errors = new List<string>() { "Non sono stati trovati post nel topic selezionato" };
                response.Success = false;
            }
            else
            {
                response.List = lista;
                response.Errors = null;
                response.Success = true;
            }
            return response;
        }

        public async Task<ResponseFilms> GetFilmsFromName(string name)
        {
            ResponseFilms response = new ResponseFilms();
            name = name.Trim().ToLower();
            var lista = await _context.Films.Where(f => f.Titolo.ToLower().StartsWith(name)).ToListAsync();
            await(from f in _context.Films
                  select new
                  {
                      f.Id,
                      f.Titolo
                  }).ToListAsync();

            if (lista == null)
            {
                response.List = null;
                response.Errors = new List<string>() { "Non sono stati trovati film col nome selezionato" };
                response.Success = false;
            }
            else
            {
                response.List = lista;
                response.Errors = null;
                response.Success = true;
            }
            return response;
        }

        public async Task<ResponseTopics> GetTopicsFromName(string name)
        {
            ResponseTopics response = new ResponseTopics();
            name = name.Trim().ToLower();
            var lista = await _context.Topics.Where(t => t.Titolo.ToLower().StartsWith(name)).ToListAsync();
            await (from t in _context.Topics
                   select new
                   {
                       t.Id,
                       t.Titolo,
                       t.Film
                   }).ToListAsync();

            if (lista == null)
            {
                response.List = null;
                response.Errors = new List<string>() { "Non sono stati trovati topic col nome selezionato" };
                response.Success = false;
            }
            else
            {
                response.List = lista;
                response.Errors = null;
                response.Success = true;
            }
            return response;
        }

        #endregion

        #region Posts
        public async Task<ResponsePostFilm> PostFilm(RequestFilm request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponsePostMessaggio> PostMessaggio(RequestMessaggio request)
        {
            ResponsePostMessaggio response = new ResponsePostMessaggio();

            Messaggio_Class messaggio = new Messaggio_Class();
            try
            {
                var post = await _context.Posts.FirstOrDefaultAsync(p=>p.Id == request.IdPost);
                
                messaggio.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.IdUser);
                messaggio.Messaggio = request.Messaggio;
                await (from p in _context.Posts
                       select new
                       {
                           p.Id,
                           p.Topic,
                           p.User,
                           p.Messaggi
                       }).ToListAsync();
                if (messaggio.User == null)
                {
                    response.Messaggio = null;
                    response.Errors = new List<string>() { "ID dell'User o del post non validi" };
                    response.Success = false;

                    return response;
                }
                post.Messaggi.Add(messaggio);
                await _context.Messaggi.AddAsync(messaggio);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Messaggio = null;
                response.Errors = new List<string>() { ex.Message };
                response.Success = false;
            }


            response.Messaggio = messaggio;
            response.Errors = null;
            response.Success = true;

            return response;
        }

        public async Task<ResponsePostPost> PostPost(RequestPost request)
        {
            ResponsePostPost response = new ResponsePostPost();

            ForumPost post = new ForumPost();
            try
            {
                post.Topic = await _context.Topics.FirstOrDefaultAsync(t => t.Id == request.IdTopic);
                post.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.IdUser);
                post.Topic.Film = await _context.Films.FirstOrDefaultAsync(f=>f.Id == post.Topic.Id);
                if(post.Topic == null || post.User == null)
                {
                    response.Post = null;
                    response.Errors = new List<string>() { "ID del Topic o User non validi" };
                    response.Success = false;

                    return response;
                }
                post.Messaggi = new List<Messaggio_Class>() {
                    new Messaggio_Class()
                    {
                        User = post.User,
                        Messaggio = request.Message,
                        Data_Creazione = DateTime.Now.Date
                    }
                };
                

                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.Post = null;
                response.Errors = new List<string>() { ex.Message };
                response.Success = false;
            }


            response.Post = post;
            response.Errors = null;
            response.Success = true;

            return response;
        }

        public async Task<ResponsePostTopic> PostTopic(RequestTopic request)
        {
            ResponsePostTopic response = new ResponsePostTopic();

            Topic topic = new Topic();
            try
            {
                topic.Titolo = request.Titolo;
                topic.Film = await _context.Films.FirstOrDefaultAsync(f => f.Id == request.IdFilm);
                
                if (topic.Film == null)
                {
                    response.Topic = null;
                    response.Errors = new List<string>() { "ID del Film non valido" };
                    response.Success = false;

                    return response;
                }

                await _context.Topics.AddAsync(topic);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Topic = null;
                response.Errors = new List<string>() { ex.Message };
                response.Success = false;
            }


            response.Topic = topic;
            response.Errors = null;
            response.Success = true;

            return response;
        }



        #endregion

        #region Puts
        public async Task<ResponsePostMessaggio> PutMessaggio(RequestPutMessaggio request)
        {
            ResponsePostMessaggio response = new ResponsePostMessaggio();
            try
            {
                var messaggio = await _context.Messaggi.FirstOrDefaultAsync(m => m.Id == request.IdMessaggio);

                if (messaggio == null)
                {
                    response.Messaggio = null;
                    response.Success = false;
                    response.Errors = new List<string>() { "Messaggio non trovato" };

                    return response;
                }

                messaggio.Messaggio = request.Messaggio;

                await (from m in _context.Messaggi
                       select new
                       {
                          m.Id,
                          m.Data_Creazione,
                          m.User,
                          m.Messaggio,
                          m.Id_Post
                       }).ToListAsync();

                await _context.SaveChangesAsync();

                response.Messaggio = messaggio;
                response.Success = true;
                response.Errors = null;
            }
            catch(Exception ex)
            {
                response.Messaggio = null;
                response.Success = false;
                response.Errors = new List<string>() { ex.Message };
            }

            return response;
        }

        public async Task<ResponsePostTopic> PutTopic(RequestPutTopic request)
        {
            ResponsePostTopic response = new ResponsePostTopic();
            try
            {
                var topic = await _context.Topics.FirstOrDefaultAsync(t => t.Id == request.IdTopic);
                if(topic == null)
                {
                    response.Topic = null;
                    response.Success = false;
                    response.Errors = new List<string>() { "Topic non trovato" };

                    return response;
                }
                topic.Titolo = request.Titolo;

                await (from t in _context.Topics
                       select new
                       {
                           t.Id,
                           t.Film,
                           t.Titolo
                       }).ToListAsync();

                await _context.SaveChangesAsync();

                response.Topic = topic;
                response.Success = true;
                response.Errors = null;
            }
            catch (Exception ex)
            {
                response.Topic = null;
                response.Success = false;
                response.Errors = new List<string>() { ex.Message };
            }

            return response;
        }


        #endregion
    }

}
