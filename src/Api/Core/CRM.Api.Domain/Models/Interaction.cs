using CRM.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Domain.Models;

public class Interaction: BaseEntity
{
    public Guid CustomerId { get; set; }
    public Guid UserId { get; set; }
    public InteractionType InteractionType {  get; set; }
    public DateTime Date {  get; set; }
    public string Notes { get; set; }

    public Customer Customer { get; set; }
    public User User { get; set; }
}
