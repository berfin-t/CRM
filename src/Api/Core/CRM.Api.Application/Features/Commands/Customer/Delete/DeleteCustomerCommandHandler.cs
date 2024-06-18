using CRM.Common;
using CRM.Common.Events.Customer;
using CRM.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.Customer.Delete;

public class DeleteCustomerCommandHandler:IRequestHandler<DeleteCustomerCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: CRMConstants.DeleteCustomerExchangeName,
            exchangeType: CRMConstants.DefaultExchangeType,
            queueName: CRMConstants.DeleteCustomerQueueName,
            obj: new DeleteCustomerEvent()
            {
                Id = command.Id
            });

        return await Task.FromResult(true);
    }
}
