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


        [HttpGet("userposts/{email}")]
        public async Task<ResponsePosts> GetAllPostOfUser(string email)
        {
            return await _myservice.GetAllPostOfUser(email);
        }


        [HttpGet("topic/{name}")]
        public async Task<ResponseTopics> GetTopicsFromName(string name)
        {
            return await _myservice.GetTopicsFromName(name);
        }

        [HttpGet("topicid/{id}")]
        public async Task<ResponseTopics> GetTopic(int id)
        {
            return await _myservice.GetTopic(id);
        }

        [HttpGet("topic/random")]
        public async Task<ResponseTopics> GetTopicsRandom()
        {
            return await _myservice.GetRandomTopics();
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

        [HttpPost("user")]
        public async Task<ResponsePostuser> PostUser([FromBody] RequestPostUser request)
        {
            return await _myservice.PostUser(request);
        }

        #endregion


        #region Puts
        // PUT api/<MyController>/5
        [HttpPut("putmessaggio")]
        public async Task<ResponsePostMessaggio> PutMessaggio([FromBody] RequestPutMessaggio request)
        {
            return await _myservice.PutMessaggio(request);
        }

        [HttpPut("puttopic")]
        public async Task<ResponsePostTopic> PutTopic([FromBody] RequestPutTopic request)
        {
            return await _myservice.PutTopic(request);
        }

        [HttpPut("putuser")]
        public async Task<ResponsePostuser> PutUser([FromBody] RequestPutUser request)
        {
            return await _myservice.PutUser(request);
        }

        #endregion


        #region Deletes

        // DELETE api/<MyController>/5
        [HttpDelete("Deletepost/{id}")]
        public async Task<ResponsePostPost> DeletePost(int id)
        {
            return await _myservice.DeletePost(id);
        }

        [HttpDelete("Deletetopic/{id}")]
        public async Task<ResponsePostTopic> DeleteTopic(int id)
        {
            return await _myservice.DeleteTopic(id);
        }

        #endregion


    }
}
