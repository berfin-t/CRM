using CRM.Api.Application.Interfaces.Repositories;
using CRM.Api.Domain.Models;
using CRM.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetCustomerDetail;

public class GetCustomerDetailQueryHandler:IRequestHandler<GetCustomerDetailQuery, GetCustomerDetailViewModel>
{
    private readonly ICustomerRepository customerRepository;

    public GetCustomerDetailQueryHandler(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public async Task<GetCustomerDetailViewModel> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
    {
        var query = customerRepository.AsQueryable();

        query = query.Where(i => i.Id == request.CustomerId);

        var guid = query.Select(i => new GetCustomerDetailViewModel()
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
