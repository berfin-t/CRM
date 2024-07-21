using CRM.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetUserByUserId;

public class GetUserByUserIdQuery:IRequest<List<GetUserByUserIdViewModel>>
{
    public Guid UserId { get; set; }

    public GetUserByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }
}
