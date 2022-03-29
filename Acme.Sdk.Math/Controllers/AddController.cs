using Acme.Sdk.Common;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Sdk.Math.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddController : ControllerBase
{
    [HttpPost]
    public int Post(AddNumbers addNumber)
    {
        return addNumber.A + addNumber.B;
    }
}

