using DiscordBot.DAL;
using DiscordBot.DAL.Models.Logging;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Core.Services.Logging
{
    public interface ILoggingService
    {
        Task AddLoggingMessage(LoggingEventModel loggingEventModel);
    }
    public class LoggingService : ILoggingService
    {
        private readonly DatabaseContext _context;

        public LoggingService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddLoggingMessage(LoggingEventModel loggingEventModel)
        {
            await _context.LoggingEvent.AddAsync(loggingEventModel).ConfigureAwait(false);
            await _context.SaveChangesAsync();
        }
    }
}
