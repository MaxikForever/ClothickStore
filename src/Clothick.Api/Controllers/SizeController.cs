using Microsoft.AspNetCore.Mvc;

namespace Clothick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SizeController : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult> CreateSize(string sizeName)
    {
        return Ok("we arrange");
    }
}