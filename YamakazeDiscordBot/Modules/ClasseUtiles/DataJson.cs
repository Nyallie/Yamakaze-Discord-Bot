using System;
using System.Collections.Generic;
using System.Text;

namespace YamakazeDiscordBot.Modules.Classe
{
    public class DataJson
    {
        private int code;
        private string link;
        private int time;
        public int Code { get => code; set => code = value; }
        public string Link { get => link; set => link = value; }
        public int Time { get => time; set => time = value; }

        public DataJson(int cod, string lin, int tim)
        {
            Code = cod;
            Link = lin;
            Time = tim;
        }
    }
}
