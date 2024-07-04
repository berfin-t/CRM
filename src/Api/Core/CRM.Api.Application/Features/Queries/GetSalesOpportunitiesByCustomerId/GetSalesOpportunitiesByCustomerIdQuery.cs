using CRM.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetSalesOpportunitiesByCustomerId;

public class GetSalesOpportunitiesByCustomerIdQuery:IRequest<List<GetSalesOpportunitiesByCustomerIdViewModel>>
{
    public Guid CustomerId { get; set; }

    public GetSalesOpportunitiesByCustomerIdQuery(Guid customerId)
    {
        CustomerId = customerId;
    }
}
