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
        private string _urlhololive = "https://api.homoliver.live/api/hololive/v1/allvideos?limit=1&offset=";
        private Color _color = new Color(39, 198, 220);

        //Ne fonctionne plus car l'api utiliser n'existe plus
        [Command("hololive")]
        [Summary("Get a random video from hololive")]
        public async Task Hololive()
        {
            EmbedBuilder embedBuilderLoading = new EmbedBuilder()
                .WithTitle("Serching a random video...")
                .WithImageUrl("https://thumbs.gfycat.com/LittleBestAmoeba-max-14mb.gif")
                .WithColor(_color);
            Embed embedloading = embedBuilderLoading.Build();
            var message = await ReplyAsync(embed: embedloading);
            //Recherche de la vidéo
            bool sucess = true;
            Random rnd = new Random();
            Requethttp req = new Requethttp();
            DataJsonHololive hololive = await req.GetDataJsonHololive(_urlhololive + rnd.Next(1,4968));
            EmbedBuilder embedBuilderfinal = new EmbedBuilder();
            if (hololive == null)
            {
                embedBuilderfinal.WithTitle("Command error")
                    .WithDescription("The API doesn't response succesfuly.");
                sucess = false;
            }
            else
            {
                VideoHololive vid = hololive.Result[0];
                string url = "https://www.youtube.com/watch?" + vid.VideoId;
                string vidid = vid.VideoId;
                embedBuilderfinal.WithTitle("Random Hololive video")
                    .AddField(vid.VideoName, vid.Vtuber + "\n" + url)
                    .WithUrl(url)
                    .WithColor(_color)
                    .WithImageUrl($"https://img.youtube.com/vi/{vidid}/hqdefault.jpg");
            }
            Embed embed = embedBuilderfinal.Build();
            await message.ModifyAsync(msg => msg.Embed = embed);
            //await ReplyAsync(embed: embed);
            Program.log.WriteCommandToConsole(Context.User.ToString(), "hololive"+" Réussi : "+sucess);
        }


    }
}
