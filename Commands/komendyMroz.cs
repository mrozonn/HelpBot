using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity.EventHandling;

public class komendyMroz : BaseCommandModule
{
    //2. Umożliwienie wyboru ról (uprawnień) użytkownikowi i ich automatyczne nadawanie przez Bota
    [Command("role")]
    public async Task RoleCommand(CommandContext ctx)
    {

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

        var interactivity = ctx.Client.GetInteractivity();

        var reactionResult = await interactivity.WaitForReactionAsync(
            x => x.Message == roleMessage &&
            x.User == ctx.User &&
            (x.Emoji == lolEmoji)).ConfigureAwait(false);

        if (reactionResult.Result.Emoji == lolEmoji)
        {
            var role = ctx.Guild.GetRole(1069746048026812477);
            await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
        }

        await roleMessage.DeleteAsync().ConfigureAwait(false);

    }
    [Command("ankieta")]
    [Description("Narzedzie do tworzenia ankiet miedzy dwoma opcjami, użyj cudzysłowiów do każdego parametru")]
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
}
