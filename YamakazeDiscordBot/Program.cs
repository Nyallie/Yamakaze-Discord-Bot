using System;
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

namespace YamakazeDiscordBot
{
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public static DiscordSocketClient _client;
        public static CommandService _commands;
        private IServiceProvider _services;
        private CommandHandler _commandhandler;
        private JObject _json;
        
        public async Task MainAsync()
        {
            if (!File.Exists("Properties/config.json"))
            {
                Console.WriteLine("Le fichier config.json est inexistant. Le bot ne peux pas fonctionner sans se fichier.");
            }
            else
            {
                _json = JObject.Parse(File.ReadAllText("Properties/config.json"));
                _client = new DiscordSocketClient();
                _commands = new CommandService();
                _services = new ServiceCollection().AddSingleton(_client).AddSingleton(_commands).BuildServiceProvider();
                _commandhandler = new CommandHandler(_client, _commands, _json);
                _client.Log += Log;
                //  You can assign your bot token to a string, and pass that in to connect.
                //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
                string token = _json.GetValue("token").ToString();
                if (token.Equals(""))
                {
                    Console.WriteLine("Token non renseigner dans le fichier Properties/config.json. \n" +
                        "Veuillez renseignez votre token et relancer le bot");
                }
                else
                {
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
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask; ;
        }
    }
}
