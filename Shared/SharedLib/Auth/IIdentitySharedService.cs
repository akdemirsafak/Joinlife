namespace SharedLib.Auth
{
    public interface IIdentitySharedService
    {
        public string GetUserId { get; }
        public string GetUserMail { get; }
    }
}
