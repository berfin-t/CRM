using CRM.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Persistence.EntityConfigurations;

public class InteractionConfiguration:BaseEntityConfiguration<Interaction>
{
    public override void Configure(EntityTypeBuilder<Interaction> builder)
    {
        base.Configure(builder);

        builder.ToTable("interaction", Context.CRMDbContext.DEFAULT_SCHEMA);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Interactions)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Interactions)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
