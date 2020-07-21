using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamakazeDiscordBot.Modules.ClasseUtiles;

namespace YamakazeDiscordBot.Services
{
    public class Requethttp
    {
        public Requethttp()
        {

        }

        public async Task<string> GetLinkImagePurr(string url)
        {
            string imagelink="";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                HttpContent content = response.Content;
                string result = await content.ReadAsStringAsync();
                DataJsonPurr data = JsonConvert.DeserializeObject<DataJsonPurr>(result);
                imagelink = data.Link;
            }
            else
            {
                imagelink = "erreur";
            }
            return imagelink;
        }

        public async Task<string> GetLinkImageNeko(string url)
        {
            string imagelink = "";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                HttpContent content = response.Content;
                string result = await content.ReadAsStringAsync();
                DataJsonNeko data = JsonConvert.DeserializeObject<DataJsonNeko>(result);
                imagelink = data.Url;
            }
            else
            {
                imagelink = "erreur";
            }
            return imagelink;
        }
    }
}
