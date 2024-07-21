using CRM.Api.Application.Features.Commands.Interaction.Delete;
using CRM.Api.Application.Features.Queries.GetInteractionByCustomerId;
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
        [Route("Add")]
        public async Task<IActionResult> Create(CreateInteractionCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateInteraction([FromBody] UpdateInteractionCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }        

        [HttpGet]
        public async Task<IActionResult> GetByCustomerId(Guid customerId)
        {
            var byId = await mediator.Send(new GetInteractionByCustomerIdQuery(customerId));
            return Ok(byId);
        }
    }
}
