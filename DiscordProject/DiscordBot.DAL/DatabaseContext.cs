using DiscordBot.DAL.Models.Items;
using DiscordBot.DAL.Models.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<LoggingEventModel> LoggingEvent { get; set; }
    }
}

//dotnet-ef migrations add LoggingEvent --p../DiscordBot.DAL.Migrations/DiscordBot.DAL.Migrations.csproj --context DiscordBot.DAL.DatabaseContex
//dotnet-ef migrations add LoggingEvent -p../DiscordBot.DAL.Migrations/DiscordBot.DAL.Migrations.csproj --context DiscordBot.DAL.DatabaseContext
