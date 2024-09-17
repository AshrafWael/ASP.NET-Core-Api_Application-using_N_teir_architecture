using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.BLL.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HospitalManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalApiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ExternalApiController(HttpClient httpClient )
        {
          _httpClient = httpClient;
        }

        
        [HttpGet]
        [Route("GetAllPosts")]
        public ActionResult GetAllPosts()
        {
            var Responce = _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts").Result;
            var Data = System.Text.Json.JsonSerializer.Deserialize<List<Post>>(Responce);
            return Ok(Data);
        }
        [HttpPost]
        [Route("AddPost")]
        public async Task<ActionResult> Post(Post post) 
        {
            var Content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8,"Application/json");
            var Response = await _httpClient.PutAsync("https://jsonplaceholder.typicode.com/posts", Content);
            //return RedirectToAction("GetAllPosts");
            return Ok(Response);

        }


    }
}
