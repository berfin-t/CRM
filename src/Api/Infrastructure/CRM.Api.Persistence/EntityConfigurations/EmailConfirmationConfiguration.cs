using CRM.Api.Domain.Models;
using CRM.Api.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Persistence.EntityConfigurations;

public class EmailConfirmationConfiguration: BaseEntityConfiguration<EmailConfirmation>
{
    public override void Configure(EntityTypeBuilder<EmailConfirmation> builder)
    {
       base.Configure(builder);

        builder.ToTable("emailconfirmation", CRMDbContext.DEFAULT_SCHEMA);
    }
}
