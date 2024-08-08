using CRM.Common.Models.Queries;

namespace CRM.WebApp.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task<GetUserByUserIdViewModel> GetUserDetail(Guid? id);
    }
}