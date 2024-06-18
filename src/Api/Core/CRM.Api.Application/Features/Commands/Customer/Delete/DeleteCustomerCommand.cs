using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Commands.Customer.Delete;

public class DeleteCustomerCommand:IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteCustomerCommand(Guid ıd)
    {
        Id = ıd;
    }
}
