using CRM.Api.Application.Features.Commands.Customer.Delete;
using CRM.Api.Application.Features.Queries.GetCustomerByCustomerName;
using CRM.Api.Application.Features.Queries.GetCustomerDetail;
using CRM.Api.Application.Features.Queries.GetCustomers;
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
        [Route("Add")]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var result = await mediator.Send(new DeleteCustomerCommand(id));
            return Ok(result);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await mediator.Send(new GetCustomerDetailQuery(id));
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery] GetCustomersQuery query)
        {
            var customers = await mediator.Send(query);
            return Ok(customers);
        }

        [HttpGet("GetByCustomerName")]
        public async Task<IActionResult> GetByCustomerName(string firstName, string lastName)
        {
            var customer = await mediator.Send(new GetCustomerByCustomerNameQuery(firstName, lastName));
            return Ok(customer);
        }        
        
    }
}
