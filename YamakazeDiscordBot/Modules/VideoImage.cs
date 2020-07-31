using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using YamakazeDiscordBot.Modules.ClasseUtiles;
using YamakazeDiscordBot.Modules.ClasseUtiles.Metiers;
using YamakazeDiscordBot.Services;

namespace YamakazeDiscordBot.Modules
{
    public class VideoImage : ModuleBase<SocketCommandContext>
    {
        private string _url = "https://homoliver.live/api/v1/allvideos?limit=1&offset=";
        private Color _color = new Color(39, 198, 220);

        [Command("hololive")]
        [Summary("Get a random video from hololive")]
        public async Task Hololive()
        {
            bool sucess = true;
            Random rnd = new Random();
            Requethttp req = new Requethttp();
            DataJsonHololive hololive = await req.GetDataJsonHololive(_url + rnd.Next(1,4968));
            EmbedBuilder embedBuilder = new EmbedBuilder();
            if (hololive == null)
            {
                embedBuilder.WithTitle("Command error")
                    .WithDescription("The API doesn't response succesfuly.");
                sucess = false;
            }
            else
            {
                VideoHololive vid = hololive.Result[0];
                string url = vid.VideoId;
                string vidid = vid.VideoId.Remove(0, 32);
                embedBuilder.WithTitle("Random Hololive video")
                    .AddField(vid.VideoName, vid.Vtuber + "\n" + url)
                    .WithUrl(url)
                    .WithColor(_color)
                    .WithImageUrl($"https://img.youtube.com/vi/{vidid}/hqdefault.jpg");
            }
            Embed embed = embedBuilder.Build();
            await ReplyAsync(embed: embed);
            Program.log.WriteCommandToConsole(Context.User.ToString(), "hololive"+" Réussi : "+sucess);
        }
    }
}
