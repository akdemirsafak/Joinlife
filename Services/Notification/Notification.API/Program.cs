using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Notification.API.Consumers;
using Notification.API.Services;
using Notification.API.Settings;
using SharedLib.Auth;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IIdentitySharedService, IdentitySharedService>();
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"];
    opt.Audience = "notification_resource";
    opt.RequireHttpsMetadata = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddMassTransit(options =>
{
    options.AddConsumer<CreateOrderNotificationMessageCommandConsumer>();
    options.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["Rabbitmq:Host"], "/", host =>
        {
            host.Username(builder.Configuration["Rabbitmq:Username"]);
            host.Password(builder.Configuration["Rabbitmq:Password"]);
        });
        cfg.ReceiveEndpoint("create-order-notification-service", e =>
        {
            e.ConfigureConsumer<CreateOrderNotificationMessageCommandConsumer>(context);
        });
    });

});

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
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

app.MapControllers();

app.Run();