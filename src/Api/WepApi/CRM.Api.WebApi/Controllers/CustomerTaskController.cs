using CRM.Api.Application.Features.Commands.Customer.Delete;
using CRM.Api.Application.Features.Commands.CustomerTask.Delete;
using CRM.Api.Application.Features.Queries.GetCustomerDetail;
using CRM.Api.Application.Features.Queries.GetCustomerTaskDetail;
using CRM.Common.Models.Queries;
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
        [Route("Add")]
        public async Task<IActionResult> Create(CreateCustomerTaskCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateCustomerTask([FromBody] UpdateCustomerTaskCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid customerId)
        {
            //var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CustomerID");
            //if (customerIdClaim == null)
            //{
            //    return BadRequest("Customer ID not found in claims.");
            //}

            //var customerId = Guid.Parse(customerIdClaim.Value);

            var customerTask = await mediator.Send(new GetCustomerTaskDetailQuery(customerId, UserId));
            return Ok(customerTask);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search([FromQuery] SearchCustomerTaskQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomerTask(Guid customerId)
        //{
        //    var result = await mediator.Send(new DeleteCustomerTaskCommand(customerId, UserId.Value));
        //    return Ok(result);
        //}
    }
}
