using CRM.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Domain.Models;

public class CustomerTask: BaseEntity
{
    public Guid UserId { get; set; }
    public Guid CustomerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Status Status { get; set; }

    public virtual User User { get; set; }
    public virtual Customer Customer { get; set; }
}
