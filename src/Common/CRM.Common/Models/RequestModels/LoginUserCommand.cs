﻿using CRM.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Models.RequestModels;

public class LoginUserCommand: IRequest<LoginUserViewModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public LoginUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public LoginUserCommand() { }
}
