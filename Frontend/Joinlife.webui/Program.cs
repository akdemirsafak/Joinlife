using Joinlife.webui.AuthOps;
using Joinlife.webui.Core.Services;
using Joinlife.webui.Extensions;
using Joinlife.webui.Handlers;
using Joinlife.webui.Services;
using Joinlife.webui.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using SharedLib.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc().AddViewOptions(options =>
{
    options.HtmlHelperOptions.ClientValidationEnabled = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Auth/SignIn";
        opt.ExpireTimeSpan = TimeSpan.FromDays(60); //Cookie life refresh token 60 gün olduğu için burada da 60 yaptık.
        opt.SlidingExpiration = true; //Her giriş yapıldığında cookie ömrü uzasın 
        opt.Cookie.Name = "webCookie";
    }); //Service'lerde bu kısımda jwt ile kullanıcı doğrulama yapıyorduk burada ise cookie ile.



builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddAccessTokenManagement();

builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IVenueService, VenueService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddScoped<IIdentitySharedService, IdentitySharedService>();

builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddScoped<IClientCredentialTokenService, ClientCredentialTokenService>();




builder.Services.AddHttpClientServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
