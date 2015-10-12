using System;
using System.Windows.Controls;
using System.Windows.Input;
using quirc.ViewModels;


namespace quirc.Pages
{
    /// <summary>
    /// Interaction logic for ChatGrid.xaml
    /// </summary>
    public partial class ChatGrid : UserControl
    {
        ChannelConnectionViewModel vm;
        public ChatGrid()
        {
            InitializeComponent();
            vm = (ChannelConnectionViewModel)this.DataContext;
            vm.Dmd = this.DisplayMessage;
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
            vm.ConnectorSendMessage(ChatInput.Text);
            ChatInput.Clear();
        }
    }
}
