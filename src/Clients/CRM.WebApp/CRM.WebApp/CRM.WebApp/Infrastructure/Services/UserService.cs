using CRM.Common.Models.Queries;
using CRM.Common.Models;
using CRM.WebApp.Infrastructure.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace CRM.WebApp.Infrastructure.Services;

public class UserService : IUserService
{
    // Simulate data retrieval. Replace with actual data access logic.
    private readonly HttpClient client;

    public UserService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<GetUserByUserIdViewModel> GetUserDetail(Guid? id)
    {

        var userDetail = await client.GetFromJsonAsync<GetUserByUserIdViewModel>($"/api/User/UserDetail/{id}");

        return userDetail;

        //var httpResponse = await client.GetAsync($"/api/User/UserDetail/{id}");

        //if (httpResponse.IsSuccessStatusCode)
        //{
        //    var response = await httpResponse.Content.ReadAsStringAsync();

        //    if (string.IsNullOrWhiteSpace(response))
        //    {
        //        // Handle empty or invalid response
        //        return null; // or handle it accordingly
        //    }

        //    var userDetail = JsonSerializer.Deserialize<GetUserByUserIdViewModel>(response);
        //    return userDetail;
        //}
        //else
        //{
        //    // Handle non-success status codes
        //    return null; // or handle it accordingly
        //}
    }
}
