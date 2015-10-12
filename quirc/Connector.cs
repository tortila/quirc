using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatSharp;

namespace quirc
{
    class Connector : IConnector
    {
        public IrcClient Client;
        public IrcUser User;
        public IrcChannel PrimaryChannel;
        public void Connect()
        {
            User = new IrcUser("oliwia-quirc", "oliwia-quirc");
            Client = new IrcClient("irc.mizure.net:6667", User);
            Client.ConnectionComplete += (s, e) =>
            {
                Client.JoinChannel("#o");
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

        private DisplayMessageDelegate _displayMessageDelegate = null;

        public void SendMessage(string text)
        {
            this.DisplayMessage(new CompositeType(Client.User.Nick, text));
            Client.SendMessage(text, "#o");
        }

        public Connector(DisplayMessageDelegate dmd)
        {
            _displayMessageDelegate = dmd;
            this.Connect();
            this.ManageMessages();
        }
    }
}
