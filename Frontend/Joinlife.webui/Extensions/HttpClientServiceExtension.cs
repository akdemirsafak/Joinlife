using Joinlife.webui.AuthOps;
using Joinlife.webui.Core.Services;
using Joinlife.webui.Handlers;
using Joinlife.webui.Services;
using Joinlife.webui.Settings;

namespace Joinlife.webui.Extensions;

public static class HttpClientServiceExtension
{
    public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        
        services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

        services.AddScoped<IIdentityService, IdentityService>();
        //IdentityService

        services.AddHttpClient<IIdentityService, IdentityService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.IdentityBaseUri}");
        });
        services.AddHttpClient<IUserService, UserService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.IdentityBaseUri}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();



        services.AddHttpClient<ICountryService, CountryService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Location.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();


        services.AddHttpClient<ICityService, CityService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Location.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();


        services.AddHttpClient<IVenueService, VenueService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Location.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IEventService, EventService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Event.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();


        services.AddHttpClient<ITicketService, TicketService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Event.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();
        
        services.AddHttpClient<IOrderService, OrderService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Order.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IFileService, FileService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.File.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IBasketService, BasketService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Basket.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IPaymentService, PaymentService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Payment.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<INotificationService, NotificationService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Notification.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

    }
}
