using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using SauceNET;
using SauceNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly string _urlhololive = "https://api.homoliver.live/api/hololive/v1/allvideos?limit=1&offset=";
        private int _hololivevid=0;

        //Ne fonctionne plus car l'api utiliser n'existe plus
        [Command("hololive")]
        [Summary("Get a random video from hololive")]
        public async Task Hololive()
        {
            int randomnumber;
            Color color = new Color(39, 198, 220);
            EmbedBuilder embedBuilderLoading = new EmbedBuilder()
                .WithTitle("Searching a random video...")
                .WithImageUrl("https://thumbs.gfycat.com/LittleBestAmoeba-max-14mb.gif")
                .WithColor(color);//COnstruction du message d'attente
            Embed embedloading = embedBuilderLoading.Build();
            var message = await ReplyAsync(embed: embedloading);//Envoie du message d'attente
            //Recherche de la vidéo
            bool sucess = true;
            Random rnd = new Random();
            Requethttp req = new Requethttp();
            if (_hololivevid == 0)
            {
                randomnumber = rnd.Next(1, 8103);
            }
            else
            {
                randomnumber = _hololivevid;
            }
            DataJsonHololive hololive = await req.GetDataJsonHololive(_urlhololive + randomnumber);
            _hololivevid = hololive.Totalvideo;
            //Envoie de la requette vers l'api et traitement du json reçu
            EmbedAuthorBuilder embedAuthor = new EmbedAuthorBuilder()//Construction de l'auteur du message parce que why not
                .WithName("Hololive Video");
            EmbedBuilder embedBuilderfinal = new EmbedBuilder().WithCurrentTimestamp().WithAuthor(embedAuthor);//Début de la contruction du message final
            if (hololive == null)//Si aucune vidéo n'a était trouver ou qu'il y a eu un problèmes avec l'api
            {
                embedBuilderfinal.WithTitle("Command error")
                    .WithDescription("The API doesn't response succesfuly.");
                sucess = false;
            }
            else//S'il n'y a eu aucun problème
            {
                VideoHololive vid = hololive.Result[0];
                string url = "https://www.youtube.com/watch?v=" + vid.VideoId;
                string vidid = vid.VideoId;
                embedBuilderfinal.WithTitle(vid.VideoName)
                    .WithDescription(vid.Vtuber)
                    .WithUrl(url)
                    .WithColor(color)
                    .WithImageUrl($"https://img.youtube.com/vi/{vidid}/sddefault.jpg")
                    .WithFooter(footer =>
                    {
                        footer.WithText("Powered by Homoliver Api");
                    });//mise en forme du message final avec la vidéo reçu de l'api
            }
            Embed embed = embedBuilderfinal.Build();
            await message.ModifyAsync(msg => msg.Embed = embed);//Modification du message d'attente en message final
            Program.log.WriteCommandToConsole(Context.User.ToString(), "hololive"+" Réussi : "+sucess);
        }

        [Command("sauce")]
        [Summary("Search the sauce of a image")]
        public async Task Sauce(string link)
        {
            Color color = new Color(185, 9, 118);
            EmbedBuilder embedBuilderLoading = new EmbedBuilder()
                .WithTitle("Searching sauce...")
                .WithImageUrl("https://thumbs.gfycat.com/LittleBestAmoeba-max-14mb.gif")
                .WithColor(color);//COnstruction du message d'attente
            Embed embedloading = embedBuilderLoading.Build();
            var message = await ReplyAsync(embed: embedloading);//Envoie du message d'attente
            SauceNETClient sauce = new SauceNETClient("7018a095f6d54e1570bb5b4fd0cbcf20fbf4ed48");
            var result = await sauce.GetSauceAsync(link);//Envoie de la requette pour la ou les sources
            List<Result> sourceurl = result.Results.ToList();//Récuppération de la liste des sources
            EmbedAuthorBuilder embedAuthor = new EmbedAuthorBuilder()//Construction de l'auteur du message parce que why not
                .WithName(Context.Client.CurrentUser.Username)
                .WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle("Sauce Finder")
                .WithAuthor(embedAuthor)
                .WithCurrentTimestamp()
                .WithColor(color)
                .WithFooter(footer =>
                {
                    footer.WithText("Powered by SauceNao Api");
                });//Contruction de la base du messsage avec les sauces
            if (sourceurl.Count == 0)//Si l'on ne trouve aucune source
            {
                embedBuilder.WithDescription("Aucun résultat.");
            }
            else//Si il y a une ou des sources de trouver
            {
                int ind = 0;
                while (ind < sourceurl.Count && ind < 2)//Pour ne pas créer plus de 2 field avec des résultat
                {
                    EmbedFieldBuilder field = new EmbedFieldBuilder().WithName(sourceurl[ind].Name).WithValue(sourceurl[ind].SourceURL);
                    embedBuilder.AddField(field);
                    ind++;
                }
            }
            Embed embed = embedBuilder.Build();
            await message.ModifyAsync(msg => msg.Embed = embed);//Modification du message d'attente en message final
            Program.log.WriteCommandToConsole(Context.User.ToString(), "sauce");
        }
    }
}
