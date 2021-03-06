﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Reddit.Entities;
using System;

namespace Reddit.Migrations
{
    [DbContext(typeof(RedditContext))]
    partial class RedditContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reddit.Models.Post", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("OwnerUserId");

                    b.Property<int>("Score");

                    b.Property<string>("Timestamp");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Reddit");
                });

            modelBuilder.Entity("Reddit.Models.User", b =>
                {
                    b.Property<long?>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<long?>("PostId");

                    b.HasKey("UserId");

                    b.HasIndex("PostId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Reddit.Models.Post", b =>
                {
                    b.HasOne("Reddit.Models.User", "Owner")
                        .WithMany("PostsOfTheUser")
                        .HasForeignKey("OwnerUserId");
                });

            modelBuilder.Entity("Reddit.Models.User", b =>
                {
                    b.HasOne("Reddit.Models.Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId");
                });
#pragma warning restore 612, 618
        }
    }
}
