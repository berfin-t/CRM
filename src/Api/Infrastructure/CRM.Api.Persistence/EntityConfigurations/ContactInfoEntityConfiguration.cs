using CRM.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Persistence.EntityConfigurations;

public class ContactInfoEntityConfiguration : BaseEntityConfiguration<ContactInfo>
{
    public override void Configure(EntityTypeBuilder<ContactInfo> builder)
    {
        base.Configure(builder);

        builder.ToTable("contactinfo", Context.CRMDbContext.DEFAULT_SCHEMA);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.ContactInfos)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
