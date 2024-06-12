using CRM.Api.Application.Interfaces.Repositories;
using CRM.Api.Domain.Models;
using CRM.Api.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Persistence.Repositories;

public class EmailConfirmationRepository: GenericRepository<EmailConfirmation>, IEmailConfirmationRepository
{
    public EmailConfirmationRepository(CRMDbContext dbContext) : base(dbContext)
    {

    }
}
