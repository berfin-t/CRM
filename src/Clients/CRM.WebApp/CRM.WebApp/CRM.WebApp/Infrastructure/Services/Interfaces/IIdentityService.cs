using CRM.Common.Models.RequestModels;

namespace CRM.WebApp.Infrastructure.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> Login(LoginUserCommand command);
    }
}