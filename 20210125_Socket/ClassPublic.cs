using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210125_Socket
{
    public class ClassPublic
    {
        public static ServerConfig serverConfig = new ServerConfig();
        public static ClientConfig clientConfig = new ClientConfig();

        public class ServerConfig
        {
            public string IPAddress;
            public int Port;
        }

        public class ClientConfig
        {

        }

    }
}
