using System;
using quirc.Models;

namespace quirc.ViewModels
{
    public class ChannelConnectionViewModel
    {
        public ChannelConnection Connection { get; set; }
        public DisplayMessageDelegate Dmd;

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

        public void ConnectorSendMessage(string text)
        {
            if (Connection.ChannelConnector != null)
            {
                Connection.ChannelConnector.SendMessage(text);
            }
        }

        public void StartConnection()
        {
            Connection.Username = this.Username;
            Connection.Channel = this.Channel;
            Connection.Server = this.Server;
            Connection.Port = this.Port;

            Connection.ChannelConnector = new Connector(Dmd);
            Connection.ChannelConnector.Connect(Username, Channel, Server, Port);
            Connection.ChannelConnector.ManageMessages();
        }

    }
}
