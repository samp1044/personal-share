using FileShare.Main.Authentication.Web.Cookie;

namespace FileShare.Main.Authentication.Web;

public class AuthenticationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, ISession session)
    {
        var cookie = AuthenticationCookie.From(context);

        if (cookie.IsAuthenticated)
        {
            try
            {
                await session.LoadAsync(cookie.Token);
                cookie.UpdateWith(session);
            }
            catch (Exception)
            {
                cookie.Expire();
            }
            
            await next(context);
        }
    }
}