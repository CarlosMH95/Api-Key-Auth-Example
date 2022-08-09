using Api_Key_Auth_Example.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Api_Key_Auth_Example.Controllers.V1
{
    [ApiKeyAuth]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [HttpGet(template:"secret")]
        public IActionResult GetSecret()
        {
            return Ok("I Have no Secrets");
        }
    }
}
