using FileShare.Main.Authentication;
using FileShare.Main.Authentication.AspNetIdentityAuthenticationProvider;
using FileShare.Main.Authentication.Commands;
using FileShare.Main.Authentication.Persistence;
using FileShare.Main.Authentication.SessionManagement;
using FileShare.Main.Authentication.WebApi.Cookie;
using ISession = FileShare.Main.Authentication.ISession;
using FileShare.Main.Shared;

namespace FileShare.Main;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();
        
        builder.Services.AddScoped<ICommandHandler<AuthenticateCommand>, AuthenticateCommandHandler>();
        builder.Services.AddScoped<ISession, Session>();
        builder.Services.AddScoped<ISessionRepository, SessionRepository>();
        builder.Services.AddScoped<IAuthenticationProvider, AspNetIdentityAuthenticationProvider>();
        
        var app = builder.Build();
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthentication();
        app.UseMiddleware<CookieAuthenticationMiddleware>();
        app.MapControllers().RequireAuthorization();
        
        app.Run();
    }
}