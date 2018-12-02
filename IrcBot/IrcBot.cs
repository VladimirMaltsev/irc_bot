using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Text;

internal class IrcBot
{
    private readonly string _server;
    private readonly int _port;
    private readonly string _user;
    private readonly string _nick;
    private readonly string _channel;
    private readonly int _maxRetries;
    Lib lib = new Lib();

    IPHostEntry ipHost;
    IPAddress ipAddr;
    IPEndPoint ipEndPoint;

    Socket sender;

    public IrcBot(string server, int port, string user, string nick, string channel, int maxRetries)
    {
        _server = server;
        _port = port;
        _user = user;
        _nick = nick;
        _channel = channel;
        _maxRetries = maxRetries;

        var retry = true;
        var retryCount = 0;
        while (retry)
        {
            try
            {
                ipHost = Dns.GetHostEntry(_server);
                ipAddr = ipHost.AddressList[0];
                ipEndPoint = new IPEndPoint(ipAddr, _port);

                sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(ipEndPoint);

                byte[] msg;
                
                byte[] buffers = new byte[2048];
                int bytesRecs = sender.Receive(buffers);
                Console.WriteLine(Encoding.UTF8.GetString(buffers, 0, bytesRecs));

               
                msg = Encoding.UTF8.GetBytes("PASS adsfmajgKJHFKjh\n");
                int bytesSent = sender.Send(msg);
                msg = Encoding.UTF8.GetBytes("NICK " + _nick + "\n");
                bytesSent = sender.Send(msg);
                msg = Encoding.UTF8.GetBytes(_user + "\n");
                bytesSent = sender.Send(msg);
                msg = Encoding.UTF8.GetBytes("JOIN " + _channel + "\n");
                bytesSent = sender.Send(msg);
                msg = Encoding.UTF8.GetBytes("PRIVMSG " + _channel + " :кому погадать?\r\n");
                bytesSent = sender.Send(msg);

                Console.WriteLine("My nick>  " + _nick);
                Console.WriteLine("Ip dist>  " + ipAddr);
                retry = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Thread.Sleep(5000);
                retry = ++retryCount <= _maxRetries;
            }
        }
    }
    public void WriteToChannel()
    {
        while (true)
        {
            sender.Send(Encoding.UTF8.GetBytes("PRIVMSG " + _channel + " :" + Console.ReadLine() + "\r\n"));
        }
    }

    public void ReadFromChannel()
    {
        byte[] msg;
        int bytesSent;
        while (true)
        {
            string inputLine;
            byte[] buffer = new byte[2048];
            int bytesRec = sender.Receive(buffer);
            if ((inputLine = Encoding.UTF8.GetString(buffer, 0, bytesRec)) != null)
            {
                Console.WriteLine("Response>>  " + inputLine);
                string[] splitInput = inputLine.Split(' ');
                if (splitInput[0] == "PING")
                {
                    string pongReply = splitInput[1];
                    msg = Encoding.UTF8.GetBytes("PONG " + pongReply + "\n");
                    bytesSent = sender.Send(msg);
                }

                if (inputLine.Contains(_nick) && inputLine.Contains("magic"))
                {
                    DoMagic();
                }

                switch (splitInput[1])
                {
                    case "001":
                        msg = Encoding.UTF8.GetBytes("JOIN " + _channel);
                        bytesSent = sender.Send(msg);
                        sender.Send(msg);
                        break;

                    default:
                        break;
                }
                    

            }
        }
           
    }

    void DoMagic()
    {
        byte[] msg;
        int bytesSent;
        msg = Encoding.UTF8.GetBytes("PRIVMSG " + _channel + " :Заглядываю в будущее...\r\n");
        bytesSent = sender.Send(msg);
        Thread.Sleep(500);
        msg = Encoding.UTF8.GetBytes("PRIVMSG " + _channel + " :Секундочку, у меня для вас кое-что есть:\r\n");
        bytesSent = sender.Send(msg);
        Thread.Sleep(500);
        msg = Encoding.UTF8.GetBytes("PRIVMSG " + _channel + " :" + lib.GetPrediction() + "\r\n");
        bytesSent = sender.Send(msg);
    }
}

   

