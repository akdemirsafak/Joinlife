using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Payment.API.Services;
using SharedLib.Auth;
using SharedLib.Messages;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"];
    opt.Audience = "payment_resource";
    opt.RequireHttpsMetadata = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IIdentitySharedService, IdentitySharedService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddMassTransit(x =>
{
    // Default Port : 5672
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["Rabbitmq:Host"], "/", host =>
        {
            host.Username(builder.Configuration["Rabbitmq:Username"]);
            host.Password(builder.Configuration["Rabbitmq:Password"]);
        });
    });
    EndpointConvention.Map<CreateOrderNotificationMessageCommand>(new Uri("queue:create-order-notification-service"));
    EndpointConvention.Map<CreateOrderMessageCommand>(new Uri("queue:create-order-service"));
   
});
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));//
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




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
