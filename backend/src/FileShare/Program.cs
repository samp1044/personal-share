namespace FileShare.Main;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();
        
        var app = builder.Build();
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthentication();
        app.MapControllers().RequireAuthorization();
        
        app.Run();
    }
}