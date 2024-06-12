using AutoMapper;
using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common;
using CRM.Common.Events;
using CRM.Common.Infrastructure;
using CRM.Common.Infrastructure.Exceptions;
using CRM.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.User.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;

    public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<Guid> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var dbUser = await userRepository.GetByIdAsync(command.Id);

        if (dbUser is null)
        {
            throw new DatabaseValidationException("User not found");
        }

        var dbEmailAddress = dbUser.Email;
        var emailChanged = string.CompareOrdinal(dbEmailAddress, command.Email) != 0;

        mapper.Map(command, dbUser);

        var rows = await userRepository.UpdateAsync(dbUser);

        if (emailChanged && rows > 0)
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

            dbUser.EmailConfirmed = false;
            await userRepository.UpdateAsync(dbUser);
        }

        return dbUser.Id;
}
}
