using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Models.Queries;

public class GetInteractionByCustomerIdViewModel
{
    public Guid CustomerId { get; set; }
    public InteractionType InteractionType { get; set; }
    public DateTime Date {  get; set; }
    public string Notes { get; set; }

}
