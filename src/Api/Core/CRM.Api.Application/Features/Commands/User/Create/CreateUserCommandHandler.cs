using AutoMapper;
using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common;
using CRM.Common.Events;
using CRM.Common.Events.User;
using CRM.Common.Infrastructure;
using CRM.Common.Infrastructure.Exceptions;
using CRM.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.User.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;

    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var existUser = await userRepository.GetSingleAsync(i => i.Email == command.Email);
        if (existUser is not null)
        {
            throw new DatabaseValidationException("User already exist");
        }

        var dbUser = mapper.Map<Domain.Models.User>(command);
        dbUser.Password = PasswordEncryptor.Encrpt(command.Password);

        var rows = await userRepository.AddAsync(dbUser);

        if (rows > 0)
        {
            var @event = new UserEmailChangedEvent()
            {
                OldEmailAddress = null,
                NewEmailAddress = dbUser.Email
            };

            QueueFactory.SendMessageToExchange(exchangeName: CRMConstants.UserExchangeName,
                exchangeType: CRMConstants.DefaultExchangeType,
                queueName: CRMConstants.UserEmailChangedQueueName,
                obj: @event);

        }

        
        return dbUser.Id;
    }

}
