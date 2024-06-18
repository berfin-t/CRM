using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Models.RequestModels;

public class CreateSalesOpportunityCommand:IRequest<Guid>
{
    public Guid CustomerId { get; set; }

    public CreateSalesOpportunityCommand(Guid customerId)
    {
        CustomerId = customerId;
    }
}
