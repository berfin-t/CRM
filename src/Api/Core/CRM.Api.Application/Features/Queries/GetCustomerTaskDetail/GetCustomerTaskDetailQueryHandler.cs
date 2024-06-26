using CRM.Api.Application.Interfaces.Repositories;
using CRM.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetCustomerTaskDetail;

public class GetCustomerTaskDetailQueryHandler:IRequestHandler<GetCustomerTaskDetailQuery, GetCustomerTaskDetailViewModel>
{
    private readonly ICustomerTaskRepository customerTaskRepository;

    public GetCustomerTaskDetailQueryHandler(ICustomerTaskRepository customerTaskRepository)
    {
        this.customerTaskRepository = customerTaskRepository;
    }

    public async Task<GetCustomerTaskDetailViewModel> Handle(GetCustomerTaskDetailQuery request, CancellationToken cancellationToken)
    {
        var query = customerTaskRepository.AsQueryable();

        query = query.Include(i => i.User)
            .Where(i => i.CustomerId == request.CustomerId);

        var guid = query.Select(i => new GetCustomerTaskDetailViewModel()
        {
            Id = i.Id,
            Title = i.Title,
            Description = i.Description,
            DueDate = i.DueDate,
            Status = i.Status,
            CreatedByUserName = i.User.Username,
            CustomerName = i.Customer.FirstName + " " + i.Customer.LastName

        });

        return await guid.FirstOrDefaultAsync(cancellationToken:  cancellationToken);
    }
}
