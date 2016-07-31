using IngswDev.EntityFramework.Map.Interfaces;
using IngswDev.EntityFramework.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IngswDev.EntityFramework.Map.Entities
{
    public class UserMap : IEntityMap
    {
        private readonly EntityTypeBuilder<User> _modelBuilder;

        public UserMap(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder.Entity<User>();
        }

        public void Map()
        {
            _modelBuilder.ToTable("Users");
            // user indexes 
            _modelBuilder.HasKey(key => key.Id)
                .ForSqlServerIsClustered()
                .ForSqlServerHasName("UserId");

            _modelBuilder.HasIndex(index => index.Email)
                .ForSqlServerIsClustered(false)
                .ForSqlServerHasName("IX_Email")
                .IsUnique();

            _modelBuilder.HasIndex(index => index.Username)
                .ForSqlServerIsClustered(false)
                .IsUnique();

            // Navigations properties
            _modelBuilder.HasMany(many => many.AccessTokens)
                .WithOne(one => one.User)
                .OnDelete(DeleteBehavior.Cascade);

            // user data validations
            _modelBuilder.Property(p => p.Id)
                .HasMaxLength(32)
                .IsRequired();
            _modelBuilder.Property(p => p.Email)
                .HasMaxLength(256)
                .IsRequired();
            _modelBuilder.Property(p => p.Username)
                .HasMaxLength(256)
                .IsRequired();
            _modelBuilder.Property(p => p.Name)
                .IsRequired(false);
            _modelBuilder.Property(p => p.PasswordHash)
                .IsRequired();
        }
    }
}
