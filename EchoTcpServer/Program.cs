using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using GramOunceConverter;

namespace EchoTcpServer
{
    class Program
    {
        public static readonly int Port = 7777;

        static void Main()
        {
            IPAddress localAddress = IPAddress.Loopback;

            TcpListener serverSocket = new TcpListener(localAddress, Port);
            serverSocket.Start();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Echo server started on " + localAddress + " port " + Port);
            Console.WriteLine("//--        Welcome to the Gram and ounce Conveter    --\\");
            Console.WriteLine("  input: ToGram or ToOunce and then enter a value");
            Console.WriteLine("----------------------------------------------------------------------");
            while (true)
            {
                try
                {
                    TcpClient clientConnection = serverSocket.AcceptTcpClient();
                    Task.Run(() => DoIt(clientConnection));
                }
                catch (SocketException)
                {
                    Console.WriteLine("Socket exception: Will continue working");
                }
            }
        }

        private static void DoIt(TcpClient clientConnection)
        {
            Console.WriteLine("Incoming client " + clientConnection.Client);
            NetworkStream stream = clientConnection.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            while (true)
            {


              
                string request = reader.ReadLine();
                if (string.IsNullOrEmpty(request)) { break; }


                if (request == "stop")
                {
                  clientConnection.Close();
                }

                Console.WriteLine("Request: " + request);
                string response = "";
                string[] ToBeRequested = request.Split(" ");
                switch (ToBeRequested[0].ToUpper())
                {
                    case "TOGRAM":
                        response = "Grams: " + GramAndOunceConverter.ToGram(int.Parse(ToBeRequested[1])).ToString();
                        break;
                    case "TOOUNCE":
                        response = "Ounce: " + GramAndOunceConverter.ToOunce(int.Parse(ToBeRequested[1])).ToString();
                        break;
                }

                writer.WriteLine(response);
                writer.Flush();
            }

            clientConnection.Close();
            Console.WriteLine("Socket closed");
        }
    }
}