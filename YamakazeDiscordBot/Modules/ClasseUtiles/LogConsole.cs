using System;
using System.Collections.Generic;
using System.Text;

namespace YamakazeDiscordBot.Modules.ClasseUtiles
{
    public class LogConsole
    {
        public LogConsole()
        {

        }

        public void WriteCommandToConsole(string user,string command,string saybyuser=null)
        {
            string message = "The user "+user+" used the command " + command;
            if (saybyuser != null)
            {
                message += " and say : " + saybyuser;
            }
            Console.WriteLine(message);
        }
    }
}
