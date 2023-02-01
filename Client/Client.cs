using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            int port = 8080;
            IPAddress localAddress = IPAddress.Parse("127.0.0.1");
            TcpClient client = new TcpClient(localAddress.ToString(), port);

            Console.WriteLine("Connected to server.");

            string message = "Hello from the client!";
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            client.GetStream().Write(buffer, 0, buffer.Length);
            Console.WriteLine("Message sent: " + message);

            buffer = new byte[1024];
            int bytesReceived = client.GetStream().Read(buffer, 0, buffer.Length);

            string response = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
            Console.WriteLine("Response received: " + response);
        }
    }
}
