using Acme.Sdk.Common;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Sdk.Math.Controllers;

[ApiController]
[Route("[controller]")]
public class AddController : ControllerBase
{
    private readonly ILogger<AddController> _logger;

    public AddController(ILogger<AddController> logger)
    {
        _logger = logger;
    }

    [HttpPost()]
    public int Post(AddNumbers addNumber)
    {
        return addNumber.A + addNumber.B;
    }
}

