using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YamakazeDiscordBot.Modules.ClasseUtiles;

namespace YamakazeDiscordBot.Modules
{
    public class Fun : ModuleBase<SocketCommandContext>
    {
        private readonly LogConsole log = new LogConsole();

        [Command("say")]
        [Summary("Repeat what the user say")]
        public async Task SayAsync([Remainder][Summary("Repete ce qui suis la commande say")] string echo)
        {
            log.WriteCommandToConsole(Context.User.Username, "say",echo);
            await ReplyAsync(echo);
        }

        [Command("lenny")]
        [Summary("Send a lenny face")]
        public async Task Lenny()
        {
            log.WriteCommandToConsole(Context.User.Username, "lenny");
            await ReplyAsync("( ͡° ͜ʖ ͡°)");
        }

        
    }
}
