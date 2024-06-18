using AutoMapper;
using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.Interaction.Create;

public class CreateInteractionCommandHandler:IRequestHandler<CreateInteractionCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly IInteractionRepository interactionRepository;

    public CreateInteractionCommandHandler(IMapper mapper, IInteractionRepository interactionRepository)
    {
        this.mapper = mapper;
        this.interactionRepository = interactionRepository;
    }

    public async Task<Guid> Handle(CreateInteractionCommand command, CancellationToken cancellationToken)
    {
        var dbInteraction = mapper.Map<Domain.Models.Interaction>(command);

        await interactionRepository.AddAsync(dbInteraction);

        return dbInteraction.Id;

        //TODO RabbitMQ için  yaz
    }
}
