using Bogus;
using CRM.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Common.Infrastructure;
using static Bogus.DataSets.Name;
using CRM.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Persistence.Context;

internal class SeedData
{
    private static List<User> GetUser()
    {

        var result = new Faker<User>("tr")
            .RuleFor(i => i.Id, i => Guid.NewGuid())
            .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.UtcNow.AddDays(-100), DateTime.UtcNow))
            .RuleFor(i => i.Username, i => i.Internet.UserName())
            .RuleFor(i => i.Password, i => PasswordEncryptor.Encrpt(i.Internet.Password()))
            .RuleFor(i=>i.Email, i=>i.Internet.Email())
            .RuleFor(i=>i.FirstName, i=>i.Person.FirstName)
            .RuleFor(i=>i.LastName, i=>i.Person.LastName)
            .RuleFor(i=>i.Role, i => i.PickRandom<Role>())
            .RuleFor(i => i.EmailConfirmed, i => i.PickRandom(true, false))
            .Generate(500);

        return result;

    }

    private static List<Customer> GetCustomer()
    {
        var result = new Faker<Customer>("tr")
            .RuleFor(i => i.Id, i => Guid.NewGuid())
            .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.UtcNow.AddDays(-100), DateTime.UtcNow))
            .RuleFor(i => i.FirstName, i => i.Person.FirstName)
            .RuleFor(i => i.LastName, i => i.Person.LastName)
            .RuleFor(i => i.Email, i => i.Internet.Email())
            .RuleFor(i => i.PhoneNumber, i => i.Phone.PhoneNumber())
            .RuleFor(i => i.Address, i => i.Address.FullAddress())
            .RuleFor(i => i.Company, i => i.Company.CompanyName())
            .RuleFor(i => i.Notes, i => i.Lorem.Sentence(10, 10))
            .Generate(250);

        return result;

    }

    public async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder();

        dbContextBuilder.UseNpgsql(configuration["CRMDbConnectionString"]);

        var context = new CRMDbContext(dbContextBuilder.Options);

        //if(context.Users.Any() && context.Customers.Any())
        //{
        //    await Task.CompletedTask;
        //    return;
        //}

        var users = GetUser();
        var userIds = users.Select(i => i.Id);

        await context.Users.AddRangeAsync(users);

        var customers = GetCustomer();
        var customerIds = customers.Select(i => i.Id);

        await context.Customers.AddRangeAsync(customers);

        var guids = Enumerable.Range(0, 200).Select(i => Guid.NewGuid()).ToList();
        var counter = 0;

        var contactInfo = new Faker<ContactInfo>("tr")
            .RuleFor(i => i.Id, i => guids[counter++])
            .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.UtcNow.AddDays(-100), DateTime.UtcNow))
            .RuleFor(i => i.ContactType, i => i.PickRandom<ContactType>())
            .RuleFor(i => i.ContactDetail, i => i.Lorem.Sentence(2, 5))
            .RuleFor(i => i.Preferred, i => i.PickRandom(true, false))
            .RuleFor(i => i.CustomerId, i => i.PickRandom(customerIds))            
            .Generate(50);

        await context.ContactInfos.AddRangeAsync(contactInfo);

        var customerTask = new Faker<CustomerTask>("tr")
           .RuleFor(i => i.Id, i => Guid.NewGuid())
           .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.UtcNow.AddDays(-100), DateTime.UtcNow))
           .RuleFor(i => i.Title, i => i.Lorem.Sentence(5, 5))
           .RuleFor(i => i.Description, i => i.Lorem.Paragraph(1))
           .RuleFor(i => i.DueDate, i => i.Date.Between(DateTime.UtcNow.AddDays(50), DateTime.UtcNow))
           .RuleFor(i => i.Status, i => i.PickRandom<Status>())
           .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
           .RuleFor(i => i.CustomerId, i => i.PickRandom(customerIds))
           .Generate(50);

        await context.CustomerTasks.AddRangeAsync(customerTask);

        var interaction = new Faker<Interaction>("tr")
           .RuleFor(i => i.Id, i => Guid.NewGuid())
           .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.UtcNow.AddDays(-100), DateTime.UtcNow))
           .RuleFor(i => i.Notes, i => i.Lorem.Paragraph(1))
           .RuleFor(i => i.Date, i => i.Date.Between(DateTime.UtcNow.AddDays(50), DateTime.UtcNow))
           .RuleFor(i => i.InteractionType, i => i.PickRandom<InteractionType>())
           .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
           .RuleFor(i => i.CustomerId, i => i.PickRandom(customerIds))
           .Generate(50);

        await context.Interactions.AddRangeAsync(interaction);

        var salesOpportunity = new Faker<SalesOpportunity>("tr")
           .RuleFor(i => i.Id, i => Guid.NewGuid())
           .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.UtcNow.AddDays(-100), DateTime.UtcNow))
           .RuleFor(i => i.OpportunityName, i => i.Lorem.Sentence(1, 2))
           .RuleFor(i => i.Description, i => i.Lorem.Paragraph(1))
           .RuleFor(i => i.CloseDate, i => i.Date.Between(DateTime.UtcNow.AddDays(50), DateTime.UtcNow))
           .RuleFor(i => i.Value, i => i.Random.Decimal(10.00M, 1000.00M))
           .RuleFor(i => i.Stage, i => i.PickRandom<Stage>())
           .RuleFor(i => i.CustomerId, i => i.PickRandom(customerIds))
           .Generate(50);

        await context.SalesOpportunities.AddRangeAsync(salesOpportunity);

        await context.SaveChangesAsync();

    }
}
