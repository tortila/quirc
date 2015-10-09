using System.Windows;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using quirc.Pages;
using UserAuth = quirc.Models.UserAuth;

namespace quirc.ViewModels
{
    public class UserAuthViewModel
    {
        public ChatGrid IrcChatGrid;
        public string Username {get; set; }
        public string UserPassword { get; set; }
        public string Server { get; set; }
        public string Channel { get; set; }
        public string Port { get; set; }

        public ICommand LoginCommand { get; set; }

        public UserAuth UserAuth;

        public UserAuthViewModel()
        {
            Server = "irc.mizure.net";
            Port = "6667";
            LoginCommand = new RelayCommand(param => LoginExecute(), param => CanExecuteLoginCommand);
        }

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
            UserAuth = new UserAuth(Username, Channel, Server, Port, UserPassword);
            //MessageBox.Show("oh hai");
        }

        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }

    }
}