using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPChatClient
{
    class Program
    {
        private static TcpClient _clientSocket = null;
        private static Stream _nstream = null;
        private static StreamWriter _sWriter = null;
        private static StreamReader _sReader = null;
        static void Main(string[] args)
        {
            try
            {

                using (_clientSocket = new TcpClient("127.0.0.1", 7777))
                {
                    using (_nstream = _clientSocket.GetStream())
                    {
                        while (true)
                        {
                            _sWriter = new StreamWriter(_nstream) { AutoFlush = true };

                            Console.WriteLine("Write your message here: ");
                            string clientMsg = Console.ReadLine();

                            _sWriter.WriteLine(clientMsg);


                            _sReader = new StreamReader(_nstream);
                            string rdMsgFromServer = _sReader.ReadLine();
                            if (rdMsgFromServer != null)
                            {

                                Console.WriteLine("Client recieved Message from Server:" + rdMsgFromServer);
                                Console.WriteLine(".....................................................");

                            }
                            else
                            {
                                Console.WriteLine("Client recieved null message from Server ");
                            }
                        }

                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }

    }

}