using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Common.Models;

namespace CRM.Api.Domain.Models;

public class ContactInfo: BaseEntity
{
    public Guid CustomerId { get; set; }
    public ContactType ContactType { get; set; }
    public string ContactDetail { get; set; }
    public bool Preferred { get; set; }

    public virtual Customer Customer { get; set; }
}
