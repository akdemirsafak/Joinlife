using FluentValidation;
using Location.Application;
using Location.Application.Behaviors;
using Location.Application.Services;
using Location.Persistance.DbContexts;
using Location.Persistance.Interceptors;
using Location.Persistance.Repositories;
using Location.Persistance.Services;
using Location.Persistance.UnitOfWorks;
using Location.Presentation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter());
})
    .AddApplicationPart(typeof(PresentationAssemblyReference).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"];
    opt.Audience = "location_resource";
    opt.RequireHttpsMetadata = true;
});




builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
});

string mssqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;


builder.Services.AddSingleton<AuditInterceptor>();

builder.Services.AddDbContext<LocationDbContext>((sp,opt) =>
{
    var auditInterceptor=sp.GetService<AuditInterceptor>()!;
    opt.UseSqlServer(mssqlConnectionString,
        option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(LocationDbContext))!.GetName().Name);
        });
    opt.AddInterceptors(auditInterceptor);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IVenueService, VenueService>();

builder.Services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
