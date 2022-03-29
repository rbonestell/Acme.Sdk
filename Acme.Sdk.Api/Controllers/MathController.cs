using Acme.Common.Utils;
using Acme.Sdk.Common;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Sdk.Api.Controllers;

[Route("api/[controller]")]
public class MathController : Controller
{
    [HttpPost]
    [Route("add")]
    public async Task<int> Post([FromBody]AddNumbers addNumbers)
    {
        return await ServiceClient.Post<int>(addNumbers, ServiceClient.Endpoint.Math, "add");
    }
}
