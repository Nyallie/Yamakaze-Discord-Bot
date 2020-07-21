using System;
using System.Collections.Generic;
using System.Text;

namespace YamakazeDiscordBot.Modules.ClasseUtiles
{
    public class DataJsonPurr
    {
        private int code;
        private string link;
        private int time;
        public int Code { get => code; set => code = value; }
        public string Link { get => link; set => link = value; }
        public int Time { get => time; set => time = value; }

        public DataJsonPurr(int cod, string lin, int tim)
        {
            Code = cod;
            Link = lin;
            Time = tim;
        }
    }
}
