using System;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace PunityServer
{
    class Program
    {
        static public int port = 3404;
        static public IPAddress serverAdress = Dns.GetHostEntry("localhost").AddressList[0];
        static public int playerLimit = 2;
        static public string serverName;
        static public string motd;


        static void Main(string[] args)
        {
            Console.WriteLine("Punity Server\n\nReading Server.cfg file");
            ReadConfig();
            Console.WriteLine("Finished applying Server.cfg\nStarting server...");
            Console.Read();
        }

        static public void ReadConfig(){
            
            // Try to assign the Host.cfg values to the server variables
            try
            {
                string[] configLines = System.IO.File.ReadAllLines("./Data/Server.cfg");

                // This will loop thorugh the file and depending on the "variable" 
                // it will assign the value to the corresponding variable
                foreach (var config in configLines)
                {
                    string[] line = config.Split(":");

                    switch (line[0])
                    {
                        case "PORT":
                            int.TryParse(line[1], out port);
                            break;
                        case "MAXPLAYERS":
                            int.TryParse(line[1], out playerLimit);
                            break;
                        case "IP":
                            if (line[1] != "")
                                serverAdress = IPAddress.Parse(line[1]);   
                            break;
                        case "NAME":
                            serverName = line[1];
                            break;
                        case "MOTD":
                            motd = line[1];
                            break;
                        default:
                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("ERROR WHEN LOADING HOST.CFG");
                throw; 
            }
        }
    }
}
