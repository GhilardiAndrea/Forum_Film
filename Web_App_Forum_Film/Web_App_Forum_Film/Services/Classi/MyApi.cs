using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Web_Api_Forum_Film.Services.Class;
using Web_Api_Forum_Film.Services.Class.Dtos;

namespace Web_App_Forum_Film.Services.Classi
{
    public class MyApi
    {
        public static string url = "https://localhost:44360/";

        #region GET

        public static async Task<ResponseTopics> GetTopicsFromFilms(RequestGetFilms request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Api/topic/films");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                ResponseTopics response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ResponseTopics>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopics()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        public static async Task<ResponseFilms> GetAllFilm()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + "api/Api/film");

                ResponseFilms response = JsonConvert.DeserializeObject<ResponseFilms>(result);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseFilms()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }

        }

        public static async Task<ResponseTopics> GetTopic(int id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Api/topicid/{id}");

                ResponseTopics response = JsonConvert.DeserializeObject<ResponseTopics>(result);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopics()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }

        }

        public static async Task<ResponseTopics> GetRandomTopics()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + "api/Api/topic/random");

                ResponseTopics response = JsonConvert.DeserializeObject<ResponseTopics>(result);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopics()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }

        }
        public static async Task<ResponsePosts> GetAllPostsInTopic(int id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Api/topicposts/{id}");

                ResponsePosts response = JsonConvert.DeserializeObject<ResponsePosts>(result);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePosts()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }

        }
        public static async Task<ResponsePosts> GetAllPostOfUser(string email)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Api/userposts/{email}");

                ResponsePosts response = JsonConvert.DeserializeObject<ResponsePosts>(result);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePosts()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }

        }
        public static async Task<ResponseTopics> GetTopicsFromName(string name)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Api/topic/{name}");

                ResponseTopics response = JsonConvert.DeserializeObject<ResponseTopics>(result);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopics()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
        public static async Task<ResponseFilms> GetFilmsFromName(string name)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Api/film/{name}");

                ResponseFilms response = JsonConvert.DeserializeObject<ResponseFilms>(result);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseFilms()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        #endregion

        #region POST

        public static async Task<ResponsePostPost> PostPost(RequestPost request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Api/post");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                ResponsePostPost response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ResponsePostPost>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePostPost()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
        public static async Task<ResponsePostTopic> PostTopic(RequestTopic request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Api/topic");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                ResponsePostTopic response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ResponsePostTopic>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePostTopic()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
        public static async Task<ResponsePostFilm> PostFilm(RequestFilm request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Api/film");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                ResponsePostFilm response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ResponsePostFilm>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePostFilm()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        public static async Task<ResponsePostMessaggio> PostMessaggio(RequestMessaggio request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Api/messaggio");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                ResponsePostMessaggio response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ResponsePostMessaggio>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePostMessaggio()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        public static async Task<ResponsePostuser> PostUser(RequestPostUser request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Api/user");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                ResponsePostuser response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ResponsePostuser>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePostuser()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        #endregion

        #region PUTS
        public static async Task<ResponsePostMessaggio> PutMessaggio(RequestPutMessaggio request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Api/putmessaggio");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                ResponsePostMessaggio response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ResponsePostMessaggio>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePostMessaggio()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        public static async Task<ResponsePostTopic> PutTopic(RequestPutTopic request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Api/puttopic");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                ResponsePostTopic response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ResponsePostTopic>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePostTopic()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        public static async Task<ResponsePostuser> PutUser(RequestPutUser request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Api/putuser");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                ResponsePostuser response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ResponsePostuser>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePostuser()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        #endregion

        #region DELETES
        public static async Task<ResponsePostPost> DeletePost(int id)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + $"api/Api/Deletepost/{id}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(id);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                ResponsePostPost response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ResponsePostPost>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePostPost()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
        public static async Task<ResponsePostTopic> DeleteTopic(int id)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + $"api/Api/Deletetopic/{id}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(id);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                ResponsePostTopic response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ResponsePostTopic>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponsePostTopic()
                {
                    Success = false,
                    Errors = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        #endregion
    }

}
