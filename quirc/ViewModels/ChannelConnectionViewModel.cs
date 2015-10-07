using quirc.Models;

namespace quirc.ViewModels
{
    public class ChannelConnectionViewModel
    {
        public ChannelConnection Connection { get; set; }

        public ChannelConnectionViewModel()
        {
            this.Connection = new ChannelConnection();
        }

        public string Username
        {
            get { return Connection.Username; }
            set { Connection.Username = value; }
        }

        public string Password
        {
            get { return Connection.UserPassword; }
            set { Connection.UserPassword = value; }
        }

        public string Channel
        {
            get { return Connection.Channel; }
            set { Connection.Channel = value; }
        }

        public string Server
        {
            get { return Connection.Server; }
            set { Connection.Server = value; }
        }

        public string Port
        {
            get { return Connection.Port; }
            set { Connection.Port = value; }
        }

        public string ChannelConnectionInfo()
        {
            return "Connected as " + Connection.Username + " to " + Connection.Channel; 
        }
    }
}
