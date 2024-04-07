using Joinlife.webui.Core.Services;
using Joinlife.webui.Services;
using Joinlife.webui.Settings;

namespace Joinlife.webui.Extensions;

public static class HttpClientServiceExtension
{
    public static void AddHttpClientServices(this IServiceCollection services,IConfiguration configuration)
    {
        var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        services.AddHttpClient<ICountryService, CountryService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Location.Path}");
        });


        services.AddHttpClient<ICityService, CityService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Location.Path}");
        });

        services.AddHttpClient<ICountryService, CountryService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Location.Path}");
        });

        services.AddHttpClient<IVenueService, VenueService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Location.Path}");
        });

        services.AddHttpClient<IEventService, EventService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Event.Path}");
        });
        services.AddHttpClient<ITicketService, TicketService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Location.Path}");
        });
        services.AddHttpClient<IOrderService, OrderService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Order.Path}");
        });


    }
}
