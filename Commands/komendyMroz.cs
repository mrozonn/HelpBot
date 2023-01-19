using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class komendyMroz : BaseCommandModule
{
    [Command("ping")]
    public async Task PongCommand(CommandContext ctx)
    {
        await ctx.RespondAsync($"Pong!");
    }
}
