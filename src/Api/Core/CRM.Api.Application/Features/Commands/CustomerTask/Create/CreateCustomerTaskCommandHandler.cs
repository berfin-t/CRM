using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Common.Models.RequestModels;
using AutoMapper;
using CRM.Api.Application.Interfaces.Repositories;

namespace CRM.Api.Application.Features.Commands.CustomerTask.Create;

public class CreateCustomerTaskCommandHandler:IRequestHandler<CreateCustomerTaskCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly ICustomerTaskRepository customerTaskRepository;

    public CreateCustomerTaskCommandHandler(IMapper mapper, ICustomerTaskRepository customerTaskRepository)
    {
        this.mapper = mapper;
        this.customerTaskRepository = customerTaskRepository;
    }

    public async Task<Guid> Handle(CreateCustomerTaskCommand command, CancellationToken cancellationToken)
    {
        var dbCustomerTask = mapper.Map<Domain.Models.CustomerTask>(command);
        
        await customerTaskRepository.AddAsync(dbCustomerTask);

        return dbCustomerTask.Id;

        //TODO RabbitMQ için  yaz.
    }

}
