using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Events.Interaction;

public class DeleteInteractionEvent
{
    public Guid CustomerId { get; set; }
    public Guid UserId { get; set; }
}
