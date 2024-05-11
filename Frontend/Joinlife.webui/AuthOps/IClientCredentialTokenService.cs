namespace Joinlife.webui.AuthOps;

public interface IClientCredentialTokenService
{
    Task<string> GetToken();
}
