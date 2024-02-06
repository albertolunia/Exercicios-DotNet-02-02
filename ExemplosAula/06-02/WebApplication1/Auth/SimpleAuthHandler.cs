using System.Text;

namespace WebAPI_SimpleAuthExample.Auth;
public class SimpleAuthHandler
{
    private readonly RequestDelegate _next;
    public SimpleAuthHandler(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        if(!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.Headers.Add("WWW-Authenticate", "Basic");
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authorization header is missing");
            return;
        }
        var Header = context.Request.Headers["Authorization"].ToString();
        var encondedUsernamePassword = Header.Substring(6);
        var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encondedUsernamePassword));
        string[] usernamePasswordArray = decodedUsernamePassword.Split(":");
        var username = usernamePasswordArray[0];
        var password = usernamePasswordArray[1];
        
        if(username != "admin" || password != "admin")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid username or password");
            return;
        }        



        await _next(context);
    }
}
