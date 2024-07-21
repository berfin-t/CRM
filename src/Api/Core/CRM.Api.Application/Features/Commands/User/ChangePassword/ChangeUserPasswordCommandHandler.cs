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

    public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        if(!request.UserId.HasValue)
        {
            throw new ArgumentNullException(nameof(request.UserId));
        }

        var dbUser = await userRepository.GetByIdAsync(request.UserId.Value);

        if (dbUser == null)
        {
            throw new DatabaseValidationException("Uer not fount!");
        }

        var encPass = PasswordEncryptor.Encrpt(request.OldPassword);

        if (dbUser.Password != encPass)
        {
            throw new DatabaseValidationException("Old password wrong!");
        }
        dbUser.Password = PasswordEncryptor.Encrpt(request.NewPassword);
        await userRepository.UpdateAsync(dbUser);

        return true;
    }
}
