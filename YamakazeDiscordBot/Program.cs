using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YamakazeDiscordBot.Modules.ClasseUtiles;
using YamakazeDiscordBot.Services;

namespace YamakazeDiscordBot
{
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public static DiscordSocketClient _client;
        public static CommandService _commands;
        private IServiceProvider _services;
        private CommandHandler _commandhandler;
        private string _json;
        public static PropertiesJson _prop;
        public static LogConsole log;

        public async Task MainAsync()
        {
            if (!File.Exists("Properties/config.json"))
            {
                Console.WriteLine("Veuillez rentrer le token qui permettra de conecter le bot a discord.");//Poser question a l'utilisateur sur le token
                string tok = Console.ReadLine();//Réccupérer ce que l'utilisateur rentre comme texte.
                Console.WriteLine("Veuillez entrer le préfix que vous voudrais utiliser.");//Demander quel préfix l'utilisateur veux que le bot a.
                string prefix = Console.ReadLine();//Réccupérer ce que l'utilisateur rentre comme texte.
                PropertiesJson prop = new PropertiesJson(tok,prefix);//Créer un objet PropertiesJson avec le token et le prefix en parametre.
                string json = JsonConvert.SerializeObject(prop);//Transformer prop en json dans une variable string.
                File.WriteAllText("Properties/config.json",json);//Ecrire le string dans un fichier .json.
            }
            log = log = new LogConsole();
            _json = File.ReadAllText("Properties/config.json");
            _prop = JsonConvert.DeserializeObject<PropertiesJson>(_json);
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection().AddSingleton(_client).AddSingleton(_commands).BuildServiceProvider();
            _commandhandler = new CommandHandler(_client, _commands, _prop);
            _client.Log += Log;
            //  You can assign your bot token to a string, and pass that in to connect.
            //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
            string token = _prop.Token;
            // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
            // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
            // var token = File.ReadAllText("token.txt");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;
            await _commandhandler.InstallCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
