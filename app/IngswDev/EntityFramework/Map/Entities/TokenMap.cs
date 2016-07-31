using IngswDev.EntityFramework.Map.Interfaces;
using IngswDev.EntityFramework.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IngswDev.EntityFramework.Map.Entities
{
    public class TokenMap : IEntityMap
    {
        private readonly EntityTypeBuilder<Token> _modelBuilder;

        public TokenMap(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder.Entity<Token>();
        }

        public void Map()
        {
            _modelBuilder.ToTable("Tokens");
            // token indexes
            _modelBuilder.HasKey(key => key.Id)
                .ForSqlServerIsClustered()
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .ForSqlServerHasName("TokenId");

            _modelBuilder.HasIndex(index => index.AccessToken)
                .ForSqlServerHasName("IX_Tokens_AccessToken")
                .ForSqlServerIsClustered(false)
                .IsUnique();

            // token foreign keys
            _modelBuilder.HasOne(one => one.User)
                .WithMany(many => many.AccessTokens)
                .HasForeignKey(fk => fk.UserId)
                .ForSqlServerHasConstraintName("FK_User_UserId")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            _modelBuilder.Property(p => p.UserId)
                .HasMaxLength(32)
                .IsRequired();

            // default values
            _modelBuilder.Property(p => p.Expiration)
                .ForSqlServerHasDefaultValue(DateTime.UtcNow.AddMinutes(30))
                .IsRequired();

        }
    }
}
