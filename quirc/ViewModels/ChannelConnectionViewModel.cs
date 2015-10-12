using System;
using System.Windows;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using quirc.Models;

namespace quirc.ViewModels
{
    public class ChannelConnectionViewModel
    {
        public ChannelConnection Connection { get; set; }
        public DisplayMessageDelegate Dmd { get; set; }

        public ChannelConnectionViewModel()
        {
            this.Connection = new ChannelConnection();
            LoginCommand = new RelayCommand(param => LoginExecute(), param => CanExecuteLoginCommand);
            this.Username = "oliwia-testuje";
            this.Channel = "#o";
            this.Server = "irc.mizure.net";
            this.Port = "6667";
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

            Console.WriteLine("Starting connection: " + Username + Channel + "/" + Server + ":" + Port);

            Connection.ChannelConnector = new Connector(Dmd);
            Connection.ChannelConnector.Connect(Username, Channel, Server, Port);
            Connection.ChannelConnector.ManageMessages();
        }

        public ICommand LoginCommand { get; set; }

        private bool FieldsNotEmpty
        {
            get
            {
                return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Server) && !string.IsNullOrEmpty(Channel);
            }
        }

        private bool CanExecuteLoginCommand
        {
            get { return FieldsNotEmpty; }
        }

        public void LoginExecute()
        {
            this.StartConnection();
        }

        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }
    }
}
