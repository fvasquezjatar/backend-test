using IngswDev.EntityFramework.Map.Interfaces;
using IngswDev.EntityFramework.Models;
using IngswDev.EntityFramework.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IngswDev.EntityFramework.Map.Entities
{
    public class EventDateMap : IEntityMap
    {
        private readonly EntityTypeBuilder<EventDate> _modelBuilder;

        public EventDateMap(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder.Entity<EventDate>();
        }

        public void Map()
        {
            _modelBuilder.ToTable("TargetDates");

            _modelBuilder.HasKey(key => key.Id)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .ForSqlServerIsClustered()
                .ForSqlServerHasName("TargetDateId");

            _modelBuilder.Property(p => p.TargetDate)
                .IsRequired();

            _modelBuilder.Property(p => p.TimeZone)
                .IsRequired(false);

            _modelBuilder.Property(p => p.Deleted)
                .ForSqlServerHasDefaultValue(false)
                .IsRequired();

            _modelBuilder.HasOne(one => one.Event)
                .WithMany(many => many.TargetDates)
                .HasForeignKey(fk => fk.EventId)
                .OnDelete(DeleteBehavior.Restrict)
                .ForSqlServerHasConstraintName("FK_Event_EventId")
                .IsRequired();
        }
    }
}
