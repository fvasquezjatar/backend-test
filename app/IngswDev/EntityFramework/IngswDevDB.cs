using IngswDev.EntityFramework.Map;
using IngswDev.EntityFramework.Models;
using IngswDev.EntityFramework.Models.Entities;
using IngswDev.EntityFramework.Models.Security;
using Microsoft.EntityFrameworkCore;

namespace IngswDev.EntityFramework
{
    public sealed class IngswDevDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Token> AccessTokens { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDate> TargetDates { get; set; }

        public IngswDevDB(DbContextOptions options)
            : base(options)
        {
            Database.Migrate();
        }

        public IngswDevDB(DbContextOptionsBuilder builder)
            : base(builder.Options)
        {
            Database.Migrate();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddCustomTypeConfigurations();
            base.OnModelCreating(modelBuilder);
        }
    }
}
