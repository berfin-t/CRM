using CRM.Common.Models;
using CRM.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Features.Queries.GetSalesOpportunitiesByStage;

public class GetSalesOpportunitiesByStageQuery:IRequest<List<GetSalesOpportunitiesByStageViewModel>>
{
    public Stage Stage { get; set; }

    public GetSalesOpportunitiesByStageQuery(Stage stage)
    {
        Stage = stage;
    }
}
