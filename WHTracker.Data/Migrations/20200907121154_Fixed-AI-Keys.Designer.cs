﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WHTracker.Data;

namespace WHTracker.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200907121154_Fixed-AI-Keys")]
    partial class FixedAIKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WHTracker.Data.Models.Alliance", b =>
                {
                    b.Property<int>("AllianceId")
                        .HasColumnType("int");

                    b.Property<string>("AllianceName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("AllianceTicker")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MemberCount")
                        .HasColumnType("int");

                    b.HasKey("AllianceId");

                    b.ToTable("Alliances");
                });

            modelBuilder.Entity("WHTracker.Data.Models.Corporation", b =>
                {
                    b.Property<int>("CorporationId")
                        .HasColumnType("int");

                    b.Property<string>("CorporationName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CorporationTicker")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MemberCount")
                        .HasColumnType("int");

                    b.HasKey("CorporationId");

                    b.ToTable("Corporations");
                });

            modelBuilder.Entity("WHTracker.Data.Models.DailyAggregateAlliance", b =>
                {
                    b.Property<int>("DailyAggregateAllianceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AllianceId")
                        .HasColumnType("int");

                    b.Property<int>("CarrierKills")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtSubCap")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtTotal")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenSubCAp")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenTotal")
                        .HasColumnType("int");

                    b.Property<int>("DreadKills")
                        .HasColumnType("int");

                    b.Property<int>("FaxesKills")
                        .HasColumnType("int");

                    b.Property<int>("ISKKilledCapital")
                        .HasColumnType("int");

                    b.Property<int>("ISKKilledStructure")
                        .HasColumnType("int");

                    b.Property<int>("ISKKilledSubCap")
                        .HasColumnType("int");

                    b.Property<int>("ISKKilledTotal")
                        .HasColumnType("int");

                    b.Property<int>("ISKLostCapital")
                        .HasColumnType("int");

                    b.Property<int>("ISKLostStructure")
                        .HasColumnType("int");

                    b.Property<int>("ISKLostSubCap")
                        .HasColumnType("int");

                    b.Property<int>("ISKLostTotal")
                        .HasColumnType("int");

                    b.Property<int>("KillsCapital")
                        .HasColumnType("int");

                    b.Property<int>("KillsStrcture")
                        .HasColumnType("int");

                    b.Property<int>("KillsSubCap")
                        .HasColumnType("int");

                    b.Property<int>("KillsTotal")
                        .HasColumnType("int");

                    b.Property<int>("LargetrctureKills")
                        .HasColumnType("int");

                    b.Property<int>("LossesCapital")
                        .HasColumnType("int");

                    b.Property<int>("LossesStrcture")
                        .HasColumnType("int");

                    b.Property<int>("LossesSubCap")
                        .HasColumnType("int");

                    b.Property<int>("LossesTotal")
                        .HasColumnType("int");

                    b.Property<int>("MediumStrctureKills")
                        .HasColumnType("int");

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.Property<int>("PointsKilledCapital")
                        .HasColumnType("int");

                    b.Property<int>("PointsKilledStructure")
                        .HasColumnType("int");

                    b.Property<int>("PointsKilledSubCap")
                        .HasColumnType("int");

                    b.Property<int>("PointsKilledTotal")
                        .HasColumnType("int");

                    b.Property<int>("PointsLostCapital")
                        .HasColumnType("int");

                    b.Property<int>("PointsLostStructure")
                        .HasColumnType("int");

                    b.Property<int>("PointsLostSubCap")
                        .HasColumnType("int");

                    b.Property<int>("PointsLostTotal")
                        .HasColumnType("int");

                    b.Property<int>("RorqualKills")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("XLStrctureKills")
                        .HasColumnType("int");

                    b.HasKey("DailyAggregateAllianceID");

                    b.HasIndex("AllianceId");

                    b.ToTable("DailyAggregateAlliances");
                });

            modelBuilder.Entity("WHTracker.Data.Models.DailyAggregateCorporation", b =>
                {
                    b.Property<int>("DailyAggregateCorporationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarrierKills")
                        .HasColumnType("int");

                    b.Property<int>("CorporationID")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtSubCap")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtTotal")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenSubCAp")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenTotal")
                        .HasColumnType("int");

                    b.Property<int>("DreadKills")
                        .HasColumnType("int");

                    b.Property<int>("FaxesKills")
                        .HasColumnType("int");

                    b.Property<int>("ISKKilledCapital")
                        .HasColumnType("int");

                    b.Property<int>("ISKKilledStructure")
                        .HasColumnType("int");

                    b.Property<int>("ISKKilledSubCap")
                        .HasColumnType("int");

                    b.Property<int>("ISKKilledTotal")
                        .HasColumnType("int");

                    b.Property<int>("ISKLostCapital")
                        .HasColumnType("int");

                    b.Property<int>("ISKLostStructure")
                        .HasColumnType("int");

                    b.Property<int>("ISKLostSubCap")
                        .HasColumnType("int");

                    b.Property<int>("ISKLostTotal")
                        .HasColumnType("int");

                    b.Property<int>("KillsCapital")
                        .HasColumnType("int");

                    b.Property<int>("KillsStrcture")
                        .HasColumnType("int");

                    b.Property<int>("KillsSubCap")
                        .HasColumnType("int");

                    b.Property<int>("KillsTotal")
                        .HasColumnType("int");

                    b.Property<int>("LargetrctureKills")
                        .HasColumnType("int");

                    b.Property<int>("LossesCapital")
                        .HasColumnType("int");

                    b.Property<int>("LossesStrcture")
                        .HasColumnType("int");

                    b.Property<int>("LossesSubCap")
                        .HasColumnType("int");

                    b.Property<int>("LossesTotal")
                        .HasColumnType("int");

                    b.Property<int>("MediumStrctureKills")
                        .HasColumnType("int");

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.Property<int>("PointsKilledCapital")
                        .HasColumnType("int");

                    b.Property<int>("PointsKilledStructure")
                        .HasColumnType("int");

                    b.Property<int>("PointsKilledSubCap")
                        .HasColumnType("int");

                    b.Property<int>("PointsKilledTotal")
                        .HasColumnType("int");

                    b.Property<int>("PointsLostCapital")
                        .HasColumnType("int");

                    b.Property<int>("PointsLostStructure")
                        .HasColumnType("int");

                    b.Property<int>("PointsLostSubCap")
                        .HasColumnType("int");

                    b.Property<int>("PointsLostTotal")
                        .HasColumnType("int");

                    b.Property<int>("RorqualKills")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("XLStrctureKills")
                        .HasColumnType("int");

                    b.HasKey("DailyAggregateCorporationId");

                    b.HasIndex("CorporationID");

                    b.ToTable("DailyAggregateCorporations");
                });

            modelBuilder.Entity("WHTracker.Data.Models.Killmails", b =>
                {
                    b.Property<int>("KiilmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("KillmailHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("KiilmailId");

                    b.ToTable("Killmails");
                });

            modelBuilder.Entity("WHTracker.Data.Models.DailyAggregateAlliance", b =>
                {
                    b.HasOne("WHTracker.Data.Models.Alliance", "Alliance")
                        .WithMany("DailyAggregateAlliances")
                        .HasForeignKey("AllianceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WHTracker.Data.Models.DailyAggregateCorporation", b =>
                {
                    b.HasOne("WHTracker.Data.Models.Corporation", "Corporation")
                        .WithMany("DailyAggregateCorporations")
                        .HasForeignKey("CorporationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
