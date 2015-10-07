namespace quirc.Models
{
    public class ChannelConnection
    {

        public ChannelConnection()
        {
            this.Username = "oliwia-kodzi";
            this.Channel = "#o";
            this.Server = "irc.mizure.net";
            this.Port = "6667";
            this.UserPassword = "";
        }

        public string Username { get; set; }
        public string Channel { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string UserPassword { get; set; }

    }
}