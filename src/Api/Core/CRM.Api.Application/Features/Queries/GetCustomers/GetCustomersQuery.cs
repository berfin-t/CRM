using CRM.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetCustomers;

public class GetCustomersQuery: IRequest<List<GetCustomersViewModel>>
{
    public int Count { get; set; } = 50;
}
