using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetCustomerByCustomerName;

public class GetCustomerByCustomerNameQueryHandler:IRequestHandler<GetCustomerByCustomerNameQuery, GetCustomerByCustomerNameViewModel>
{
    private readonly ICustomerRepository customerRepository;

    public GetCustomerByCustomerNameQueryHandler(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public async Task<GetCustomerByCustomerNameViewModel> Handle(GetCustomerByCustomerNameQuery request, CancellationToken cancellationToken)
    {
        var query = customerRepository.AsQueryable();

        query = query.Where(i=>i.FirstName == request.FirstName && i.LastName == request.LastName);

        var guid = query.Select(i => new GetCustomerByCustomerNameViewModel()
        {
            Id = i.Id,
            FirstName = i.FirstName,
            LastName = i.LastName,
            Email = i.Email,
            PhoneNumber = i.PhoneNumber,
            Address = i.Address,
            Company = i.Company,
            Notes = i.Notes,
            CreatedDate = i.CreatedDate
        });

        return await guid.FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}
