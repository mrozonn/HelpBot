using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class komendyLewandowski : BaseCommandModule
{
    [Command("ping2")]
    public async Task PongCommand(CommandContext ctx)
    {
        await ctx.RespondAsync($"Pong!");
    }
}
