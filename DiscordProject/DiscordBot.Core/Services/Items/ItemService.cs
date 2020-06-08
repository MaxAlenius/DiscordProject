using DiscordBot.DAL;
using DiscordBot.DAL.Models.Items;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Core.Services.Items
{
    public interface IItemService
    {
        Task<Item> GetItemByNameAsync(string itemName);

        Task AddItemAsync(string itemName, string description);
    }

    public class ItemService : IItemService
    {
        private readonly DatabaseContext _context;

        public ItemService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddItemAsync(string itemName, string description)
        {
            await _context.Items.AddAsync(new Item { Name=itemName, Description=description}).ConfigureAwait(false);
            await _context.SaveChangesAsync();
        }

        public async Task<Item> GetItemByNameAsync(string itemName)
        {
            return await _context.Items.FirstOrDefaultAsync(x => x.Name.ToLower() == itemName.ToLower()).ConfigureAwait(false);
        }
    }
}
