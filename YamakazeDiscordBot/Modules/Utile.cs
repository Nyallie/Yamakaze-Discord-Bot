using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamakazeDiscordBot.Modules.ClasseUtiles;

namespace YamakazeDiscordBot.Modules
{
    public class Utile : ModuleBase<SocketCommandContext>
    {
        private readonly Color _color = new Color(111, 38, 184);
        [Command("help")]
        [Summary("Affiche toute les commandes du bot")]
        public async Task HelpCommand()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.WithColor(_color);
            embedBuilder.WithTitle("Hello, I'm Yamakaze...")
                .WithDescription("Here are my commands, I wish you will like they...\n" +
                "It... it's okay if you don't like them... really...");
            embedBuilder.AddField("Utiles :", "help, ping, avatar, botinfo, \nhelpall, yamakaze");
            embedBuilder.AddField("Moderation :", "kick, ban, unban, purge");
            embedBuilder.AddField("Fun :", "lenny, say");
            embedBuilder.AddField("Reaction :", "bite, baka, cuddle, feed, hug, kiss, \nlick, pat, poke, putin, slap, tickle");
            embedBuilder.AddField("Picture and video :","hololive, sauce");
            embedBuilder.AddField("Nsfw :", "nhsauce");
            embedBuilder.AddField("Help :", "Prefix : "+Program._prop.Prefix);
            embedBuilder.WithCurrentTimestamp();
            embedBuilder.WithFooter(footer =>
            {
                footer
                .WithText("Yamakaze Wiki :\n https://kancolle.fandom.com/wiki/Yamakaze");
            });
            Program.log.WriteCommandToConsole(Context.User.ToString(), "help");
            await ReplyAsync("", false, embedBuilder.Build());
        }

        [Command("ping")]
        [Summary("Get the latency of the bot")]
        public async Task Ping()
        {
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription("Pong! :ping_pong:**" + Program._client.Latency + " ms**")
                .WithColor(_color);
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "ping");
            await ReplyAsync(embed: embed);
        }

        [Command("avatar")]
        [Summary("Resend the user avatar")]
        public async Task AvatarUser(IGuildUser user = null)
        {
            ImageFormat format = ImageFormat.Auto;
            ushort size = 1024;
            string avatarlink;
            string username;
            if (user == null)
            {
                avatarlink = Context.User.GetAvatarUrl(format, size);
                username = Context.User.Username.ToString();
            }
            else
            {
                avatarlink = user.GetAvatarUrl(format,size);
                username = user.Username.ToString();
            }
            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.WithTitle(username + " avatar.");
            embedBuilder.WithImageUrl(avatarlink).WithColor(_color).WithCurrentTimestamp();
            Embed emded = embedBuilder.Build();            
            await ReplyAsync(embed: emded);
            Program.log.WriteCommandToConsole(Context.User.ToString(), "avatar");
        }

        [Command("botinfo")]
        [Summary("Give the bot information")]
        public async Task InfoBot()
        {
            EmbedBuilder embedbuilder = new EmbedBuilder();
            embedbuilder.AddField("Bot version :", "0.8");
            embedbuilder.AddField("Bot developper :", "Heliodore24#5872");
            embedbuilder.AddField("Program langage and library :", "C#, Discord.Net");
            embedbuilder.WithColor(_color);
            embedbuilder.WithCurrentTimestamp();
            embedbuilder.WithFooter(footer =>
            {
                footer.WithText("For more information, send a message to the developper");
            });
            Embed embed = embedbuilder.Build();
            await ReplyAsync(embed: embed);
            Program.log.WriteCommandToConsole(Context.User.ToString(), "botinfo");
        }

        [Command("helpall")]
        [Summary("Explique ce que chaque commandes fait.")]
        public async Task HelpAll()
        {
            List<CommandInfo> commands = Program._commands.Commands.ToList();
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithCurrentTimestamp()
                .WithDescription("Here's a list of commands and their description: ")
                .WithColor(_color)
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Yamakaze Wiki :\n https://kancolle.fandom.com/wiki/Yamakaze");
                });
            int i = 0;
            while (i<commands.Count)
            {
                CommandInfo command = commands[i];
                // Get the command Summary attribute information
                //string embedFieldText = commands[i].Summary ?? "No description available\n";
                embedBuilder.AddField(command.Name, command.Summary);
                Console.WriteLine(command.Name+" : "+ command.Summary);
                i++;
            }
            Embed embed = embedBuilder.Build();
            await ReplyAsync(embed: embed);
            Program.log.WriteCommandToConsole(Context.User.ToString(), "helpall");
        }

        [Command("yamakaze")]
        [Summary("Give information who Yamakaze is...")]
        public async Task Yamakaze()
        {
            string message = "Her name is write '山風' and mean 'Moutain Wind'.\n";
            message += "Personality : Yamakaze is very shy and stoic. " +
                "She is a fragile girl who wants someone to stand by her side, " +
                "even though she denies it.";
            EmbedBuilder embedbuilder = new EmbedBuilder();
            embedbuilder
                .WithTitle("Yamakaze")
                .WithDescription(message)
                .WithImageUrl("https://static.zerochan.net/Yamakaze.%28Kantai.Collection%29.full.2284538.png")
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer.WithText("More information at : https://kancolle.fandom.com/wiki/Yamakaze");
                });
            Embed embed = embedbuilder.Build();
            await ReplyAsync(embed: embed);
            Program.log.WriteCommandToConsole(Context.User.ToString(), "yamakaze");

            
        }
        [Command("serverinfo")]
        [Summary("Renvoie les information du serveur sur le quel la commande a était éffectuer")]
        public async Task InfoServer()
        {
            EmbedAuthorBuilder embedAuthor = new EmbedAuthorBuilder()//Construction de l'auteur du message parce que why not
                .WithName(Context.Guild.Name)
                .WithIconUrl(Context.Guild.IconUrl);
            string role="";
            foreach (IRole role1 in Context.Guild.Roles)
            {
                if (role1 == Context.Guild.Roles.Last())
                {
                    role = role + role1.Name + ".";
                }
                else
                {
                    role = role + role1.Name + ", ";
                }
            }
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithAuthor(embedAuthor)
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithTitle("Server information")
                .AddField("ID",Context.Guild.Id,true)
                .AddField("Member", Context.Guild.MemberCount,true)
                .AddField("Server Owner", Context.Guild.Owner.Username, true)
                .AddField("Channel",Context.Guild.TextChannels.Count+" Text Channel and "+Context.Guild.VoiceChannels.Count+"Voice Channel")
                .AddField("Create",Context.Guild.CreatedAt)
                .AddField("Roles", role)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer.WithText("Yamakaze Bot");
                });
            Embed embed = embedBuilder.Build();
            await ReplyAsync(embed: embed);
            Program.log.WriteCommandToConsole(Context.User.ToString(), "server");
        }
    }
}
