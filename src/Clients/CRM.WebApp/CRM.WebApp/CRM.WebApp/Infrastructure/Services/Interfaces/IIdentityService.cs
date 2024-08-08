using CRM.Common.Models.Queries;
using CRM.Common.Models.RequestModels;

namespace CRM.WebApp.Infrastructure.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<LoginUserViewModel> Login(LoginUserCommand command);
    }
}