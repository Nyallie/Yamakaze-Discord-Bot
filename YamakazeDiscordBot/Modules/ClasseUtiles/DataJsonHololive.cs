using System;
using System.Collections.Generic;
using System.Text;
using YamakazeDiscordBot.Modules.ClasseUtiles.Metiers;

namespace YamakazeDiscordBot.Modules.ClasseUtiles
{
    public class DataJsonHololive
    {
        private List<VideoHololive> result;
        private int totalvideo;

        public List<VideoHololive> Result { get => result; set => result = value; }
        public int Totalvideo { get => totalvideo; set => totalvideo = value; }

        public DataJsonHololive()
        {

        }
    }
}
