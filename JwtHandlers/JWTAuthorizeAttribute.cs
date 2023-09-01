using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ToDoList;

public class JwtAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    override
    public void OnAuthorization(AuthorizationContext filterContext)
    {
        string token = filterContext.HttpContext.Request.Cookies["jwtToken"]?.Value;

        if (string.IsNullOrEmpty(token) || !TokenManager.ValidateToken(token))
        {
            HttpCookie jwtCookie = new HttpCookie("jwtToken")
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            
            filterContext.HttpContext.Response.Cookies.Add(jwtCookie);

            IAuthenticationManager authenticationManager = filterContext.HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.AppendCacheExtension("no-store, must-revalidate");
            
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new
                {
                    action = "Login",
                    controller = "Account",
                    returnUrl = "/"
                }
            ));
        }
    }
}
