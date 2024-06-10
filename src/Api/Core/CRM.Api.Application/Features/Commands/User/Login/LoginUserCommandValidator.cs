using CRM.Common.Models.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.User.Login;

public class LoginUserCommandValidator: AbstractValidator<LoginUserCommand> 
{
    public LoginUserCommandValidator()
    {
        RuleFor(i => i.Email)
             .NotNull()
             .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
             .WithMessage("{PropertyName} not a valid email address");

        RuleFor(i => i.Password)
            .NotNull()
            .MinimumLength(8)
            .WithMessage("{PropertyName} should at least be {MinLenght} characters");

    }
}
