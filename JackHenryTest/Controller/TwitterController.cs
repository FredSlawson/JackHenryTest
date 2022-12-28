using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace JackHenryTest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {

        private IConfiguration _config;

        public TwitterController(IConfiguration Config)
        {
            _config = Config;
        }

        [EnableCors]
        [HttpGet]
        public async Task<Stream> GetStream()
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _config.GetValue<string>("BearerToken"));
                return await http.GetStreamAsync("https://api.twitter.com/2/tweets/sample/stream");
            }
        }

    }
}
