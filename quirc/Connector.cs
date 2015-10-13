using System;
using ChatSharp;

namespace quirc
{
    public class Connector : IConnector
    {
        public IrcClient Client;
        public IrcUser User;
        public IrcChannel PrimaryChannel;
        public void Connect(string u, string c, string server, string p)
        {
            User = new IrcUser(u, u);
            Client = new IrcClient(server + ":" + p, User);
            Client.ConnectionComplete += (s, e) =>
            {
                Client.JoinChannel(c);
            };
            Client.ConnectAsync();
        }

        public void ManageMessages()
        {
            Client.ChannelMessageRecieved += (s, e) =>
            {
                this.DisplayMessage(new CompositeType(e.PrivateMessage.User.Nick, e.PrivateMessage.Message));
            };
        }

        public void DisplayMessage(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (_displayMessageDelegate != null)
            {
                    _displayMessageDelegate(composite);
            }
        }

        DisplayMessageDelegate _displayMessageDelegate = null;
        public void SendMessage(string text)
        {
            this.DisplayMessage(new CompositeType(Client.User.Nick, text));
            Client.SendMessage(text, Client.Channels[0].Name);
        }

        public Connector(DisplayMessageDelegate dmd)
        {
            _displayMessageDelegate = new DisplayMessageDelegate(dmd);
        }
    }
}
