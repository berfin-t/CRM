using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Models.RequestModels;

public class CreateSalesOpportunityCommand:IRequest<Guid>
{
    public Guid CustomerId { get; set; }
    public string OpportunityName { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public Stage Stage { get; set; }
    public DateTime CloseDate { get; set; }
}
