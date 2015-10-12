using quirc.Pages;

namespace quirc.Models
{
    public class ChannelConnection
    {
        
        public string Username { get; set; }
        public string Channel { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string UserPassword { get; set; }
        public Connector ChannelConnector { get; set; }

    }
}