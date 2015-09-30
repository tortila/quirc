using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace quirc.Pages
{
    /// <summary>
    /// Interaction logic for ChatGrid.xaml
    /// </summary>
    public partial class ChatGrid : UserControl
    {
        private readonly Connector _backend;
        public ChatGrid()
        {
            _backend = new Connector(this.DisplayMessage);
            InitializeComponent();
        }

        public void DisplayMessage(CompositeType composite)
        {
            string username = composite.Username ?? "";
            string message = composite.Message ?? "";
            // Dispatcher is here to take care of threads ownership over UI components
            Dispatcher.Invoke(() =>
            {
                ChatHistory.Text += (username + ": " + message + Environment.NewLine);
            });
            
        }

        private void ChatInput_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return && e.Key != Key.Enter) return;
            _backend.SendMessage(ChatInput.Text);
            ChatInput.Clear();
        }
    }
}
