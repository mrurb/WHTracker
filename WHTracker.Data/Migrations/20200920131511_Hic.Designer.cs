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
    [Migration("20200920131511_Hic")]
    partial class Hic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WHTracker.Data.Models.Alliance", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MemberCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Ticker")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Alliances");
                });

            modelBuilder.Entity("WHTracker.Data.Models.Corporation", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MemberCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Ticker")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

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

                    b.Property<int>("CarrierLosses")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtHic")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtPod")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtSubCap")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtTotal")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenHic")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenPod")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenSubCap")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenTotal")
                        .HasColumnType("int");

                    b.Property<int>("DreadKills")
                        .HasColumnType("int");

                    b.Property<int>("DreadLosses")
                        .HasColumnType("int");

                    b.Property<int>("FaxesKills")
                        .HasColumnType("int");

                    b.Property<int>("FaxesLosses")
                        .HasColumnType("int");

                    b.Property<float>("ISKKilledCapital")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledPod")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledStructure")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledSubCap")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledTotal")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostCapital")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostHic")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostPod")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostStructure")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostSubCap")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostTotal")
                        .HasColumnType("float");

                    b.Property<float>("ISKkilledHic")
                        .HasColumnType("float");

                    b.Property<int>("KillsCapital")
                        .HasColumnType("int");

                    b.Property<int>("KillsHic")
                        .HasColumnType("int");

                    b.Property<int>("KillsPod")
                        .HasColumnType("int");

                    b.Property<int>("KillsStructure")
                        .HasColumnType("int");

                    b.Property<int>("KillsSubCap")
                        .HasColumnType("int");

                    b.Property<int>("KillsTotal")
                        .HasColumnType("int");

                    b.Property<int>("LargeStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("LargeStructureLosses")
                        .HasColumnType("int");

                    b.Property<int>("LossesCapital")
                        .HasColumnType("int");

                    b.Property<int>("LossesHic")
                        .HasColumnType("int");

                    b.Property<int>("LossesPod")
                        .HasColumnType("int");

                    b.Property<int>("LossesStructure")
                        .HasColumnType("int");

                    b.Property<int>("LossesSubCap")
                        .HasColumnType("int");

                    b.Property<int>("LossesTotal")
                        .HasColumnType("int");

                    b.Property<int>("MediumStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("MediumStructureLosses")
                        .HasColumnType("int");

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.Property<int>("RorqualKills")
                        .HasColumnType("int");

                    b.Property<int>("RorqualLosses")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("XLStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("XLStructureLosses")
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

                    b.Property<int>("CarrierLosses")
                        .HasColumnType("int");

                    b.Property<int>("CorporationID")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtHic")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtPod")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtSubCap")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtTotal")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenHic")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenPod")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenSubCap")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenTotal")
                        .HasColumnType("int");

                    b.Property<int>("DreadKills")
                        .HasColumnType("int");

                    b.Property<int>("DreadLosses")
                        .HasColumnType("int");

                    b.Property<int>("FaxesKills")
                        .HasColumnType("int");

                    b.Property<int>("FaxesLosses")
                        .HasColumnType("int");

                    b.Property<float>("ISKKilledCapital")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledPod")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledStructure")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledSubCap")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledTotal")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostCapital")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostHic")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostPod")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostStructure")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostSubCap")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostTotal")
                        .HasColumnType("float");

                    b.Property<float>("ISKkilledHic")
                        .HasColumnType("float");

                    b.Property<int>("KillsCapital")
                        .HasColumnType("int");

                    b.Property<int>("KillsHic")
                        .HasColumnType("int");

                    b.Property<int>("KillsPod")
                        .HasColumnType("int");

                    b.Property<int>("KillsStructure")
                        .HasColumnType("int");

                    b.Property<int>("KillsSubCap")
                        .HasColumnType("int");

                    b.Property<int>("KillsTotal")
                        .HasColumnType("int");

                    b.Property<int>("LargeStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("LargeStructureLosses")
                        .HasColumnType("int");

                    b.Property<int>("LossesCapital")
                        .HasColumnType("int");

                    b.Property<int>("LossesHic")
                        .HasColumnType("int");

                    b.Property<int>("LossesPod")
                        .HasColumnType("int");

                    b.Property<int>("LossesStructure")
                        .HasColumnType("int");

                    b.Property<int>("LossesSubCap")
                        .HasColumnType("int");

                    b.Property<int>("LossesTotal")
                        .HasColumnType("int");

                    b.Property<int>("MediumStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("MediumStructureLosses")
                        .HasColumnType("int");

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.Property<int>("RorqualKills")
                        .HasColumnType("int");

                    b.Property<int>("RorqualLosses")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("XLStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("XLStructureLosses")
                        .HasColumnType("int");

                    b.HasKey("DailyAggregateCorporationId");

                    b.HasIndex("CorporationID");

                    b.ToTable("DailyAggregateCorporations");
                });

            modelBuilder.Entity("WHTracker.Data.Models.Killmails", b =>
                {
                    b.Property<int>("KiilmailId")
                        .HasColumnType("int");

                    b.Property<string>("KillmailHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("KiilmailId");

                    b.ToTable("Killmails");
                });

            modelBuilder.Entity("WHTracker.Data.Models.MonthlyAggregateAlliance", b =>
                {
                    b.Property<int>("MonthlyAggregateAllianceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AllianceId")
                        .HasColumnType("int");

                    b.Property<int>("CarrierKills")
                        .HasColumnType("int");

                    b.Property<int>("CarrierLosses")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtHic")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtPod")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtSubCap")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtTotal")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenHic")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenPod")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenSubCap")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenTotal")
                        .HasColumnType("int");

                    b.Property<int>("DreadKills")
                        .HasColumnType("int");

                    b.Property<int>("DreadLosses")
                        .HasColumnType("int");

                    b.Property<int>("FaxesKills")
                        .HasColumnType("int");

                    b.Property<int>("FaxesLosses")
                        .HasColumnType("int");

                    b.Property<float>("ISKKilledCapital")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledPod")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledStructure")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledSubCap")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledTotal")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostCapital")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostHic")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostPod")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostStructure")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostSubCap")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostTotal")
                        .HasColumnType("float");

                    b.Property<float>("ISKkilledHic")
                        .HasColumnType("float");

                    b.Property<int>("KillsCapital")
                        .HasColumnType("int");

                    b.Property<int>("KillsHic")
                        .HasColumnType("int");

                    b.Property<int>("KillsPod")
                        .HasColumnType("int");

                    b.Property<int>("KillsStructure")
                        .HasColumnType("int");

                    b.Property<int>("KillsSubCap")
                        .HasColumnType("int");

                    b.Property<int>("KillsTotal")
                        .HasColumnType("int");

                    b.Property<int>("LargeStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("LargeStructureLosses")
                        .HasColumnType("int");

                    b.Property<int>("LossesCapital")
                        .HasColumnType("int");

                    b.Property<int>("LossesHic")
                        .HasColumnType("int");

                    b.Property<int>("LossesPod")
                        .HasColumnType("int");

                    b.Property<int>("LossesStructure")
                        .HasColumnType("int");

                    b.Property<int>("LossesSubCap")
                        .HasColumnType("int");

                    b.Property<int>("LossesTotal")
                        .HasColumnType("int");

                    b.Property<int>("MediumStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("MediumStructureLosses")
                        .HasColumnType("int");

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.Property<int>("RorqualKills")
                        .HasColumnType("int");

                    b.Property<int>("RorqualLosses")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("XLStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("XLStructureLosses")
                        .HasColumnType("int");

                    b.HasKey("MonthlyAggregateAllianceID");

                    b.HasIndex("AllianceId");

                    b.ToTable("MonthlyAggregateAlliances");
                });

            modelBuilder.Entity("WHTracker.Data.Models.MonthlyAggregateCorporation", b =>
                {
                    b.Property<int>("MonthlyAggregateCorporationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarrierKills")
                        .HasColumnType("int");

                    b.Property<int>("CarrierLosses")
                        .HasColumnType("int");

                    b.Property<int>("CorporationID")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtHic")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtPod")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtSubCap")
                        .HasColumnType("int");

                    b.Property<int>("DamageDealtTotal")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenCapital")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenHic")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenPod")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenStructure")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenSubCap")
                        .HasColumnType("int");

                    b.Property<int>("DamageTakenTotal")
                        .HasColumnType("int");

                    b.Property<int>("DreadKills")
                        .HasColumnType("int");

                    b.Property<int>("DreadLosses")
                        .HasColumnType("int");

                    b.Property<int>("FaxesKills")
                        .HasColumnType("int");

                    b.Property<int>("FaxesLosses")
                        .HasColumnType("int");

                    b.Property<float>("ISKKilledCapital")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledPod")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledStructure")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledSubCap")
                        .HasColumnType("float");

                    b.Property<float>("ISKKilledTotal")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostCapital")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostHic")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostPod")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostStructure")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostSubCap")
                        .HasColumnType("float");

                    b.Property<float>("ISKLostTotal")
                        .HasColumnType("float");

                    b.Property<float>("ISKkilledHic")
                        .HasColumnType("float");

                    b.Property<int>("KillsCapital")
                        .HasColumnType("int");

                    b.Property<int>("KillsHic")
                        .HasColumnType("int");

                    b.Property<int>("KillsPod")
                        .HasColumnType("int");

                    b.Property<int>("KillsStructure")
                        .HasColumnType("int");

                    b.Property<int>("KillsSubCap")
                        .HasColumnType("int");

                    b.Property<int>("KillsTotal")
                        .HasColumnType("int");

                    b.Property<int>("LargeStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("LargeStructureLosses")
                        .HasColumnType("int");

                    b.Property<int>("LossesCapital")
                        .HasColumnType("int");

                    b.Property<int>("LossesHic")
                        .HasColumnType("int");

                    b.Property<int>("LossesPod")
                        .HasColumnType("int");

                    b.Property<int>("LossesStructure")
                        .HasColumnType("int");

                    b.Property<int>("LossesSubCap")
                        .HasColumnType("int");

                    b.Property<int>("LossesTotal")
                        .HasColumnType("int");

                    b.Property<int>("MediumStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("MediumStructureLosses")
                        .HasColumnType("int");

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.Property<int>("RorqualKills")
                        .HasColumnType("int");

                    b.Property<int>("RorqualLosses")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("XLStructureKills")
                        .HasColumnType("int");

                    b.Property<int>("XLStructureLosses")
                        .HasColumnType("int");

                    b.HasKey("MonthlyAggregateCorporationId");

                    b.HasIndex("CorporationID");

                    b.ToTable("MonthlyAggregateCorporations");
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

            modelBuilder.Entity("WHTracker.Data.Models.MonthlyAggregateAlliance", b =>
                {
                    b.HasOne("WHTracker.Data.Models.Alliance", "Alliance")
                        .WithMany("MonthlyAggregateAlliances")
                        .HasForeignKey("AllianceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WHTracker.Data.Models.MonthlyAggregateCorporation", b =>
                {
                    b.HasOne("WHTracker.Data.Models.Corporation", "corporation")
                        .WithMany("MonthlyAggregateCorporations")
                        .HasForeignKey("CorporationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
