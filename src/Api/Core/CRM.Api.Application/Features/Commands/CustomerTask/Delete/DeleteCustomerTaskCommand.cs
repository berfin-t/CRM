using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.CustomerTask.Delete;

public class DeleteCustomerTaskCommand:IRequest<bool>
{
    public Guid UserId { get; set; }
    public Guid CustomerId { get; set; }

    public DeleteCustomerTaskCommand(Guid userId, Guid customerId)
    {
        UserId = userId;
        CustomerId = customerId;
    }
}
