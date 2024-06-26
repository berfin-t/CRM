using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Models.Queries;

public class GetCustomerTaskDetailViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Status Status { get; set; }

    public string CreatedByUserName { get; set; }
    public string CustomerName { get; set; }
}
