using CRM.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetCustomerTaskDetail;

public class GetCustomerTaskDetailQuery:IRequest<GetCustomerTaskDetailViewModel>
{
    // Guid CustomerTaskId { get; set; }
    public Guid? UserId { get; set; }
    public Guid CustomerId { get; set; }


    public GetCustomerTaskDetailQuery(Guid customerId, Guid? userId)
    {
        CustomerId = customerId;
        UserId = userId;
    }
}
