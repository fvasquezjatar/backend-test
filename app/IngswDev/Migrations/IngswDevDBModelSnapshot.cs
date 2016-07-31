using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IngswDev.EntityFramework;

namespace IngswDev.Migrations
{
    [DbContext(typeof(IngswDevDB))]
    partial class IngswDevDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IngswDev.EntityFramework.Models.Entities.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("Highlight")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:DefaultValue", false);

                    b.Property<string>("ImageUri")
                        .IsRequired();

                    b.Property<string>("Location");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true)
                        .HasAnnotation("SqlServer:Name", "EventId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.ToTable("Events");
                });

            modelBuilder.Entity("IngswDev.EntityFramework.Models.Entities.EventDate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:DefaultValue", false);

                    b.Property<long>("EventId");

                    b.Property<DateTime>("TargetDate");

                    b.Property<string>("TimeZone");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true)
                        .HasAnnotation("SqlServer:Name", "TargetDateId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("EventId");

                    b.ToTable("TargetDates");
                });

            modelBuilder.Entity("IngswDev.EntityFramework.Models.Security.Token", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<DateTime>("Expiration")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:DefaultValue", new DateTime(2016, 7, 31, 3, 7, 38, 553, DateTimeKind.Utc));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true)
                        .HasAnnotation("SqlServer:Name", "TokenId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("AccessToken")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", false)
                        .HasAnnotation("SqlServer:Name", "IX_Tokens_AccessToken");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("IngswDev.EntityFramework.Models.Security.User", b =>
                {
                    b.Property<string>("Id")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Name");

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true)
                        .HasAnnotation("SqlServer:Name", "UserId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", false)
                        .HasAnnotation("SqlServer:Name", "IX_Email");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IngswDev.EntityFramework.Models.Entities.EventDate", b =>
                {
                    b.HasOne("IngswDev.EntityFramework.Models.Entities.Event", "Event")
                        .WithMany("TargetDates")
                        .HasForeignKey("EventId")
                        .HasAnnotation("SqlServer:Name", "FK_Event_EventId");
                });

            modelBuilder.Entity("IngswDev.EntityFramework.Models.Security.Token", b =>
                {
                    b.HasOne("IngswDev.EntityFramework.Models.Security.User", "User")
                        .WithMany("AccessTokens")
                        .HasForeignKey("UserId")
                        .HasAnnotation("SqlServer:Name", "FK_User_UserId");
                });
        }
    }
}
