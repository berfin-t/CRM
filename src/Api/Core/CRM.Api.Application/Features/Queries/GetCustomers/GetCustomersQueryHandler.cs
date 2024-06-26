using AutoMapper;
using AutoMapper.QueryableExtensions;
using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetCustomers;

public class GetCustomersQueryHandler:IRequestHandler<GetCustomersQuery, List<GetCustomersViewModel>>
{
    private readonly ICustomerRepository customerRepository;
    private readonly IMapper mapper;

    public GetCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        this.customerRepository = customerRepository;
        this.mapper = mapper;
    }

    public async Task<List<GetCustomersViewModel>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var query = customerRepository.AsQueryable();
        
        var list = query.Select(i => new GetCustomersViewModel()
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

        return await query.ProjectTo<GetCustomersViewModel>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
