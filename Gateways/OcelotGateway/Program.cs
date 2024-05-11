using CacheManager.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("GatewayAuthenticationScheme", opt => //Bu scheme name config dosyasında hangi root'a eklersek o token ile korunacak.
    {
        opt.Authority = builder.Configuration["IdentityServerURL"];
        opt.Audience = "gateway_resource";
        opt.RequireHttpsMetadata = true;
    });


string logdbConnectionString=builder.Configuration.GetConnectionString("LogDbConnection");
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .Enrich.FromLogContext()
    .WriteTo.Seq("http://localhost:5341/")
    .WriteTo.MSSqlServer(logdbConnectionString, tableName: "Logs", autoCreateSqlTable: true)
    .WriteTo.File("logs/myBeatifulLog-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();


builder.Services.AddHttpContextAccessor();

builder.Services
    .AddOcelot().AddCacheManager(x =>
    {
        x.WithRedisConfiguration("redis", (config) =>
        {
            config.WithAllowAdmin();
            config.WithEndpoint("localhost", 6379);
            config.WithDatabase(0);
        })
        .WithJsonSerializer()
        .WithRedisCacheHandle("redis");
    });

builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName}.json")
    .AddEnvironmentVariables();



var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSerilogRequestLogging();

await app.UseOcelot();

app.Run();
