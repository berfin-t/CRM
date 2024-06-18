using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Models.RequestModels;

public class CreateCustomerTaskCommand:IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid CustomerId { get; set; }

    public CreateCustomerTaskCommand(Guid userId, Guid customerId)
    {
        UserId = userId;
        CustomerId = customerId;
    }
}
