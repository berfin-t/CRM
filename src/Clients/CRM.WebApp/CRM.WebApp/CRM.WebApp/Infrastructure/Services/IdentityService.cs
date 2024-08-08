using Blazored.LocalStorage;
using CRM.Common.Infrastructure.Exceptions;
using CRM.Common.Infrastructure.Results;
using CRM.Common.Models.Queries;
using CRM.Common.Models.RequestModels;
using CRM.WebApp.Infrastructure.Auth;
using CRM.WebApp.Infrastructure.Extensions;
using CRM.WebApp.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace CRM.WebApp.Infrastructure.Services;

public class IdentityService : IIdentityService
{
    private JsonSerializerOptions defaultJsonOpt => new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly HttpClient httpClient;
    private readonly ISyncLocalStorageService syncLocalStorageService;
    private readonly AuthenticationStateProvider authenticationStateProvider;

    public IdentityService(HttpClient httpClient, ISyncLocalStorageService syncLocalStorageService, AuthenticationStateProvider authenticationStateProvider)
    {
        this.httpClient = httpClient;
        this.syncLocalStorageService = syncLocalStorageService;
        this.authenticationStateProvider = authenticationStateProvider;
    }

    public bool IsLoggedIn => !string.IsNullOrEmpty(GetUserToken());

    public string GetUserToken()
    {
        return syncLocalStorageService.GetToken();
    }

    public string GetUserName()
    {
        return syncLocalStorageService.GetToken();
    }

    public Guid GetUserId()
    {
        return syncLocalStorageService.GetUserId();
    }

    public async Task<LoginUserViewModel> Login(LoginUserCommand command)
    {
        string responseStr;
        var httpResponse = await httpClient.PostAsJsonAsync("/api/User/Login", command);

        //var jsonString = "{\"Email\":\"Borlukcu_Tutuncu@gmail.com\", \"Password\":\"string12345\"}";
        //HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        //var httpResponse = await httpClient.PostAsync("/api/User/Login", content);

        if (httpResponse != null && !httpResponse.IsSuccessStatusCode)
        {
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                responseStr = await httpResponse.Content.ReadAsStringAsync();
                var validation = JsonSerializer.Deserialize<ValidationResponseModel>(responseStr, defaultJsonOpt);
                responseStr = validation.FlattenErrors;
                throw new DatabaseValidationException(responseStr);
            }

            return null;
        }

        responseStr = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<LoginUserViewModel>(responseStr);

        if (!string.IsNullOrEmpty(response.Token)) // login success
        {
            syncLocalStorageService.SetToken(response.Token);
            syncLocalStorageService.SetUsername(response.UserName);
            syncLocalStorageService.SetUserId(response.Id);

            ((AuthStateProvider)authenticationStateProvider).NotifyUserLogin(response.UserName, response.Id);

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", response.Token);

            return response;
        }

        return null;
    }


    //public void Logout()
    //{
    //    syncLocalStorageService.RemoveItem(LocalStorageExtension.TokenName);
    //    syncLocalStorageService.RemoveItem(LocalStorageExtension.UserName);
    //    syncLocalStorageService.RemoveItem(LocalStorageExtension.UserId);

    //    ((AuthStateProvider)authenticationStateProvider).NotifyUserLogout();
    //    httpClient.DefaultRequestHeaders.Authorization = null;
    //}
}
