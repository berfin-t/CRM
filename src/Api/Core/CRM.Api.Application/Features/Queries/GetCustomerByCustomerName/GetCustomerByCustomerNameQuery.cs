using CRM.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetCustomerByCustomerName;

public class GetCustomerByCustomerNameQuery:IRequest<GetCustomerByCustomerNameViewModel>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public GetCustomerByCustomerNameQuery(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
