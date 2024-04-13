using Joinlife.webui.ViewModels.User;

namespace Joinlife.webui.Core.Services;

public interface IUserService
{
    Task<UserViewModel> GetUserAsync();
}
