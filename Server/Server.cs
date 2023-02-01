using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8080;
            IPAddress localAddress = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(localAddress, port);
            listener.Start();

            Console.WriteLine("Server started. Listening for connections...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected.");

                byte[] buffer = new byte[1024];
                int bytesReceived = client.GetStream().Read(buffer, 0, buffer.Length);

                string message = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                Console.WriteLine("Received message: " + message);

                byte[] response = Encoding.ASCII.GetBytes("Message received.");
                client.GetStream().Write(response, 0, response.Length);
                Console.WriteLine("Response sent.");
            }
        }
    }
}
