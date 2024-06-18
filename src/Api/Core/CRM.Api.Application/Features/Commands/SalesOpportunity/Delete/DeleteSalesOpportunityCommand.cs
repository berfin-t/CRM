using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.SalesOpportunity.Delete;

public class DeleteSalesOpportunityCommand:IRequest<bool>
{
    public Guid CustomerId { get; set; }

    public DeleteSalesOpportunityCommand(Guid customerId)
    {
        CustomerId = customerId;
    }
}
