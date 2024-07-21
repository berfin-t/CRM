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

namespace CRM.Api.Application.Features.Queries.GetUserByUserId;

public class GetUserByUserIdQueryHandler:IRequestHandler<GetUserByUserIdQuery, List<GetUserByUserIdViewModel>>
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public GetUserByUserIdQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<List<GetUserByUserIdViewModel>> Handle(GetUserByUserIdQuery request, CancellationToken cancellationToken)
    {
        var query = userRepository.AsQueryable();

        query = query.Where(q=>q.Id == request.UserId);

        return await query.ProjectTo<GetUserByUserIdViewModel>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
