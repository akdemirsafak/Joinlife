using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.Tickets;
using SharedLib.Dtos;

namespace Joinlife.webui.Services;

public class TicketService : ITicketService
{
    private readonly HttpClient _httpClient;

    public TicketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TicketViewModel> CreateAsync(CreateTicketInput createTicketInput)
    {
        var serviceResponse = await _httpClient.PostAsJsonAsync("ticket",createTicketInput);
        if (serviceResponse.IsSuccessStatusCode)
        {
            var ticketViewModel = await serviceResponse.Content.ReadFromJsonAsync<AppResponse<TicketViewModel>>();
            return ticketViewModel.Data;
        }
        return null;
    }

    public async Task<TicketViewModel> GetById(Guid ticketId)
    {
        var serviceResponse = await _httpClient.GetAsync($"ticket/{ticketId}");
        if (serviceResponse.IsSuccessStatusCode)
        {
            var ticketViewModel = await serviceResponse.Content.ReadFromJsonAsync<AppResponse<TicketViewModel>>();
            return ticketViewModel.Data;
        }
        return null;
    }

    public async Task<List<TicketViewModel>> GetEventTickets(Guid eventId)
    {
        var serviceResponse= await _httpClient.GetAsync($"ticket/event/{eventId}");
        if (serviceResponse.IsSuccessStatusCode)
        {
            var ticketViewModel = await serviceResponse.Content.ReadFromJsonAsync<AppResponse<List<TicketViewModel>>>();
            return ticketViewModel.Data;
        }
        return null;
    }

    public async Task<TicketViewModel> UpdateAsync(UpdateTicketInput updateTicketInput)
    {
        var serviceResponse = await _httpClient.PutAsJsonAsync("ticket", updateTicketInput);
        if (serviceResponse.IsSuccessStatusCode)
        {
            var ticketViewModel =await  serviceResponse.Content.ReadFromJsonAsync<AppResponse<TicketViewModel>>();
            return ticketViewModel.Data;
        }
        return null;
    }
}
