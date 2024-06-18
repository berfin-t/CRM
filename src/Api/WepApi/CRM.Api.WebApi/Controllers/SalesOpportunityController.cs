using CRM.Api.Application.Features.Commands.SalesOpportunity.Delete;
using CRM.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOpportunityController : BaseController
    {
        private readonly IMediator mediator;

        public SalesOpportunityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSalesOpportunityCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSalesOpportunity(Guid customerId)
        {
            var result = await mediator.Send(customerId);

            return Ok(result);
        }
    }
}
