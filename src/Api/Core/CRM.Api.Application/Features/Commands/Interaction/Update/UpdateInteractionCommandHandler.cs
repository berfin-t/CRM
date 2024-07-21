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

namespace CRM.Api.Application.Features.Commands.Interaction.Update;

public class UpdateInteractionCommandHandler:IRequestHandler<UpdateInteractionCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly IInteractionRepository interactionRepository;

    public UpdateInteractionCommandHandler(IMapper mapper, IInteractionRepository interactionRepository)
    {
        this.mapper = mapper;
        this.interactionRepository = interactionRepository;
    }

    public async Task<Guid> Handle(UpdateInteractionCommand request, CancellationToken cancellationToken)
    {
        var dbInteraction = await interactionRepository.GetByIdAsync(request.Id);

        if (dbInteraction == null)
        {
            throw new DatabaseValidationException("Interaction not found!");
        }

        mapper.Map(request, dbInteraction);

        var rows = await interactionRepository.UpdateAsync(dbInteraction);

        return dbInteraction.Id;
    }
}
