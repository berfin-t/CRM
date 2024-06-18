using AutoMapper;
using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.SalesOpportunity.Create;

public class CreateSalesOpportunittyCommandHandler:IRequestHandler<CreateSalesOpportunityCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly ISalesOpporrtunityRepository salesOpporrtunityRepository;

    public CreateSalesOpportunittyCommandHandler(IMapper mapper, ISalesOpporrtunityRepository salesOpporrtunityRepository)
    {
        this.mapper = mapper;
        this.salesOpporrtunityRepository = salesOpporrtunityRepository;
    }

    public async Task<Guid> Handle(CreateSalesOpportunityCommand command, CancellationToken cancellationToken)
    {
        var dbSalesOpportunity = mapper.Map<Domain.Models.SalesOpportunity>(command);

        await salesOpporrtunityRepository.AddAsync(dbSalesOpportunity);

        return dbSalesOpportunity.Id;
    }
}
