﻿using AutoMapper;
using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common.Infrastructure;
using CRM.Common.Infrastructure.Exceptions;
using CRM.Common.Models.Queries;
using CRM.Common.Models.RequestModels;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.User.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    private readonly IConfiguration configuration;

    public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
        this.configuration = configuration;
    }

    public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await userRepository.GetSingleAsync(i => i.Email == request.Email);

        if (dbUser == null)
        {
            throw new DatabaseValidationException("User not found");
        }

        var pass = PasswordEncryptor.Encrpt(request.Password);
        if (dbUser.Password != pass)
        {
            throw new DatabaseValidationException("Password is wrong!");
        }
        if (!dbUser.EmailConfirmed)
        {
            throw new DatabaseValidationException("Email address have not been confirmed yet!");
        }

        var result = mapper.Map<LoginUserViewModel>(dbUser);

        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
            new Claim(ClaimTypes.Name, dbUser.Username),
            new Claim(ClaimTypes.GivenName, dbUser.FirstName),
            new Claim(ClaimTypes.Surname, dbUser.LastName),
            new Claim(ClaimTypes.Email, dbUser.Email),
        };

        result.Token = GenerateToken(claims);
        return result;


    }

    private string GenerateToken(Claim[] claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthConfig:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.Now.AddDays(10);

        var token = new JwtSecurityToken(claims: claims,
            expires: expiry,
            signingCredentials: creds,
            notBefore: DateTime.Now);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
