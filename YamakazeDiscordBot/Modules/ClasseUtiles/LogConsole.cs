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
            string message = "Command : " + command + "\n" +
                "User who call the command : "+user+"\n";
            if (saybyuser != null)
            {
                message += "say with the command : "+saybyuser;
            }
            Console.WriteLine(message);
        }
    }
}
