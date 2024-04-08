namespace Joinlife.webui.Settings
{
    public class ServiceApiSettings
    {
        public string GatewayUrl { get; set; }
        public ServiceApi Event { get; set; }
        public ServiceApi Location { get; set; }
        public ServiceApi Order { get; set; }
        public ServiceApi Ticket { get; set; }
    }
    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
