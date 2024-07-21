using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.SearchByCustomerTask;

public class SearchCustomerTaskQueryHandler:IRequestHandler<SearchCustomerTaskQuery, List<SearchCustomerTaskViewModel>>
{
    private readonly ICustomerTaskRepository customerTaskRepository;

    public SearchCustomerTaskQueryHandler(ICustomerTaskRepository customerTaskRepository)
    {
        this.customerTaskRepository = customerTaskRepository;
    }

    public async Task<List<SearchCustomerTaskViewModel>> Handle(SearchCustomerTaskQuery request, CancellationToken cancellationToken)
    {
        var result = customerTaskRepository
            .Get(i => i.Title.ToLower().StartsWith(request.SearchText.ToLower()))
            .Select(i => new SearchCustomerTaskViewModel()
            {
                Id = i.Id,
                Title = i.Title,
            });

        return await result.ToListAsync(cancellationToken);

    }
}
