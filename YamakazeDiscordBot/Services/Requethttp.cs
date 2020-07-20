using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamakazeDiscordBot.Modules.Classe;

namespace YamakazeDiscordBot.Services
{
    public class Requethttp
    {
        public Requethttp()
        {

        }

        public async Task<string> GetLinkImage(string url)
        {
            string imagelink="";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                HttpContent content = response.Content;
                string result = await content.ReadAsStringAsync();
                DataJson data = JsonConvert.DeserializeObject<DataJson>(result);
                imagelink = data.Link;
            }
            else
            {
                imagelink = "erreur";
            }
            return imagelink;
        }
    }
}
