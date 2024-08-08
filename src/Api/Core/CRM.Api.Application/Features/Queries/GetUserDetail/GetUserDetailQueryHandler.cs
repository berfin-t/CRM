using AutoMapper;
using CRM.Api.Application.Interfaces.Repositories;
using CRM.Api.Domain.Models;
using CRM.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetUserDetail;

public class GetUserDetailQueryHandler: IRequestHandler<GetUserDetailQuery, GetUserByUserIdViewModel>
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public GetUserDetailQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<GetUserByUserIdViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
        User dbUser = null;

        if (request.UserId != Guid.Empty)
            dbUser = await userRepository.GetByIdAsync(request.UserId);

        else if (!string.IsNullOrEmpty(request.UserName))
            dbUser = await userRepository.GetSingleAsync(i => i.Username == request.UserName);

        return mapper.Map<GetUserByUserIdViewModel>(dbUser);
    }

    
}
