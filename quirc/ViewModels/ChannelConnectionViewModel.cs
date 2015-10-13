using System;
using System.Windows;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using quirc.Models;

namespace quirc.ViewModels
{
    public class ChannelConnectionViewModel
    {
        //public ChannelConnection Connection { get; set; }
        public Connector ChannelConnector;
        public DisplayMessageDelegate Dmd { get; set; }

        public ChannelConnectionViewModel()
        {
            LoginCommand = new RelayCommand(param => LoginExecute(), param => CanExecuteLoginCommand);

            this.Username = "oliwia-testuje";
            this.Channel = "#o";
            this.Server = "irc.mizure.net";
            this.Port = "6667";
        }


        public string Username { get; set; }

        public string Password { get; set; }

        public string Channel { get; set; }
        public string Server { get; set; }

        public string Port { get; set; }

        public void ConnectorSendMessage(string text)
        {
            if (this.ChannelConnector != null)
            {
                this.ChannelConnector.SendMessage(text);
            }
        }

        public void StartConnection()
        {

            Console.WriteLine("Starting connection: " + Username + Channel + "/" + Server + ":" + Port);

            this.ChannelConnector = new Connector(Dmd);
            this.ChannelConnector.Connect(Username, Channel, Server, Port);
            this.ChannelConnector.ManageMessages();
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
        }

        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }
    }
}
