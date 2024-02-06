using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator mediator;

    protected IMediator Mediator => mediator ??=
        HttpContext.RequestServices.GetService<IMediator>();

    protected abstract ActionResult HandleResult<T>(Result<T> result);
}