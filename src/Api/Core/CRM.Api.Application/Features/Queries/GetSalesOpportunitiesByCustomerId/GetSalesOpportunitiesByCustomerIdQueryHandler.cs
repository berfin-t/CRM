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

namespace CRM.Api.Application.Features.Queries.GetSalesOpportunitiesByCustomerId;

public class GetSalesOpportunitiesByCustomerIdQueryHandler:IRequestHandler<GetSalesOpportunitiesByCustomerIdQuery, List<GetSalesOpportunitiesByCustomerIdViewModel>>
{
    private readonly ISalesOpporrtunityRepository salesOpporrtunityRepository;
    private readonly IMapper mapper;

    public GetSalesOpportunitiesByCustomerIdQueryHandler(ISalesOpporrtunityRepository salesOpporrtunityRepository, IMapper mapper)
    {
        this.salesOpporrtunityRepository = salesOpporrtunityRepository;
        this.mapper = mapper;
    }

    public async Task<List<GetSalesOpportunitiesByCustomerIdViewModel>> Handle(GetSalesOpportunitiesByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var query = salesOpporrtunityRepository.AsQueryable();

        query = query.Where(q=>q.CustomerId == request.CustomerId);

        //var list = query.Select(i=> new GetSalesOpportunitiesByCustomerIdViewModel()
        //{
        //    CustomerId = i.CustomerId,
        //    OpportunityName = i.OpportunityName,
        //    Description = i.Description,
        //    Value = i.Value,
        //    Stage = i.Stage,
        //    CloseDate = i.CloseDate
        //});


        return await query.ProjectTo<GetSalesOpportunitiesByCustomerIdViewModel>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
