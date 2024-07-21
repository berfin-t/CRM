using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Domain.Models;

public class Customer: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Company { get; set; }
    public string Notes { get; set; }

    public virtual ICollection<SalesOpportunity> SalesOpportunities { get; set; }
    public virtual ICollection<CustomerTask> CustomerTasks { get; set; }
    public virtual ICollection<Interaction> Interactions { get; set; }
}
