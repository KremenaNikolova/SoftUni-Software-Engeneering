﻿// <auto-generated />
using System;
using Forum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Forum.Data.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    [Migration("20230605093227_CreateAndSeedDb")]
    partial class CreateAndSeedDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Forum.App.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ff6cfeaa-0991-47ec-b091-61e40f35f9a0"),
                            Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!",
                            Title = "My first post"
                        },
                        new
                        {
                            Id = new Guid("9b5de3d1-0651-45cc-a1cd-8740bf39ca23"),
                            Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!",
                            Title = "My second post"
                        },
                        new
                        {
                            Id = new Guid("a0059fc1-4534-469b-b325-dbfa770479bd"),
                            Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!",
                            Title = "My third post"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
