namespace Joinlife.webui.Settings
{
    public class ServiceApiSettings
    {
        public string GatewayUrl { get; set; }
        public string IdentityBaseUri { get; set; }
        public ServiceApi Event { get; set; }
        public ServiceApi Location { get; set; }
        public ServiceApi Order { get; set; }
        public ServiceApi File { get; set; }
        public ServiceApi Basket { get; set; }
        public ServiceApi Payment { get; set; }
        public ServiceApi Notification { get; set; }
    }
    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
