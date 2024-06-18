using CRM.Api.Application.Features.Commands.Customer.Delete;
using CRM.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    var customer = await mediator.Send(new GetCustomerDetailQuery(id, string.Empty));
        //    return Ok(customer);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await mediator.Send(new DeleteCustomerCommand(id));
            return Ok();
        }
    }
}
