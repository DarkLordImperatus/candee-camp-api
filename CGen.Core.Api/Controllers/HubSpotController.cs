using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CGen.Core.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CGen.Core.Api.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Authorize(Roles = "web-unauth")]
    [Route("api/v{ver:apiVersion}/[controller]")]
    public class HubSpotController : Controller
    {
        private static HttpClient _client;
        private readonly string _hubSpotKey;
        private readonly string _hubSpotUrl;

        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public HubSpotController(IConfiguration config)
        {
            _client = new HttpClient();

            _hubSpotKey = config["HubSpot:Key"];
            _hubSpotUrl = config["HubSpot:Url"];
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddContact([FromBody] HubSpotContactModel model)
        {
            const string url = "/contacts/v1/contact";
            var transformedObject = model.Transform();
            var jsonObject = JsonConvert.SerializeObject(transformedObject, _serializerSettings);
            var content = new StringContent(jsonObject, Encoding.UTF8, "text/json");
            
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await _client.PostAsync($"{_hubSpotUrl}{url}?hapikey={_hubSpotKey}", content);

            return Ok(new { result = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result) });
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetContacts()
        {
            const string url = "/contacts/v1/lists/all/contacts/all";
            
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await _client.GetAsync($"{_hubSpotUrl}{url}?hapikey={_hubSpotKey}");

            return Ok(new {result = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result)});
        }
    }
}