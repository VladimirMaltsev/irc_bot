using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args) { 

         IrcBot ircBot;

        
             ircBot = new IrcBot(
                 server: "irc.freenode.net",
                 port: 6667,
                 user: "USER BOTVOTr 0 * :BOTVOTr",
                 nick: "GadalkaLola",
                 channel: "##net1337",
                 maxRetries: 10
                 );

        new Thread(() => ircBot.ReadFromChannel()).Start();
        new Thread(() => ircBot.WriteToChannel()).Start();
        
    }
}

