﻿using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.User.ConfirmEmail;

public class ConfirmEmailCommandHandler:IRequestHandler<ConfirmEmailCommand, bool>
{
    private readonly IUserRepository userRepository;
    private readonly IEmailConfirmationRepository emailConfirmationRepository;

    public ConfirmEmailCommandHandler(IUserRepository userRepository, IEmailConfirmationRepository emailConfirmationRepository)
    {
        this.userRepository = userRepository;
        this.emailConfirmationRepository = emailConfirmationRepository;
    }

    public async Task<bool> Handle(ConfirmEmailCommand command, CancellationToken cancellationToken)
    {
        var confirmation = await emailConfirmationRepository.GetByIdAsync(command.ConfirmationId);

        if (confirmation == null)
        {
            throw new DatabaseValidationException("Confirmation not found");
        }

        var dbUser = await userRepository.GetSingleAsync(i => i.Email == confirmation.NewEmailAddress);

        if (dbUser == null)
        {
            throw new DatabaseValidationException("User not found");
        }

        if(dbUser.EmailConfirmed)
        {
            throw new DatabaseValidationException("Email address is already confirmed!");
        }

        dbUser.EmailConfirmed = true;
        await userRepository.UpdateAsync(dbUser);

        return true;
    }
}
