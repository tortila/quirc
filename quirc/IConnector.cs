using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace quirc
{
    public interface IConnector
    {
        void DisplayMessage(CompositeType composite);

        void SendMessage(string text);
    }

    public class CompositeType
    {
        private string _username = "Anonymous";
        private string _message = "";

        public CompositeType() { }
        public CompositeType(string u, string m)
        {
            _username = u;
            _message = m;
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }

    public delegate void DisplayMessageDelegate(CompositeType data);

}