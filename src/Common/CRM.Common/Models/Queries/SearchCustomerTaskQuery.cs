using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Models.Queries;

public class SearchCustomerTaskQuery:IRequest<List<SearchCustomerTaskViewModel>>
{
    public SearchCustomerTaskQuery(string searchText)
    {
        searchText = searchText;
    }
    public SearchCustomerTaskQuery() { }
    public string SearchText { get; set; }
}
