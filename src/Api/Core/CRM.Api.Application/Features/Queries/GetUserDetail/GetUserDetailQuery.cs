using CRM.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetUserDetail;

public class GetUserDetailQuery : IRequest<GetUserByUserIdViewModel>
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }

    public GetUserDetailQuery(Guid userId, string userName)
    {
        UserId = userId;
        UserName = userName;
    }
}
