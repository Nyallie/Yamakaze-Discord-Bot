using System;
using System.Collections.Generic;
using System.Text;

namespace YamakazeDiscordBot.Modules.ClasseUtiles
{
    public class DataJsonNeko
    {
        private string url;

        public string Url { get => url; set => url = value; }

        public DataJsonNeko(string lin)
        {
            Url = lin;
        }
    }
}