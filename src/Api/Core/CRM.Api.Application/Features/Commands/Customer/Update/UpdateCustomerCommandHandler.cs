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

namespace CRM.Api.Application.Features.Commands.Customer.Update;

public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly ICustomerRepository customerRepository;

    public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        this.mapper = mapper;
        this.customerRepository = customerRepository;
    }

    public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var dbCustomer = await customerRepository.GetByIdAsync(request.Id);
        if (dbCustomer == null)
        {
            throw new DatabaseValidationException("Customer not found!");
        }

        mapper.Map(request, dbCustomer);

        var rows = await customerRepository.UpdateAsync(dbCustomer);

        return dbCustomer.Id;
    }
}
