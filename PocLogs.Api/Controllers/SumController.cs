using Microsoft.AspNetCore.Mvc;

namespace PocLogs.Api.Controllers;

public record IdRequest(long Id);

[ApiController]
[Route("[controller]")]
public class SumController : ControllerBase
{
    [HttpPost]
    public ActionResult<long> Post([FromBody] IdRequest request)
    {
        return Ok(request.Id + 1);
    }
}
