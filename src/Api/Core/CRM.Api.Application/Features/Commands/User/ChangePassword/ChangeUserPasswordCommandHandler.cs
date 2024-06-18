using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common.Events.User;
using CRM.Common.Infrastructure;
using CRM.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.User.ChangePassword;

public class ChangeUserPasswordCommandHandler:IRequestHandler<ChangeUserPasswordCommand, bool>
{
    private readonly IUserRepository userRepository;

    public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<bool> Handle(ChangeUserPasswordCommand command, CancellationToken cancellationToken)
    {
        if(!command.UserId.HasValue)
        {
            throw new ArgumentNullException(nameof(command.UserId));
        }

        var dbUser = await userRepository.GetByIdAsync(command.UserId.Value);

        if (dbUser == null)
        {
            throw new DatabaseValidationException("Uer not fount!");
        }

        var encPass = PasswordEncryptor.Encrpt(command.NewPassword);
        await userRepository.UpdateAsync(dbUser);

        return true;
    }
}
