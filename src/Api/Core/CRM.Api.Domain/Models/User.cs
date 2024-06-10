using CRM.Common.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Domain.Models;

public class User: BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Role Role { get; set; }
    public bool EmailConfirmed { get; set; }

    public virtual ICollection<CustomerTask> CustomerTasks { get; set; }
    public virtual ICollection<Interaction> Interactions { get; set; }

}
