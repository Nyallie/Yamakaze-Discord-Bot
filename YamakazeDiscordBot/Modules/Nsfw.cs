using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using YamakazeDiscordBot.Modules.ClasseUtiles;

namespace YamakazeDiscordBot.Modules
{
    public class Nsfw : ModuleBase<SocketCommandContext>
    {
        private Color _color = new Color(203, 38, 76); 
        [Command("nhsauce")]
        [Summary("Renvoie un lien Nhentai en fonction du 6digit donner en pinguant quelqu'un")]
        [Alias("nhs")]
        public async Task NhentaiSauce(string sauce=null, IGuildUser user = null)
        {
            string message = "";
            if (sauce == null)//Si aucun 6digit a était fournis
            {
                await ReplyAsync("You have to give a 6digits");
                return;
            }
            if (user == null)//Si aucun utilisateur n'a était ping
            {
                message = $":eyes: Here the sauce.\n https://www.nhentai.net/g/{sauce}";
            }
            else//Si un utilisateur a était ping et qu'un 6digit a était fournis
            {
                message = $":eyes: {user.Mention} Here the sauce. \n https://www.nhentai.net/g/{sauce}";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithColor(_color);//Construction du message
            Embed embed = EmbedBuilder.Build();
            await ReplyAsync(embed: embed);//Envoie du message
            Program.log.WriteCommandToConsole(Context.User.ToString(), "nhsauce");
        }
    }
}
