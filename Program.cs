using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Logging;

namespace HelpBot
{
    class Program
    {
        //testowa zmiana kurczak
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {

            var discord = new DiscordClient(new DiscordConfiguration()
            {


                //token
                Token = "MTA1MTE1NTU0OTY1MzMyMzg2Nw.GlIPwg.Pq8b_Ct4pE4JrMB2brqQVUswmDKOIedZhB2RFA",
                TokenType = TokenType.Bot,
                //uprawnienia
                Intents = DiscordIntents.All,
                //logi w command linie
                MinimumLogLevel = LogLevel.Debug,


            });


            discord.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromMinutes(2)
            });

            //implementacja komend poprzedzonych prefixem
            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" } //ustawienie prefixu
            });

            commands.RegisterCommands<komendyMroz>();
            commands.RegisterCommands<komendyLewandowski>();

            await discord.ConnectAsync();
            await Task.Delay(-1);


        }


    }
}
//test