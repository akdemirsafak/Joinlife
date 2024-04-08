using IdentityModel.Client;
using Joinlife.webui.Models.Auth;
using SharedLib.Dtos;

namespace Joinlife.webui.Core.Services;

public interface IIdentityService
{
    Task<TokenResponse> GetAccessTokenByRefreshToken();
    Task RevokeRefreshToken(); //kullanıcı çıkışında token'ın silinmesi.
    Task<AppResponse<bool>> SignInAsync(SigninInputModel loginInputModel);
    Task<AppResponse<bool>> SignUpAsync(SignupInputModel signUpInputModel);
}
