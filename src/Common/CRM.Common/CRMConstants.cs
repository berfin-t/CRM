using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common;

public class CRMConstants
{
    public const string RabbitMQHost = "localhost";
    public const string DefaultExchangeType = "direct";

    public const string UserExchangeName = "UserExchange";
    public const string UserEmailChangedQueueName = "UserEmailChangedQueue";

    public const string DeleteCustomerExchangeName = "DeleteCustomerExchange";
    public const string DeleteCustomerQueueName = "DeleteCustomerQueue";

    public const string DeleteCustomerTaskExchangeName = "DeleteCustomerTaskExchange";
    public const string DeleteCustomerTaskQueueName = "DeleteCustomerTaskQueue";

    public const string DeleteInteractionExchangeName = "DeleteInteractionExchange";
    public const string DeleteInteractionQueueName = "DeleteInteractionQueue";

    public const string DeleteSalesOpportunityExchangeName = "DeleteSalesOpportunityExchange";
    public const string DeleteSalesOpportunityQueueName = "DeleteSalesOpportunityQueue";


}
