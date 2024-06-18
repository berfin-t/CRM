using CRM.Common;
using CRM.Common.Events.SalesOpportunity;
using CRM.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.SalesOpportunity.Delete;

public class DeleteSalesOpportunityCommandHandler:IRequestHandler<DeleteSalesOpportunityCommand, bool>
{
    public async Task<bool> Handle(DeleteSalesOpportunityCommand command, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: CRMConstants.DeleteSalesOpportunityExchangeName,
            exchangeType: CRMConstants.DefaultExchangeType,
            queueName: CRMConstants.DeleteSalesOpportunityQueueName,
            obj: new DeleteSalesOpportunityEvent()
            {
                CustomerId = command.CustomerId
            });

        return await Task.FromResult(true);
    }
}
