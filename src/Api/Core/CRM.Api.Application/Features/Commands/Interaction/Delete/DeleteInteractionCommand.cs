using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.Interaction.Delete;

public class DeleteInteractionCommand:IRequest<bool>
{
    public Guid CustomerId { get; set; }
    public Guid UserId { get; set; }

    public DeleteInteractionCommand(Guid customerId, Guid userId)
    {
        CustomerId = customerId;
        UserId = userId;
    }
}
