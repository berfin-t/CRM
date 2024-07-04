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

namespace CRM.Api.Application.Features.Queries.GetSalesOpportunitiesByStage;

public class GetSalesOpportunitiesByStageQueryHandler:IRequestHandler<GetSalesOpportunitiesByStageQuery, List<GetSalesOpportunitiesByStageViewModel>>
{
    private readonly ISalesOpporrtunityRepository salesOpporrtunityRepository;
    private readonly IMapper mapper;

    public GetSalesOpportunitiesByStageQueryHandler(ISalesOpporrtunityRepository salesOpporrtunityRepository, IMapper mapper)
    {
        this.salesOpporrtunityRepository = salesOpporrtunityRepository;
        this.mapper = mapper;
    }

    public async Task<List<GetSalesOpportunitiesByStageViewModel>> Handle(GetSalesOpportunitiesByStageQuery request, CancellationToken cancellationToken)
    {
        var query = salesOpporrtunityRepository.AsQueryable();

        query = query.Where(q => q.Stage == request.Stage);

        var list = query.Select(i => new GetSalesOpportunitiesByStageViewModel()
        {
            CustomerId = i.CustomerId,
            OpportunityName = i.OpportunityName,
            Description = i.Description,
            Value = i.Value,
            Stage = i.Stage,
            CloseDate = i.CloseDate
        });

        return await query.ProjectTo<GetSalesOpportunitiesByStageViewModel>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
