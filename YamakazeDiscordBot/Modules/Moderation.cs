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
    public class Moderation : ModuleBase<SocketCommandContext>
    {

        [Command("purge")]
        [Alias("clean")]
        [Summary("Removes X messages from the current channel.")]
        [RequireUserPermission(ChannelPermission.ManageMessages)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task PurgeAsync(int amount)
        {
            // Check if the amount provided by the user is positive.
            if (amount <= 0)
            {
                await ReplyAsync("The amount of messages to remove must be positive.");
                return;
            }
            // Download X messages starting from Context.Message, which means
            // that it won't delete the message used to invoke this command.
            var messages = await Context.Channel.GetMessagesAsync(Context.Message, Direction.Before, amount).FlattenAsync();
            // Ensure that the messages aren't older than 14 days,
            // because trying to bulk delete messages older than that
            // will result in a bad request.
            var filteredMessages = messages.Where(x => (DateTimeOffset.UtcNow - x.Timestamp).TotalDays <= 14);
            // Get the total amount of messages.
            var count = filteredMessages.Count();
            // Check if there are any messages to delete.
            if (count == 0)
            {
                await ReplyAsync("Nothing to delete.");
            }
            else
            {
                // The cast here isn't needed if you're using Discord.Net 1.x,
                // but I'd recommend leaving it as it's what's required on 2.x, so
                // if you decide to update you won't have to change this line.
                await (Context.Channel as ITextChannel).DeleteMessagesAsync(filteredMessages);
                await ReplyAsync($"Done. Removed {count} {(count > 1 ? "messages" : "message")}.");
                Program.log.WriteCommandToConsole(Context.User.Username, "purge");
            }
        }

        [Command("ban")]
        [Summary("Ban la personne ping dans la commandes avec la raison")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage ="You don't have the permission ``ban_member``!")]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task BanMember(IGuildUser user =null, [Remainder] string reason =null)
        {
            if (user == null)
            {
                await ReplyAsync("Please specify a user!");
                return;
            }
            if (reason == null) reason = "Not Specified";
            await Context.Guild.AddBanAsync(user, 1, reason);//Ban a user
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription($":white_check_mark: {user.Mention} was banned.\n **Reason** {reason}")
                .WithFooter(footer =>
                {
                    footer
                    .WithText("User Ban Log")
                    .WithIconUrl("https://i.imgur.com/6Bi17B3.png");
                });
            Embed embed = EmbedBuilder.Build();
            await ReplyAsync(embed: embed);
            Program.log.WriteCommandToConsole(Context.User.Username, "ban");
        }

        [Command("unban")]
        [Summary("Annule le banissement d'un user mentioner")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "You don't have the permission ``ban_member``!")]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task UnBanMember(IGuildUser user = null)
        {
            if (user == null)
            {
                await ReplyAsync("Please specify a user!");
                return;
            }
            await Context.Guild.RemoveBanAsync(user);//Unban a user
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription($":white_check_mark: {user.Mention} was unbanned.")
                .WithFooter(footer =>
                {
                    footer
                    .WithText("User Ban Log")
                    .WithIconUrl("https://i.imgur.com/6Bi17B3.png");
                });
            Embed embed = EmbedBuilder.Build();
            await ReplyAsync(embed: embed);
            Program.log.WriteCommandToConsole(Context.User.Username, "unban");
        }

        [Command("kick")]
        [Summary("Kick la personne ping dans la commandes avec la raison")]
        [RequireUserPermission(GuildPermission.KickMembers, ErrorMessage = "You don't have the permission ``kick_members``!")]
        [RequireBotPermission(GuildPermission.KickMembers)]
        public async Task KickMember(IGuildUser user = null, [Remainder] string reason = null)
        {
            if (user == null)
            {
                await ReplyAsync("Please specify a user!");
                return;
            }
            if (reason == null) reason = "Not Specified";
            await user.KickAsync(reason);//Kick a user
            var EmbedBuilder = new EmbedBuilder()
                .WithDescription($":white_check_mark: {user.Mention} was kick.\n **Reason** {reason}")
                .WithFooter(footer =>
                {
                    footer
                    .WithText("User Ban Log")
                    .WithIconUrl("https://i.imgur.com/6Bi17B3.png");
                });
            Embed embed = EmbedBuilder.Build();
            await ReplyAsync(embed: embed);
            Program.log.WriteCommandToConsole(Context.User.Username, "kick");
        }
    }
}
