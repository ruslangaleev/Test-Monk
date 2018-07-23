﻿// <auto-generated />
using System;
using EmailSender.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EmailSender.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EmailSender.Models.MailStory", b =>
                {
                    b.Property<string>("MailStoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreateAt");

                    b.Property<string>("FailedMessage");

                    b.Property<string>("MailFrom");

                    b.Property<string[]>("Recipients");

                    b.Property<string>("Result");

                    b.Property<string>("Subject");

                    b.HasKey("MailStoryId");

                    b.ToTable("MailStories");
                });
#pragma warning restore 612, 618
        }
    }
}
