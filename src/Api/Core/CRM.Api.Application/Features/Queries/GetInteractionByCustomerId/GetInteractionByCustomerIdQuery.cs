using CRM.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetInteractionByCustomerId;

public class GetInteractionByCustomerIdQuery: IRequest<List<GetInteractionByCustomerIdViewModel>>
{
    public Guid CustomerId { get; set; }

    public GetInteractionByCustomerIdQuery(Guid customerId)
    {
        CustomerId = customerId;
    }
}
