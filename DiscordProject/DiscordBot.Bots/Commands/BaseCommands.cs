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
using DiscordBot.Core.Services.Logging;
using DiscordBot.DAL.Models.DiscordUser;
using DiscordBot.DAL.Models.Logging;

namespace DiscordBot.Commands
{
    public class BaseCommands : BaseCommandModule
    {
        private readonly IItemService _itemService;
        private readonly ILoggingService _loggingService;

        public BaseCommands(IItemService itemService, ILoggingService loggingService )
        {
            _itemService = itemService;
            _loggingService = loggingService;
        }

        [Command("Ping")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("pong").ConfigureAwait(false);
        }

        [Command("AddItem")]
        public async Task AddItem(CommandContext ctx, string itemName, string itemDescription)
        {
            var user = new DiscordUserModel {UserId = ctx.Member.Id, DisplayName = ctx.Member.DisplayName };
            var loggingEvent = new LoggingEventModel
            {
                Date = DateTime.UtcNow,
                DiscordDisplayName = user.DisplayName,
                DiscordUserId = user.UserId,
                LoggingType = LoggingTypeEnum.Command,
                Message = "AddItem"
            };
            await _loggingService.AddLoggingMessage(loggingEvent);
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
