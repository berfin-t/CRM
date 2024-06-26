using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRM.Api.WebApi.Controllers;

public class BaseController : ControllerBase
{
    //public Guid? UserId => new(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

    public Guid? UserId
    {
        get
        {
            var val = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return val is null ? null : new Guid(val);
        }
    }
}
