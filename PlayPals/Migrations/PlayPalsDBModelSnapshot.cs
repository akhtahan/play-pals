﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlayPals.Services;

#nullable disable

namespace PlayPals.Migrations
{
    [DbContext(typeof(PlayPalsDB))]
    partial class PlayPalsDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("PlayPals.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("User1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User2Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("User1Id");

                    b.HasIndex("User2Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("PlayPals.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLiked")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchedUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchedUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("PlayPals.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChatId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SenderId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PlayPals.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Interest")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PlayPals.Models.Chat", b =>
                {
                    b.HasOne("PlayPals.Models.User", "User1")
                        .WithMany()
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayPals.Models.User", "User2")
                        .WithMany()
                        .HasForeignKey("User2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("PlayPals.Models.Match", b =>
                {
                    b.HasOne("PlayPals.Models.User", "MatchedUser")
                        .WithMany()
                        .HasForeignKey("MatchedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayPals.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MatchedUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PlayPals.Models.Message", b =>
                {
                    b.HasOne("PlayPals.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayPals.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("PlayPals.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
