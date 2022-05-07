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
        public static string url = "https://localhost:5001/";

        #region GET
        public static async Task<ResponseFilms> GetAllFilm()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + "api/api/film");

                ResponseFilms response = JsonConvert.DeserializeObject<ResponseFilms>(result);

                return response;
            }
            catch
            {
                return null;
            }

        }
        public static async Task<ResponsePosts> GetAllPostsInTopic(int id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/api/topicposts/{id}");

                ResponsePosts response = JsonConvert.DeserializeObject<ResponsePosts>(result);

                return response;
            }
            catch
            {
                return null;
            }

        }
        public static async Task<ResponsePosts> GetAllPostOfUser(string email)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/api/userposts/{email}");

                ResponsePosts response = JsonConvert.DeserializeObject<ResponsePosts>(result);

                return response;
            }
            catch
            {
                return null;
            }

        }
        public static async Task<ResponseTopics> GetTopicsFromName(string name)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/api/topic/{name}");

                ResponseTopics response = JsonConvert.DeserializeObject<ResponseTopics>(result);

                return response;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<ResponseFilms> GetFilmsFromName(string name)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/api/film/{name}");

                ResponseFilms response = JsonConvert.DeserializeObject<ResponseFilms>(result);

                return response;
            }
            catch
            {
                return null;
            }
        }

        #endregion


        public static async Task<ResponsePostPost> PostPost(RequestPost request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/api/post");
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/api/topic");
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/api/film");
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/api/messaggio");
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
        public static async Task<CreateTopicResponse> ModTopic(ModTopicRequest request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Manga/ModTopic");
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
                CreateTopicResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<CreateTopicResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new CreateTopicResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        public static async Task<DeletePostResponse> DeletePost(DeletePostRequest request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + $"api/Manga/DeletePost");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                DeletePostResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<DeletePostResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new DeletePostResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
        public static async Task<DeleteTopicResponse> DeleteTopic(DeleteTopicRequest request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + $"api/Manga/DeleteTopic");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                DeleteTopicResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<DeleteTopicResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new DeleteTopicResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
        public static async Task<DeleteReplyResponse> DeleteReply(DeleteReplyRequest request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + $"api/Manga/DeleteReply");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                DeleteReplyResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<DeleteReplyResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new DeleteReplyResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
    }
}
