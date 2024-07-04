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

namespace CRM.Api.Application.Features.Queries.GetInteractionByCustomerId;

public class GetInteractionByCustomerIdQueryHandler:IRequestHandler<GetInteractionByCustomerIdQuery, List<GetInteractionByCustomerIdViewModel>>
{
    private readonly IInteractionRepository interactionRepository;
    private readonly IMapper mapper;

    public GetInteractionByCustomerIdQueryHandler(IInteractionRepository interactionRepository, IMapper mapper)
    {
        this.interactionRepository = interactionRepository;
        this.mapper = mapper;
    }

    public async Task<List<GetInteractionByCustomerIdViewModel>> Handle(GetInteractionByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var query = interactionRepository.AsQueryable();

        query = query.Where(q=>q.CustomerId == request.CustomerId);

        return await query.ProjectTo<GetInteractionByCustomerIdViewModel>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
