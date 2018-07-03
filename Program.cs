using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Master_Ferret
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        private DiscordSocketClient client;
        private CommandService commands;
        private IServiceProvider services;

        private string prefix = "!";

        public async Task RunBotAsync()
        {
            client = new DiscordSocketClient();
            commands = new CommandService();
            services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commands)
                .BuildServiceProvider();

            //event subs
            client.Log += Log;
            string botToken = "NDYzNDg4MTU0NTE5ODYzMjk2.DhxRew.XXg9aoONuvTYZnG6H3nXfgI-6Pk";
            await RegisterCommandsAsync();
            await client.LoginAsync(TokenType.Bot, botToken);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            if (message == null) return;
            int argPos = 0;
            if (message.HasStringPrefix(prefix, ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))
            {
                
                var context = new SocketCommandContext(client, message);
                //Console.WriteLine(context.Channel); //Debug
                if (context.Channel.Name == "bot-spam" || context.Channel.Name == "master-ferret")
                {
                    var result = await commands.ExecuteAsync(context, argPos, services);
                    if (!result.IsSuccess)
                    {
                        Console.WriteLine(result.ErrorReason);
                    }
                }
                else
                {
                    await context.Channel.SendMessageAsync(@"This command can only be executed in the ""bot spam"" channel");
                    return;
                }
            } 
        }
    }
}
