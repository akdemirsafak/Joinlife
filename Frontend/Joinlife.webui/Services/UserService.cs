using Joinlife.webui.Core.Services;
using Joinlife.webui.ViewModels.User;
using SharedLib.Dtos;

namespace Joinlife.webui.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserViewModel> GetUserAsync()
    {
        var clientResult=await _httpClient.GetFromJsonAsync<UserViewModel>("api/auth"); //case sensitive değil. BURASI IDENTITYSERVER4 CONTROLLER'DA BELIRLEDIGIMIZ ENDPOINT
        //Burada req. token eklemedik.Bunun yerine handle edeceğiz ve otomatik eklemesini sağlayacağız. 
       
        return clientResult;
    }
}
