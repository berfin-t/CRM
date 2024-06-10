using AutoMapper;
using CRM.Api.Domain.Models;
using CRM.Common.Models.Queries;
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
    }
}
