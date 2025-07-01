using Microsoft.AspNetCore.Mvc;
using UseCases;

namespace WebUI.Server.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ControllerTemplate : ControllerBase
{
    protected ActionResult HandleGenericResult<T>(Result<T> response)
    {
        return response.Success
            ? response.Value is null
                ? NotFound()
                : Ok(response.Value)
            : BadRequest(response.Error);
    }

    protected ActionResult HandleResult(Result response)
    {
        return response.Success
            ? NoContent()
            : BadRequest(response.Error);
    }
}
