using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using YamakazeDiscordBot.Modules.ClasseUtiles.Metiers;

namespace YamakazeDiscordBot.Modules
{
    public class VideoImage : ModuleBase<SocketCommandContext>
    {
        [Command("hololive")]
        [Summary("Get a random video from hololive in the 150 video get in the bot launch")]
        public async Task Hololive()
        {
            Random rnd = new Random();
            VideoHololive vid = Program.hololive.Result[rnd.Next(Program.hololive.Result.Count)];
            string url = "https://www.youtube.com/watch?v=" + vid.VideoId;
            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.WithTitle("Random Hololive video");
            embedBuilder.AddField(vid.VideoName,vid.Vtuber+"\n"+url);
            embedBuilder.WithUrl(url);
            embedBuilder.WithImageUrl($"https://img.youtube.com/vi/{vid.VideoId}/hqdefault.jpg");
            Embed embed = embedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.Username, "hololive");
            await ReplyAsync(embed: embed);
        }
    }
}
