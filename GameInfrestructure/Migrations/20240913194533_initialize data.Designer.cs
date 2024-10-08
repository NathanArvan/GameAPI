﻿// <auto-generated />
using System;
using GameInfrestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameInfrestructure.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20240913194533_initialize data")]
    partial class initializedata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CharacterItems", b =>
                {
                    b.Property<int>("CharacterIds")
                        .HasColumnType("int");

                    b.Property<int>("ItemIds")
                        .HasColumnType("int");

                    b.HasKey("CharacterIds", "ItemIds");

                    b.HasIndex("ItemIds");

                    b.ToTable("CharacterItems");
                });

            modelBuilder.Entity("GameDomain.Abilities.Ability", b =>
                {
                    b.Property<int>("AbilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbilityId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<int>("RuleSetId")
                        .HasColumnType("int");

                    b.HasKey("AbilityId");

                    b.HasIndex("RuleSetId");

                    b.ToTable("Abilities");

                    b.HasData(
                        new
                        {
                            AbilityId = 1,
                            Description = "",
                            Duration = 0,
                            Name = "Shoot Arrow",
                            Range = 0,
                            RuleSetId = 1
                        });
                });

            modelBuilder.Entity("GameDomain.Battles.Battle", b =>
                {
                    b.Property<int?>("BattleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("BattleId"), 1L, 1);

                    b.Property<int>("RuleSetId")
                        .HasColumnType("int");

                    b.Property<int?>("Turn")
                        .HasColumnType("int");

                    b.HasKey("BattleId");

                    b.HasIndex("RuleSetId");

                    b.ToTable("Batttles");
                });

            modelBuilder.Entity("GameDomain.Campaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampaignId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("GameDomain.Characters.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"), 1L, 1);

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<int>("Actions")
                        .HasColumnType("int");

                    b.Property<int>("ArcaneVision")
                        .HasColumnType("int");

                    b.Property<int>("BattleId")
                        .HasColumnType("int");

                    b.Property<decimal>("CarryingCapacity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Evasion")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<int>("ManaPoints")
                        .HasColumnType("int");

                    b.Property<int>("MartialVision")
                        .HasColumnType("int");

                    b.Property<int>("Movement")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Poise")
                        .HasColumnType("int");

                    b.Property<int>("StaminaPoints")
                        .HasColumnType("int");

                    b.Property<int?>("TokenId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("BattleId");

                    b.HasIndex("TokenId");

                    b.ToTable("Character", (string)null);
                });

            modelBuilder.Entity("GameDomain.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("GameDomain.ItemAbility", b =>
                {
                    b.Property<int>("ItemAbilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemAbilityId"), 1L, 1);

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("ItemAbilityId");

                    b.ToTable("ItemAbility");

                    b.HasData(
                        new
                        {
                            ItemAbilityId = 1,
                            AbilityId = 1,
                            ItemId = 1
                        });
                });

            modelBuilder.Entity("GameDomain.Items.Item", b =>
                {
                    b.Property<int?>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ItemId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RuleSetId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemId");

                    b.HasIndex("RuleSetId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Name = "Bow",
                            RuleSetId = 1,
                            Weight = 0m
                        });
                });

            modelBuilder.Entity("GameDomain.Maps.Map", b =>
                {
                    b.Property<int?>("MapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("MapId"), 1L, 1);

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("MapId");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("GameDomain.RuleSets.RuleSet", b =>
                {
                    b.Property<int>("RuleSetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RuleSetId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RuleSetId");

                    b.ToTable("RuleSets");

                    b.HasData(
                        new
                        {
                            RuleSetId = 1,
                            Name = "Test"
                        });
                });

            modelBuilder.Entity("GameDomain.Tokens.Token", b =>
                {
                    b.Property<int?>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("TokenId"), 1L, 1);

                    b.Property<int?>("MapId")
                        .HasColumnType("int");

                    b.Property<int?>("xPosition")
                        .HasColumnType("int");

                    b.Property<int?>("yPosition")
                        .HasColumnType("int");

                    b.HasKey("TokenId");

                    b.HasIndex("MapId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("GameDomain.Tokens.TokenImage", b =>
                {
                    b.Property<int?>("TokenImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("TokenImageId"), 1L, 1);

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("TokenId")
                        .HasColumnType("int");

                    b.HasKey("TokenImageId");

                    b.HasIndex("TokenId")
                        .IsUnique()
                        .HasFilter("[TokenId] IS NOT NULL");

                    b.ToTable("TokenImages");
                });

            modelBuilder.Entity("ItemAbilities", b =>
                {
                    b.Property<int>("AbilityIds")
                        .HasColumnType("int");

                    b.Property<int>("ItemIds")
                        .HasColumnType("int");

                    b.HasKey("AbilityIds", "ItemIds");

                    b.HasIndex("ItemIds");

                    b.ToTable("ItemAbilities");
                });

            modelBuilder.Entity("CharacterItems", b =>
                {
                    b.HasOne("GameDomain.Characters.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterIds")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameDomain.Items.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemIds")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameDomain.Abilities.Ability", b =>
                {
                    b.HasOne("GameDomain.RuleSets.RuleSet", "RuleSet")
                        .WithMany("Abilities")
                        .HasForeignKey("RuleSetId");

                    b.Navigation("RuleSet");
                });

            modelBuilder.Entity("GameDomain.Battles.Battle", b =>
                {
                    b.HasOne("GameDomain.RuleSets.RuleSet", "RuleSet")
                        .WithMany("Battles")
                        .HasForeignKey("RuleSetId");

                    b.Navigation("RuleSet");
                });

            modelBuilder.Entity("GameDomain.Characters.Character", b =>
                {
                    b.HasOne("GameDomain.Battles.Battle", "Battle")
                        .WithMany("Characters")
                        .HasForeignKey("BattleId");

                    b.HasOne("GameDomain.Tokens.Token", "Token")
                        .WithMany("Characters")
                        .HasForeignKey("TokenId");

                    b.Navigation("Battle");

                    b.Navigation("Token");
                });

            modelBuilder.Entity("GameDomain.Items.Item", b =>
                {
                    b.HasOne("GameDomain.RuleSets.RuleSet", "RuleSet")
                        .WithMany("Items")
                        .HasForeignKey("RuleSetId");

                    b.Navigation("RuleSet");
                });

            modelBuilder.Entity("GameDomain.Tokens.Token", b =>
                {
                    b.HasOne("GameDomain.Maps.Map", null)
                        .WithMany("Tokens")
                        .HasForeignKey("MapId");
                });

            modelBuilder.Entity("GameDomain.Tokens.TokenImage", b =>
                {
                    b.HasOne("GameDomain.Tokens.Token", null)
                        .WithOne("Image")
                        .HasForeignKey("GameDomain.Tokens.TokenImage", "TokenId");
                });

            modelBuilder.Entity("ItemAbilities", b =>
                {
                    b.HasOne("GameDomain.Abilities.Ability", null)
                        .WithMany()
                        .HasForeignKey("AbilityIds")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameDomain.Items.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemIds")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameDomain.Battles.Battle", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("GameDomain.Maps.Map", b =>
                {
                    b.Navigation("Tokens");
                });

            modelBuilder.Entity("GameDomain.RuleSets.RuleSet", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("Battles");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("GameDomain.Tokens.Token", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}
