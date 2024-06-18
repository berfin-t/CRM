using CRM.Common;
using CRM.Common.Events.CustomerTask;
using CRM.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.CustomerTask.Delete;

public class DeleteCustomerTaskCommandHandler:IRequestHandler<DeleteCustomerTaskCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerTaskCommand command, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: CRMConstants.DeleteCustomerTaskExchangeName,
            exchangeType: CRMConstants.DefaultExchangeType,
            queueName: CRMConstants.DeleteCustomerTaskQueueName,
            obj: new DeleteCustomerTaskEvent()
            {
                UserId = command.UserId,
                CustomerId = command.CustomerId
            });

        return await Task.FromResult(true);
    }
}
