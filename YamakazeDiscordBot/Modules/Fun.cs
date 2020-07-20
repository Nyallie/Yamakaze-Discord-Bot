using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YamakazeDiscordBot.Modules
{
    public class Fun : ModuleBase<SocketCommandContext>
    {

        [Command("say")]
        [Summary("Repeat what the user say")]
        public async Task SayAsync([Remainder][Summary("Repete ce qui suis la commande say")] string echo)
        {
            await ReplyAsync(echo);
        }

        [Command("lenny")]
        [Summary("Send a lenny face")]
        public async Task Lenny()
        {
            await ReplyAsync("( ͡° ͜ʖ ͡°)");
        }

        
    }
}
