using System;
using System.Collections.Generic;
using System.Text;

namespace YamakazeDiscordBot.Modules.ClasseUtiles
{
    public class PropertiesJson
    {
        private string token;
        private string prefix;
        public string Token { get => token; set => token = value; }
        public string Prefix { get => prefix; set => prefix = value; }
        public PropertiesJson(string tok, string pre)
        {
            Token = tok;
            Prefix = pre;
        }
    }
}
