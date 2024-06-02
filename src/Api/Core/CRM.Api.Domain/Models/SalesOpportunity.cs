using CRM.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Domain.Models;

public class SalesOpportunity: BaseEntity
{
    public Guid CustomerId { get; set; }
    public string OpportunityName {  get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public Stage Stage { get; set; }
    public DateTime CloseDate { get; set; }

    public virtual Customer Customer { get; set; }

}
