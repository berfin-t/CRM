using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Events.Customer;

public class DeleteCustomerEvent
{
    public Guid Id { get; set; }
}
