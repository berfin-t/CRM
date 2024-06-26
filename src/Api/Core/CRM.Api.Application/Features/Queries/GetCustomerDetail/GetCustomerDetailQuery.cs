using CRM.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetCustomerDetail;

public class GetCustomerDetailQuery:IRequest<GetCustomerDetailViewModel>
{
    public Guid CustomerId { get; set; }

    public GetCustomerDetailQuery(Guid customerId)
    {
        CustomerId = customerId;
    }
}
