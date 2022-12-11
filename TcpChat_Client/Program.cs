using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpChat_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client2";
            Console.WriteLine("[CLIENT]");
            Socket socket_sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse("127.0.0.1");
            IPEndPoint endRemoutePoint = new IPEndPoint(address, 7632);
            Console.WriteLine("Нажмите Enter для продолжения");

            Console.ReadLine();
            socket_sender.Connect(endRemoutePoint);
            while (true)
            {
                
                Console.WriteLine("Введите сообщение для отправки");
                string message = Console.ReadLine();
                byte[] bytes = Encoding.Unicode.GetBytes(message);
                socket_sender.Send(bytes);
                Console.WriteLine("посылка " + message + " отправлена");

                byte[] byte_answers = new byte[1024];
                int num_bytes = socket_sender.Receive(byte_answers);
                string answer = Encoding.Unicode.GetString(byte_answers, 0, num_bytes);
                Console.WriteLine(answer);
                Console.WriteLine();
            }
            

            Console.ReadLine();
        }
    }
}
