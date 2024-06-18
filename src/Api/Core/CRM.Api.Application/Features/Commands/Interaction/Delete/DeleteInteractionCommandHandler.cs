using CRM.Common;
using CRM.Common.Events.Interaction;
using CRM.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.Interaction.Delete;

public class DeleteInteractionCommandHandler: IRequestHandler<DeleteInteractionCommand, bool>
{
    public async Task<bool> Handle(DeleteInteractionCommand command, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: CRMConstants.DeleteInteractionExchangeName,
            exchangeType: CRMConstants.DefaultExchangeType,
            queueName: CRMConstants.DeleteInteractionQueueName,
            obj: new DeleteInteractionEvent()
            {
                CustomerId = command.CustomerId,
                UserId = command.UserId,
            });

        return await Task.FromResult(true);
    }
}
