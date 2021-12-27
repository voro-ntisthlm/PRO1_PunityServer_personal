using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace PunityServer
{
    class Server
    {
        static public int port = 3404;
        static public IPAddress serverAdress = IPAddress.Parse("192.168.56.1");
        static public int playerLimit = 2;
        static public string serverName;
        static public string motd;
    }
}

