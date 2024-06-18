using CRM.Api.Application.Features.Commands.Customer.Delete;
using CRM.Api.Application.Features.Commands.CustomerTask.Delete;
using CRM.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTaskController : BaseController
    {
        private readonly IMediator mediator;

        public CustomerTaskController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerTaskCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomerTask(Guid customerId)
        {
            var result = await mediator.Send(new DeleteCustomerTaskCommand(customerId, UserId.Value));
            return Ok(result);
        }
    }
}
