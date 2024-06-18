using CRM.Api.Application.Features.Commands.User.ConfirmEmail;
using CRM.Common.Events.User;
using CRM.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CRM.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    [Route("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
    {
        if(!command.UserId.HasValue)
        {
            command.UserId = UserId;
        }

        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    [Route("Confirm")]
    public async Task<IActionResult> ConfirmEmail(Guid id)
    {
        var result = await mediator.Send(new ConfirmEmailCommand()
        {
            ConfirmationId = id
        });

        return Ok(result);
    }
    
}
