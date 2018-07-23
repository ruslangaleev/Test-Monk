﻿// <auto-generated />
using System;
using EmailSender.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EmailSender.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20180723130856_NewFiled")]
    partial class NewFiled
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("FailedMessage");

                    b.Property<string>("MailFrom");

                    b.Property<string[]>("Recipients");

                    b.Property<string>("Result");

                    b.Property<DateTime>("SendAt");

                    b.Property<string>("Subject");

                    b.HasKey("MailStoryId");

                    b.ToTable("MailStories");
                });
#pragma warning restore 612, 618
        }
    }
}
