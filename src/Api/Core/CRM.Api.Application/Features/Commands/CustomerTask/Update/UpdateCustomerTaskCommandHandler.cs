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

namespace CRM.Api.Application.Features.Commands.CustomerTask.Update;

public class UpdateCustomerTaskCommandHandler: IRequestHandler<UpdateCustomerTaskCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly ICustomerTaskRepository customerTaskRepository;

    public UpdateCustomerTaskCommandHandler(IMapper mapper, ICustomerTaskRepository customerTaskRepository)
    {
        this.mapper = mapper;
        this.customerTaskRepository = customerTaskRepository;
    }

    public async Task<Guid> Handle(UpdateCustomerTaskCommand request, CancellationToken cancellationToken)
    {
        var dbCustomerTask = await customerTaskRepository.GetByIdAsync(request.Id);

        if (dbCustomerTask == null)
        {
            throw new DatabaseValidationException("Customer Task not founr!");
        }

        mapper.Map(request, dbCustomerTask);

        var rows = customerTaskRepository.UpdateAsync(dbCustomerTask);

        return dbCustomerTask.Id;   

    }
}
