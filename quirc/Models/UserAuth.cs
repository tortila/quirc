using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quirc.Models
{
    public class UserAuth
    {
        public UserAuth(string u, string c, string s, string p, string up)
        {
            ConnectionData = new CompositeType(u, c, s, p, up);
            Console.WriteLine("User auth created: " + u + c + p + up);
        }
        public string Username { get; set; }
        public string Channel { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string UserPassword { get; set; }

        public CompositeType ConnectionData;
        
        public class CompositeType
        {
            public CompositeType() { }
            public CompositeType(string u, string c, string s, string p, string up)
            {
                Username = u;
                Channel = c;
                Server = s;
                Port = p;
                UserPassword = !string.IsNullOrEmpty(up) ? up : "";
            }

            public string Username { get; set; }
            public string Channel { get; set; }
            public string Server { get; set; }
            public string Port { get; set; }
            public string UserPassword { get; set; }
        }
    }
}
