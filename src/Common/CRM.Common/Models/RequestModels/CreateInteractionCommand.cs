using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Models.RequestModels;

public class CreateInteractionCommand:IRequest<Guid>
{
    public Guid CustomerId { get; set; }
    public Guid UserId { get; set; }

    public CreateInteractionCommand(Guid customerId, Guid userId)
    {
        CustomerId = customerId;
        UserId = userId;
    }
}
