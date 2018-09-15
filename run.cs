using System; 

namespace Fleck2
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new WebSocketServer("ws://localhost:11111");
            server.Start(socket =>
            {
                socket.OnOpen = () => Console.WriteLine("Open!");
                socket.OnClose = () => Console.WriteLine("Close!");
                socket.OnMessage = message => Console.WriteLine(message + Environment.NewLine);
                //socket.Send(message);
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
                        break;
                }
                cm = Console.ReadLine();
            }
        }
    }
     
}
