using DiscordBot.DAL;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.DAL.Models.Items;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DiscordBot.Core.Services.Items;

namespace DiscordBot.Commands
{
    public class BaseCommands : BaseCommandModule
    {
        private readonly IItemService _itemService;

        public BaseCommands(IItemService itemService)
        {
            _itemService = itemService;
        }

        [Command("Ping")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("pong").ConfigureAwait(false);
        }

        [Command("AddItem")]
        public async Task AddItem(CommandContext ctx, string itemName, string itemDescription)
        {
            await _itemService.AddItemAsync(itemName, itemDescription);
            await ctx.Channel.SendMessageAsync("Item added").ConfigureAwait(false);
        }

        [Command("GetItem")]
        public async Task GetItem(CommandContext ctx, string itemName)
        {

            Item item = await _itemService.GetItemByNameAsync(itemName).ConfigureAwait(false);

            if (item == null)
            {
                await ctx.Channel.SendMessageAsync($"There is no item called {itemName}");
                return;
            }

            await ctx.Channel.SendMessageAsync($"Name: {item.Name}, Description: {item.Description}");
        }
    }
}
