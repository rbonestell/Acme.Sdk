using Acme.Common.Utils;
using Acme.Sdk.Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Acme.Sdk.Api.Controllers
{
    [Route("api/[controller]")]
    public class WorkController : Controller
    {
        // POST api/values
        [HttpPost]
        public async Task<int> Post([FromBody]AddNumbers addNumbers)
        {
            return await ServiceClient.Post<int>(addNumbers, ServiceClient.Endpoint.Math, "add");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkResult();
        }

    }
}

