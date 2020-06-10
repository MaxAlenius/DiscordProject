using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.DAL.Models.Logging
{
    public enum LoggingTypeEnum
    {
        Command,
        UserEvent,
        VoiceState
    }
    public class LoggingEventModel : Entity
    {
        public LoggingTypeEnum LoggingType { get; set; }
        public DateTime Date { get; set; }
        public ulong DiscordUserId { get; set; }
        public string Message { get; set; }
        public string DiscordDisplayName { get; set; }
    }
}
