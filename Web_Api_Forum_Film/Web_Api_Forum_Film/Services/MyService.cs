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

        public async Task<ResponseTopics> GetTopic(int id)
        {
            ResponseTopics response = new ResponseTopics();
            var lista = await _context.Topics.Where(t => t.Id == id).ToListAsync();
            await(from t in _context.Topics
                  select new
                  {
                      t.Id,
                      t.Titolo,
                      t.Film
                  }).ToListAsync();

            if (lista == null)
            {
                response.List = null;
                response.Errors = new List<string>() { "Non sono stati trovati topic coll' id selezionato" };
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

        public async Task<ResponsePosts> GetAllPostOfUser(string email)
        {
            ResponsePosts response = new ResponsePosts();

            var lista = await _context.Posts.Where(p => p.User.Email == email).ToListAsync();

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
            var lista = await _context.Films.Where(f => f.Titolo_Originale.ToLower().StartsWith(name)).ToListAsync();
            await(from f in _context.Films
                  select new
                  {
                      f.Id,
                      f.Titolo_Originale,
                      f.Budget,
                      f.Genere,
                      f.Lingua_Originale,
                      f.OverView,
                      f.Poster_Path
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

        public async Task<ResponseTopics> GetRandomTopics()
        {
            Random random = new Random();
            List<Topic> lista = await _context.Topics.ToListAsync();
            List<Topic> listafinale = new List<Topic>();
            int num;
            lista = lista.OrderBy(t => t.Id).ToList();
            for (int i = 0; i < 12; i++)
            {
                num = random.Next(lista[0].Id, lista[lista.Count - 1].Id);
                listafinale.Add(lista[num]);
            }

            await (from t in _context.Topics
                   select new
                   {
                       t.Id,
                       t.Titolo,
                       t.Film
                   }).ToListAsync();

            ResponseTopics response = new ResponseTopics();

            response.List = listafinale;
            response.Errors = null;
            response.Success = true;

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
                
                messaggio.User = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.EmailUser);
                messaggio.Messaggio = request.Messaggio;
                messaggio.Data_Creazione = DateTime.Now;
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

                return response;
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
                post.User = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.EmailUser);
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
                        Data_Creazione = DateTime.Now
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

                return response;
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

                return response;
            }


            response.Topic = topic;
            response.Errors = null;
            response.Success = true;

            return response;
        }

        public async Task<ResponsePostuser> PostUser(RequestPostUser request)
        {
            ResponsePostuser response = new ResponsePostuser();
            MyUser user = new MyUser()
            {
                Cognome = request.User.Cognome,
                Nome = request.User.Nome,
                Data_Nascita = request.User.Data_Nascita,
                Email = request.User.Email,
                Nazione = request.User.Nazione
            };
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.User = null;
                response.Errors = new List<string>() { ex.Message };
                response.Success = false;

                return response;
            }


            response.User = user;
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

                return response;
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

                return response;
            }

            return response;
        }

        public async Task<ResponsePostuser> PutUser(RequestPutUser request)
        {
            ResponsePostuser response = new ResponsePostuser();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(t => t.Email == request.User.Email);
                if (user == null)
                {
                    response.User = null;
                    response.Success = false;
                    response.Errors = new List<string>() { "User non trovato" };

                    return response;
                }

                user.Cognome = request.User.Cognome;
                user.Nome = request.User.Nome;
                user.Data_Nascita = request.User.Data_Nascita;
                user.Nazione = request.User.Nazione;

                await _context.SaveChangesAsync();

                response.User = user;
                response.Success = true;
                response.Errors = null;
            }
            catch (Exception ex)
            {
                response.User = null;
                response.Success = false;
                response.Errors = new List<string>() { ex.Message };

                return response;
            }

            return response;
        }
        #endregion

        #region Deletes

        public async Task<ResponsePostPost> DeletePost(int id)
        {
            ResponsePostPost response = new ResponsePostPost();

            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if(post == null)
            {
                response.Success = false;
                response.Post = null;
                response.Errors = new List<string>() { "Nessun post trovato con quell'id" };

                return response;
            }
            await (from p in _context.Posts
                   select new
                   {
                       p.Id,
                       p.Topic,
                       p.User,
                       p.Messaggi
                   }).ToListAsync();

            foreach( Messaggio_Class messaggio in post.Messaggi )
            {                
                _context.Messaggi.Remove(messaggio);
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            response.Success = true;
            response.Post = post;
            response.Errors = null;

            return response;
        }

        public async Task<ResponsePostTopic> DeleteTopic(int id)
        {
            ResponsePostTopic response = new ResponsePostTopic();

            var topic = await _context.Topics.FirstOrDefaultAsync(t => t.Id == id);
            if (topic == null)
            {
                response.Success = false;
                response.Topic = null;
                response.Errors = new List<string>() { "Nessun post trovato con quell'id" };

                return response;
            }

            await (from t in _context.Topics
                   select new
                   {
                       t.Id,
                       t.Titolo,
                       t.Film
                   }).ToListAsync();

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            response.Success = true;
            response.Topic = topic;
            response.Errors = null;

            return response;

        }

        





        #endregion

    }

}
