using IngswDev.EntityFramework.Map.Interfaces;
using IngswDev.EntityFramework.Models;
using IngswDev.EntityFramework.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IngswDev.EntityFramework.Map.Entities
{
    public class EventMap : IEntityMap
    {
        private readonly EntityTypeBuilder<Event> _modelBuilder;

        public EventMap(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder.Entity<Event>();
        }

        public void Map()
        {
            _modelBuilder.ToTable("Events");

            _modelBuilder.HasKey(key => key.Id)
                .ForSqlServerIsClustered()
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .ForSqlServerHasName("EventId");

            _modelBuilder.Property(p => p.Title)
                .IsRequired();

            _modelBuilder.Property(p => p.Location)
                .IsRequired(false);

            _modelBuilder.Property(p => p.Description)
                .IsRequired(false);

            _modelBuilder.Property(p => p.ImageUri)
                .IsRequired();

            _modelBuilder.Property(p => p.Highlight)
                .ForSqlServerHasDefaultValue(false)
                .IsRequired();

            _modelBuilder.HasMany(many => many.TargetDates)
                .WithOne(one => one.Event)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
