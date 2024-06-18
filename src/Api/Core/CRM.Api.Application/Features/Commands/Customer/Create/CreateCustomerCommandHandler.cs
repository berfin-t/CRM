using AutoMapper;
using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common.Infrastructure.Exceptions;
using CRM.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.Customer.Create;

public class CreateCustomerCommandHandler:IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly ICustomerRepository customerRepository;

    public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        this.mapper = mapper;
        this.customerRepository = customerRepository;
    }

    public async Task<Guid> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var existCustomer = await customerRepository.GetSingleAsync(i=>i.Email == command.Email);
        if (existCustomer is not null)
        {
            throw new DatabaseValidationException("Customer already exist");
        }

        var dbCustomer = mapper.Map<Domain.Models.Customer>(command);

        var rows = await customerRepository.AddAsync(dbCustomer);

        return dbCustomer.Id;
    }
}
