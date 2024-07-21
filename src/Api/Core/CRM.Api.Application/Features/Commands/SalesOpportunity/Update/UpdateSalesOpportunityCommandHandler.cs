using AutoMapper;
using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common.Infrastructure.Exceptions;
using CRM.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.SalesOpportunity.Update;

public class UpdateSalesOpportunityCommandHandler: IRequestHandler<UpdateSalesOpportunityCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly ISalesOpporrtunityRepository salesOpportunityRepository;

    public UpdateSalesOpportunityCommandHandler(IMapper mapper, ISalesOpporrtunityRepository salesOpportunityRepository)
    {
        this.mapper = mapper;
        this.salesOpportunityRepository = salesOpportunityRepository;
    }

    public async Task<Guid> Handle(UpdateSalesOpportunityCommand request, CancellationToken cancellationToken)
    {
        var dbSalesOpportunity = await salesOpportunityRepository.GetByIdAsync(request.Id);
        if(dbSalesOpportunity == null)
        {
            throw new DatabaseValidationException("Sales Opportunity not found!");
        }

        mapper.Map(request, dbSalesOpportunity);

        var rows = await salesOpportunityRepository.UpdateAsync(dbSalesOpportunity);

        return dbSalesOpportunity.Id;
    }
}
