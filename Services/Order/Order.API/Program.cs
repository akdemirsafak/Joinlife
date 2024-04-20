using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Repositories;
using Order.Domain.Services;
using Order.Repository.DbContexts;
using Order.Repository.Repositories;
using Order.Service.Consumers;
using Order.Service.Services;
using SharedLib.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//requireAuthorizePolicy
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"];
    opt.Audience = "order_resource";
    opt.RequireHttpsMetadata = true;
});


builder.Services.AddScoped<IIdentitySharedService, IdentitySharedService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});


builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(OrderDbContext))!.GetName().Name);
    });
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();



builder.Services.AddMassTransit(setting =>
{
    setting.AddConsumer<CreateOrderMessageCommandConsumer>();
    //Catalog exchange'e gönderir. Exchange'deki mesajı alabilmemiz için queue oluşturmamız gerekir.Bu işlemi masstransit bizim için yapıyor.

    //Default port :5672
    setting.UsingRabbitMq((context, configuration) =>
    {
        configuration.Host(builder.Configuration["Rabbitmq:Host"], "/", host =>
        {
            host.Username(builder.Configuration["Rabbitmq:Username"]);
            host.Password(builder.Configuration["Rabbitmq:Password"]);
        });
        configuration.ReceiveEndpoint("create-order-service", e =>
        {
            e.ConfigureConsumer<CreateOrderMessageCommandConsumer>(context);
        });
    });
});

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
