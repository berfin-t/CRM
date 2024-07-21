using AutoMapper;
using CRM.Api.Application.Features.Queries.GetCustomers;
using CRM.Api.Domain.Models;
using CRM.Common.Models.Queries;
using CRM.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Mapping;

public class MapProfile: Profile
{
    public MapProfile() 
    { 
        CreateMap<User,LoginUserViewModel>().ReverseMap();
        CreateMap<CreateCustomerCommand, Customer>().ReverseMap();
        CreateMap<CreateCustomerTaskCommand, CustomerTask>().ReverseMap();
        CreateMap<CreateInteractionCommand , Interaction>().ReverseMap();
        CreateMap<CreateSalesOpportunityCommand, SalesOpportunity>().ReverseMap();
        CreateMap<Customer, GetCustomersViewModel>().ReverseMap();
        CreateMap<SalesOpportunity, GetSalesOpportunitiesByCustomerIdViewModel>().ReverseMap();
        CreateMap<SalesOpportunity, GetSalesOpportunitiesByStageViewModel>().ReverseMap();
        CreateMap<Interaction, GetInteractionByCustomerIdViewModel>().ReverseMap();
        CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
        CreateMap<SalesOpportunity, UpdateSalesOpportunityCommand>().ReverseMap();
        CreateMap<CustomerTask, UpdateCustomerTaskCommand>().ReverseMap();
        CreateMap<Interaction, UpdateInteractionCommand>().ReverseMap();
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, GetUserByUserIdViewModel>().ReverseMap();

    }
}
