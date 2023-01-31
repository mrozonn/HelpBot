using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity.EventHandling;
using DSharpPlus.Interactivity.Enums;

public class komendyMroz : BaseCommandModule
{
    //2. Umożliwienie wyboru ról (uprawnień) użytkownikowi i ich automatyczne nadawanie przez Bota, narazie nie dziala
    [Command("role")]
    [Description("Za pomocą tego polecenia możesz wybrać role dotyczące gier i tego czy chcesz otrzymywać wiadomości od innych użytkowników serwera. (Role DM Closed i DM Open są umowne i nie blokują użytkownikom możliwości pisania do Ciebie. Jeśli jednak nie wyrazisz zgody na otrzymywanie prywatnych wiadomości a takową otrzyamsz, zgłoś to do administracji.")]
    public async Task RoleCommand(CommandContext ctx)
    {
        var interactivity = ctx.Client.GetInteractivity();
        var roleEmbed = new DiscordEmbedBuilder
        {
            Title = "Wybierz jedną lub kilka ról!",
            Color = DiscordColor.Red,
            Description = "Gry:" + System.Environment.NewLine + ":lol: League Of Legends" + System.Environment.NewLine + ":cs: Counter-Strike: Global Offensive" + System.Environment.NewLine + ":apex: Apex: Legends" + System.Environment.NewLine + ":fortnite: Fortnite" + System.Environment.NewLine + ":amogus: Among Us" + System.Environment.NewLine + "DM: " + System.Environment.NewLine + ":open: Open" + System.Environment.NewLine + ":closed: Closed"

        };

        var roleMessage = await ctx.Channel.SendMessageAsync(embed: roleEmbed).ConfigureAwait(false);

        var lolEmoji = DiscordEmoji.FromName(ctx.Client, ":lol:");
        var csEmoji = DiscordEmoji.FromName(ctx.Client, ":cs:");
        var apexEmoji = DiscordEmoji.FromName(ctx.Client, ":apex:");
        var fortniteEmoji = DiscordEmoji.FromName(ctx.Client, ":fortnite:");
        var amogusEmoji = DiscordEmoji.FromName(ctx.Client, ":amogus:");
        var dmOpenEmoji = DiscordEmoji.FromName(ctx.Client, ":dmopen:");
        var dmClosedEmoji = DiscordEmoji.FromName(ctx.Client, ":dmclosed:");

        await roleMessage.CreateReactionAsync(lolEmoji).ConfigureAwait(false);
        await roleMessage.CreateReactionAsync(csEmoji).ConfigureAwait(false);
        await roleMessage.CreateReactionAsync(apexEmoji).ConfigureAwait(false);
        await roleMessage.CreateReactionAsync(fortniteEmoji).ConfigureAwait(false);
        await roleMessage.CreateReactionAsync(amogusEmoji).ConfigureAwait(false);
        await roleMessage.CreateReactionAsync(dmOpenEmoji).ConfigureAwait(false);
        await roleMessage.CreateReactionAsync(dmClosedEmoji).ConfigureAwait(false);


            var reactionResult = await interactivity.WaitForReactionAsync(
                x => x.Message == roleMessage &&
                x.User == x.User &&
                (x.Emoji == lolEmoji || x.Emoji == csEmoji || x.Emoji == apexEmoji || x.Emoji == fortniteEmoji || x.Emoji == amogusEmoji || x.Emoji == dmOpenEmoji || x.Emoji == dmClosedEmoji)).ConfigureAwait(false);




                if (reactionResult.Result.Emoji == lolEmoji)
                {
                    var role = ctx.Guild.GetRole(1069746048026812477);
                    await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
                }
                else if (reactionResult.Result.Emoji == csEmoji)
                {
                    var role = ctx.Guild.GetRole(1070060936934735892);
                    await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
                }
                else if (reactionResult.Result.Emoji == apexEmoji)
                {
                    var role = ctx.Guild.GetRole(1070062939610021908);
                    await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
                }
                else if (reactionResult.Result.Emoji == fortniteEmoji)
                {
                    var role = ctx.Guild.GetRole(1070063401444843633);
                    await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
                }
                else if (reactionResult.Result.Emoji == amogusEmoji)
                {
                    var role = ctx.Guild.GetRole(1069746048026812477);
                    await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
                }
                else if (reactionResult.Result.Emoji == dmOpenEmoji)
                {
                    var role = ctx.Guild.GetRole(1069746048026812477);
                    await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
                }
                else if (reactionResult.Result.Emoji == dmClosedEmoji)
                {
                    var role = ctx.Guild.GetRole(1069746048026812477);
                    await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
                }
            }
    
    //4. Możliwość tworzenia ankiet przez administratora, wymaga uprawnien do banowania użytkownikow - uprawnienia administratora

    [Command("ankieta")]
    [Description("Komenda do tworzenia ankiet miedzy dwoma opcjami, użyj cudzysłowiów do każdego parametru")]
    [RequirePermissions(Permissions.BanMembers)]
    [Hidden]
    public async Task AnkietaCommand(CommandContext ctx, string pytanie, string opcja1, string opcja2)
    {
        
        var ankietaEmbed = new DiscordEmbedBuilder
        {
            Title = pytanie,
            Description = "1:" + opcja1 + System.Environment.NewLine + "2:" + opcja2
        };

        await ctx.Channel.SendMessageAsync("@everyone").ConfigureAwait(false);
        var ankietaMessage = await ctx.Channel.SendMessageAsync(embed: ankietaEmbed).ConfigureAwait(false);

        var oneEmoji = DiscordEmoji.FromName(ctx.Client, ":one:");
        var twoEmoji = DiscordEmoji.FromName(ctx.Client, ":two:");

        await ankietaMessage.CreateReactionAsync(oneEmoji).ConfigureAwait(false);
        await ankietaMessage.CreateReactionAsync(twoEmoji).ConfigureAwait(false);

    }

    //6. Możliwość utworzenia ogłoszenia serwerowego przez administratora w formacie {co}/{kiedy}/{gdzie}, wymaga uprawnien do banowania uzytkownikow - uprawnienia administratora

    [Command("ogloszenie")]
    [Description("Komenda do tworzenia ogloszen serwerowych")]
    [RequirePermissions(Permissions.BanMembers)]
    [Hidden]
    public async Task OgloszenieCommand(CommandContext ctx, string tytul, string opis, string data)
    {

        var ankietaEmbed = new DiscordEmbedBuilder
        {
            Title = tytul,
            Description = "Szczegóły: " + System.Environment.NewLine + opis + System.Environment.NewLine + "Data:" + data
        };

        await ctx.Channel.SendMessageAsync("@everyone").ConfigureAwait(false);
        var ankietaMessage = await ctx.Channel.SendMessageAsync(embed: ankietaEmbed).ConfigureAwait(false);

    }

}
