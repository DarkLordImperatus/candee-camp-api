using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CGen.Core.Api.Controllers
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "payments")]
    [Route("api/v{ver:apiVersion}/[controller]")]
    public class PaymentsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {result = new[] {"value1", "value2"}} );
        }
    }
}
