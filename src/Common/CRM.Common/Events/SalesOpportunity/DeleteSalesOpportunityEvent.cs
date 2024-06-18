using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Events.SalesOpportunity;

public class DeleteSalesOpportunityEvent
{
    public Guid CustomerId { get; set; }
}
