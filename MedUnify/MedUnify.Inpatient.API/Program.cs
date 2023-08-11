using MedUnify.Inpatient.API.Data;
using MedUnify.Inpatient.DAL;
using MedUnify.Inpatient.SharedModel.Settings;
using Microsoft.EntityFrameworkCore;

namespace MedUnify.Inpatient.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        // Add app services to the container.
        builder.Services.ConfigureDIResolver();
        builder.Services.AddDbContext<InpatientDbContext>();
        var entityConnections = builder.Configuration.GetSection(nameof(EntityConnections)).Get<EntityConnections>();
        builder.Services.AddSingleton(entityConnections);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var authSetting = builder.Configuration.GetSection(nameof(AuthSetting)).Get<AuthSetting>();
        builder.Services.AddAuthentication("Bearer").AddIdentityServerAuthentication("Bearer", options =>
         {
             options.ApiName = authSetting.ApiName;
             options.Authority = authSetting.IdentityServer;
         });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MyCorsPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
        });


        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors("MyCorsPolicy");
        using var serviceScope = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<InpatientDbContext>();
        context?.Database.Migrate();
        context?.SeedInitialData();

        app.MapControllers();

        app.Run();
    }
}