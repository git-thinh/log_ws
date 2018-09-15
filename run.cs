using System;
using System.IO;
using System.Text;

namespace Fleck2
{
    class Program
    {
        static StringBuilder cache = new StringBuilder();

        static void Main(string[] args)
        {
            var server = new WebSocketServer("ws://localhost:11111");
            server.Start(socket =>
            {
                socket.OnOpen = () => Console.WriteLine("Open!");
                socket.OnClose = () => Console.WriteLine("Close!");
                socket.OnMessage = message =>
                {
                    cache.Append(message + Environment.NewLine);
                    Console.WriteLine(message + Environment.NewLine);
                    //socket.Send(message);
                };
            });
             
            Console.Title = "ws|http://+:11111/";
            string cm = Console.ReadLine();
            while (true)
            {
                switch (cm)
                {
                    case "clear":
                    case "cls":
                        Console.Clear();
                        cache.Length = 0;
                        cache.Capacity = 0;
                        break;
                    case "save":
                        Console.Clear();
                        File.WriteAllText("log.txt", cache.ToString(), Encoding.UTF8);
                        break;
                }
                cm = Console.ReadLine();
            }
        }
    }
     
}
