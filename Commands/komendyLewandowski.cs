using System;
using System.ComponentModel;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;



public class komendyLewandowski : BaseCommandModule
{
    [Command("zasady")]
    public async Task ZasadyCommand(CommandContext ctx)
    {

        var ZasadyEmbed = new DiscordEmbedBuilder
        {
            Title = "Zasady Serwera",
            Color = DiscordColor.Yellow,
            Description = "Zasady" + System.Environment.NewLine + "1. Zakaz umieszczania treści obrażających inne rasy i mniejszości narodowe" + System.Environment.NewLine + "2. Zakaz spamowania" + System.Environment.NewLine + "3. Zakaz wysyłania treści NSFW" + System.Environment.NewLine + "4. Zakaz oznaczania bez powodu" + System.Environment.NewLine + "5. Zakaz posiadania i tworzenia multikont na serwerze" + System.Environment.NewLine + "6. Zakaz leakowania danych osobowych i prywatnych informacji takich jak: imię, nazwisko, adres, numer telefonu itp" + System.Environment.NewLine + "7. Admin ma zawsze rację"

        };

        var ZasadyMessage = await ctx.Channel.SendMessageAsync(embed: ZasadyEmbed).ConfigureAwait(false);



    }

    [Command("opgg")]
    public async Task OpggCommand(CommandContext ctx, string nick)
    {
        var OpggEmbed = new DiscordEmbedBuilder

        {
            Title = "Link do strony Opgg z profilem gracza",
            Color = DiscordColor.Blue,
            Description = "Link do opgg oraz do najlepszych obecnie postaci z gry pod względem wygranych " + System.Environment.NewLine + "https://www.op.gg/summoners/eune/" + nick + System.Environment.NewLine + "https://www.op.gg/champions"
        };

        var opggMessage = await ctx.Channel.SendMessageAsync(embed: OpggEmbed).ConfigureAwait(false);

    }
    [Command("Admin")]
    public async Task adminCommand(CommandContext ctx)
    {
        var adminEmbed = new DiscordEmbedBuilder
        {
            Title = "Admin/Admini serwera",
            Color = DiscordColor.Purple,
            Description = "Admini Serwera" + System.Environment.NewLine + "Gabriel Mróz" + System.Environment.NewLine + "Jakub Lewandowski"

        };

        var AdminMessage = await ctx.Channel.SendMessageAsync(embed: adminEmbed).ConfigureAwait(false);

    }

    [Command("losowanie")]
    public async Task LosowanieCommand(CommandContext ctx, int min, int max)
    {
        var random = new Random();
        await ctx.RespondAsync($"Twoja liczba to: {random.Next(min, max)}");
    }
}
    





        
