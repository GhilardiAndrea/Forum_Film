using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Forum_Film.Data;
using Web_Api_Forum_Film.Services;
using Web_Api_Forum_Film.Services.Class.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Api_Forum_Film.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IMyService _myservice;
        private readonly MyDbContext _context;
        public ApiController(IMyService myService, MyDbContext context)
        {
            _context = context;
            _myservice = myService;
        }

        #region Gets

        // GET: api/<MyController>/film
        [HttpGet("film")]
        public async Task<ResponseFilms> GetAllFilm()
        {
            return await _myservice.GetAllFilm();
        }


        [HttpGet("topicposts/{id}")]
        public async Task<ResponsePosts> GetAllPostInTopic(int id)
        {
            return await _myservice.GetAllPostInTopic(id);
        }


        [HttpGet("userposts/{id}")]
        public async Task<ResponsePosts> GetAllPostOfUser(int id)
        {
            return await _myservice.GetAllPostOfUser(id);
        }


        [HttpGet("topic/{name}")]
        public async Task<ResponseTopics> GetTopicsFromName(string name)
        {
            return await _myservice.GetTopicsFromName(name);
        }

        [HttpGet("film/{name}")]
        public async Task<ResponseFilms> GetFilmsFromName(string name)
        {
            return await _myservice.GetFilmsFromName(name);
        }


        #endregion


        #region Posts
        // POST api/<MyController>
        [HttpPost("post")]
        public async Task<ResponsePostPost> PostPost([FromBody] RequestPost request)
        {
            return await _myservice.PostPost(request);
        }

        [HttpPost("topic")]
        public async Task<ResponsePostTopic> PostTopic([FromBody] RequestTopic request)
        {
            return await _myservice.PostTopic(request);
        }

        [HttpPost("film")]
        public async Task<ResponsePostFilm> PostFilm([FromBody] RequestFilm request)
        {
            return await _myservice.PostFilm(request);
        }

        [HttpPost("messaggio")]
        public async Task<ResponsePostMessaggio> PostMessaggio([FromBody] RequestMessaggio request)
        {
            return await _myservice.PostMessaggio(request);
        }

        #endregion


        #region Puts
        // PUT api/<MyController>/5
        [HttpPut("messaggio")]
        public async Task<ResponsePostMessaggio> PutMessaggio([FromBody] RequestPutMessaggio request)
        {
            return await _myservice.PutMessaggio(request);
        }

        [HttpPut("topic")]
        public async Task<ResponsePostTopic> PutTopic([FromBody] RequestPutTopic request)
        {
            return await _myservice.PutTopic(request);
        }

        #endregion


        // DELETE api/<MyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
