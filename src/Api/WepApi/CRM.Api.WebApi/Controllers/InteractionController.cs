using CRM.Api.Application.Features.Commands.Interaction.Delete;
using CRM.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionController : BaseController
    {

        private readonly IMediator mediator;

        public InteractionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInteractionCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInteraction(Guid customerId)
        {
            var result = await mediator.Send(new DeleteInteractionCommand(customerId, UserId.Value));

            return Ok(result);
        }
    }
}
