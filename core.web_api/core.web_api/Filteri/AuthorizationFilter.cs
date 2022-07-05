using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using servisi.web_api.IServisi.User;

namespace core.web_api.Filteri;
public class AuthorizationFilter : IAuthorizationFilter
{
    private ILogger _logger;
    private IAuthServis authServis;

    public AuthorizationFilter(ILogger logger,IAuthServis authServis)
    {
        _logger = logger;
        this.authServis = authServis;
    }

    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.ActionDescriptor.DisplayName.Contains("AuthController") && !context.ActionDescriptor.DisplayName.Contains("ValutaController"))
        {

            var res = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                res = false;

            string token = string.Empty;

            if (res)
            {
                token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
                if (!await authServis.verifyToken(token))
                    res = false;
            }

            if (!res)
            {
                context.ModelState.AddModelError("Unauthroized", "You are not authorized");
                //not following the dictionary convection
                context.Result = new JsonResult(context.ModelState);
            }
        }
    }
}

