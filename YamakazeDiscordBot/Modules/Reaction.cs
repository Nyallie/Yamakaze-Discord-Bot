using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using YamakazeDiscordBot.Modules.ClasseUtiles;
using YamakazeDiscordBot.Services;

namespace YamakazeDiscordBot.Modules
{
    public class Reaction : ModuleBase<SocketCommandContext>
    {
        private static string _baseurlpurr="https://purrbot.site/api/img/sfw";
        private static string _baseurlneko = "https://nekos.life/api/v2/img/";
        private Color _color = new Color(169,9,208);

        [Command("bite")]
        [Summary("Bite someone or get bite by the bot")]
        public async Task BiteReac(IGuildUser user = null)
        {
            string url = _baseurlpurr + "/bite/gif";
            string message = "";
            Requethttp req = new Requethttp();
            string giflink = await req.GetLinkImagePurr(url);
            if (user == null)
            {
                message = $"You want to be bite {Context.User.Mention} ? Okay...";
            }
            else
            {
                message = $"{Context.User.Mention} has bitten {user.Mention}";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by PurrBot Api");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "bite");
            await ReplyAsync(embed: embed);
        }

        [Command("baka")]
        [Summary("The bot tell you that you're a baka or you tell someone he is a baka")]
        public async Task BakaReac(IGuildUser user = null)
        {
            string url = _baseurlneko + "baka";
            string message = "";
            Requethttp req = new Requethttp();
            string giflink = await req.GetLinkImageNeko(url);
            if (user == null)
            {
                message = $"{Context.User.Mention}... Baka...";
            }
            else
            {
                message = $"{Context.User.Mention} has to tell to {user.Mention} : Baka !";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by Nekos.life Api");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "baka");
            await ReplyAsync(embed: embed);
        }

        [Command("cuddle")]
        [Summary("Cuddle someone or be cuddle by the bot")]
        public async Task CuddleReac(IGuildUser user = null)
        {
            string url = _baseurlpurr + "/cuddle/gif";
            string message = "";
            Requethttp req = new Requethttp();
            string giflink = await req.GetLinkImagePurr(url);
            if (user == null)
            {
                message = $"You want some cuddle {Context.User.Mention} ? Okay... ";
            }
            else
            {
                message = $"{Context.User.Mention} has cuddled {user.Mention}";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by PurrBot Api");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "cuddle");
            await ReplyAsync(embed: embed);
        }

        [Command("feed")]
        [Summary("I feed you or you feed someone")]
        public async Task FeedReac(IGuildUser user =null)
        {
            string url = _baseurlpurr + "/feed/gif";
            string message = "";
            Requethttp req = new Requethttp();
            string giflink = await req.GetLinkImagePurr(url);
            if (user == null)
            {
                message = $"Okay... I will feed you, {Context.User.Mention}";
            }
            else
            {
                message = $"{Context.User.Mention} has fed {user.Mention}";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by PurrBot Api");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "feed");
            await ReplyAsync(embed: embed);
        }

        [Command("hug")]
        [Summary("I hug you or you can hug someone")]
        public async Task HugReac(IGuildUser user = null)
        {
            string url = _baseurlpurr + "/hug/gif";
            string message = "";
            Requethttp req = new Requethttp();
            string giflink = await req.GetLinkImagePurr(url);
            if (user == null)
            {
                message = $"You... You need an hug, {Context.User.Mention} ? Okay... There you go";
            }
            else
            {
                message = $"{Context.User.Mention} has hugged {user.Mention}";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by PurrBot Api");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "hug");
            await ReplyAsync(embed: embed);
        }

        [Command("kiss")]
        [Summary("You realy want that ? Hentai-kun!")]
        public async Task KissReac(IGuildUser user = null)
        {
            string url = _baseurlpurr + "/kiss/gif";
            string message = "";
            Requethttp req = new Requethttp();
            string giflink = await req.GetLinkImagePurr(url);
            if (user == null)
            {
                message = $"You... You really want that, {Context.User.Mention} ? Hentai-san...";
            }
            else
            {
                message = $"{Context.User.Mention} has kissed {user.Mention}";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by PurrBot Api");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "kiss");
            await ReplyAsync(embed: embed);
        }

        [Command("lick")]
        [Summary("Uuhh ???")]
        public async Task LickReac(IGuildUser user=null)
        {
            string url = _baseurlpurr + "/lick/gif";
            string message = "";
            Requethttp req = new Requethttp();
            string giflink = await req.GetLinkImagePurr(url);
            if (user == null)
            {
                message = $"You... What ? {Context.User.Mention} ? Are ... Are you okay ?";
            }
            else
            {
                message = $"{Context.User.Mention} has licked {user.Mention}";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by PurrBot Api");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "lick");
            await ReplyAsync(embed: embed);
        }

        [Command("pat")]
        [Summary("Give a headpat at someone or the bot will give it to you")]
        public async Task PatReac(IGuildUser user = null)
        {
            string url = _baseurlpurr + "/pat/gif";
            string message = "";
            Requethttp req = new Requethttp();
            string giflink = await req.GetLinkImagePurr(url);
            if (user == null)
            {
                message = $"You... You need an headpat, {Context.User.Mention} ?\n Okay... There there, you did well...";
            }
            else
            {
                message = $"{Context.User.Mention} has headpated {user.Mention}";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by PurrBot Api");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "pat");
            await ReplyAsync(embed: embed);
        }

        [Command("poke")]
        [Summary("Poke or be poked")]
        public async Task PokeReac(IGuildUser user = null)
        {
            string url = _baseurlpurr + "/poke/gif";
            string message = "";
            Requethttp req = new Requethttp();
            string giflink = await req.GetLinkImagePurr(url);
            if (user == null)
            {
                message = $"You... Are you here {Context.User.Mention} ? Hi hi hi... ";
            }
            else
            {
                message = $"{Context.User.Mention} has pocked {user.Mention}";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by PurrBot Api");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "poke");
            await ReplyAsync(embed: embed);
        }

        [Command("putin")]
        [Summary("Be putined")]
        public async Task PutinReac(IGuildUser user = null)
        {
            string giflink = "https://media1.tenor.com/images/17d841bae0f15bc0fd553bacb49299b5/tenor.gif?itemid=17778546";
            string message = "";
            if (user == null)
            {
                message = "NO HENTAI, ONLY PUTIN!!";
            }
            else
            {
                message = $"{Context.User.Mention} have to say at {user.Mention}: NO HENTAI, ONLY PUTIN!!";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by the Dev of this bot");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "putin");
            await ReplyAsync(embed: embed);
        }

        [Command("slap")]
        [Summary("Slap someone or be slapped")]
        public async Task SlapReac(IGuildUser user = null)
        {
            string url = _baseurlpurr + "/slap/gif";
            string message = "";
            Requethttp req = new Requethttp();
            string giflink = await req.GetLinkImagePurr(url);
            if (user == null)
            {
                message = $"You... You did a bad thing don't you, {Context.User.Mention} ?";
            }
            else
            {
                message = $"You did something bad {user.Mention} don't you ?\n {Context.User.Mention} has slapped you...";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by PurrBot Api");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "slap");
            await ReplyAsync(embed: embed);
        }

        [Command("tickle")]
        [Summary("Tickle someone or be tickeled")]
        public async Task TickleReac(IGuildUser user = null)
        {
            string url = _baseurlpurr + "/tickle/gif";
            string message = "";
            Requethttp req = new Requethttp();
            string giflink = await req.GetLinkImagePurr(url);
            if (user == null)
            {
                message = $"Hey..., {Context.User.Mention}... Tickle tickle tickle !!";
            }
            else
            {
                message = $"{Context.User.Mention} has tickeled {user.Mention}";
            }
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription(message)
                .WithImageUrl(giflink)
                .WithColor(_color)
                .WithCurrentTimestamp()
                .WithFooter(footer =>
                {
                    footer
                    .WithText("Powered by PurrBot Api");
                });
            Embed embed = EmbedBuilder.Build();
            Program.log.WriteCommandToConsole(Context.User.ToString(), "tickle");
            await ReplyAsync(embed: embed);
        }
    }
}
