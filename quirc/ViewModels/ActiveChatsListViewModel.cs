using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quirc.Pages;

namespace quirc.ViewModels
{
    public class ActiveChatsListViewModel
    {
        public ObservableCollection<ChatGrid> Chats;

        public ActiveChatsListViewModel()
        {
            Chats = new ObservableCollection<ChatGrid>();
        }
    }
}
