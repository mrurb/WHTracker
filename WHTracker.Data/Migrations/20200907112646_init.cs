﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WHTracker.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alliances",
                columns: table => new
                {
                    AllianceID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AllianceName = table.Column<string>(nullable: true),
                    AllianceTicker = table.Column<string>(nullable: true),
                    MemberCount = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alliances", x => x.AllianceID);
                });

            migrationBuilder.CreateTable(
                name: "Corporations",
                columns: table => new
                {
                    CorporationID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CorporationName = table.Column<string>(nullable: true),
                    CorporationTicker = table.Column<string>(nullable: true),
                    MemberCount = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporations", x => x.CorporationID);
                });

            migrationBuilder.CreateTable(
                name: "Killmails",
                columns: table => new
                {
                    KiilmailID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KillmailHash = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Killmails", x => x.KiilmailID);
                });

            migrationBuilder.CreateTable(
                name: "DailyAggregateAlliances",
                columns: table => new
                {
                    DailyAggregateAllianceID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    MembersCount = table.Column<int>(nullable: false),
                    KillsTotal = table.Column<int>(nullable: false),
                    LossesTotal = table.Column<int>(nullable: false),
                    KillsSubCap = table.Column<int>(nullable: false),
                    LossesSubCap = table.Column<int>(nullable: false),
                    KillsCapital = table.Column<int>(nullable: false),
                    LossesCapital = table.Column<int>(nullable: false),
                    KillsStrcture = table.Column<int>(nullable: false),
                    LossesStrcture = table.Column<int>(nullable: false),
                    ISKKilledTotal = table.Column<int>(nullable: false),
                    ISKLostTotal = table.Column<int>(nullable: false),
                    ISKKilledSubCap = table.Column<int>(nullable: false),
                    ISKLostSubCap = table.Column<int>(nullable: false),
                    ISKKilledCapital = table.Column<int>(nullable: false),
                    ISKLostCapital = table.Column<int>(nullable: false),
                    ISKKilledStructure = table.Column<int>(nullable: false),
                    ISKLostStructure = table.Column<int>(nullable: false),
                    DamageDealtTotal = table.Column<int>(nullable: false),
                    DamageTakenTotal = table.Column<int>(nullable: false),
                    DamageDealtSubCap = table.Column<int>(nullable: false),
                    DamageTakenSubCAp = table.Column<int>(nullable: false),
                    DamageDealtCapital = table.Column<int>(nullable: false),
                    DamageTakenCapital = table.Column<int>(nullable: false),
                    DamageDealtStructure = table.Column<int>(nullable: false),
                    DamageTakenStructure = table.Column<int>(nullable: false),
                    PointsKilledTotal = table.Column<int>(nullable: false),
                    PointsLostTotal = table.Column<int>(nullable: false),
                    PointsKilledSubCap = table.Column<int>(nullable: false),
                    PointsLostSubCap = table.Column<int>(nullable: false),
                    PointsKilledCapital = table.Column<int>(nullable: false),
                    PointsLostCapital = table.Column<int>(nullable: false),
                    PointsKilledStructure = table.Column<int>(nullable: false),
                    PointsLostStructure = table.Column<int>(nullable: false),
                    RorqualKills = table.Column<int>(nullable: false),
                    DreadKills = table.Column<int>(nullable: false),
                    CarrierKills = table.Column<int>(nullable: false),
                    FaxesKills = table.Column<int>(nullable: false),
                    MediumStrctureKills = table.Column<int>(nullable: false),
                    LargetrctureKills = table.Column<int>(nullable: false),
                    XLStrctureKills = table.Column<int>(nullable: false),
                    AllianceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyAggregateAlliances", x => x.DailyAggregateAllianceID);
                    table.ForeignKey(
                        name: "FK_DailyAggregateAlliances_Alliances_AllianceID",
                        column: x => x.AllianceID,
                        principalTable: "Alliances",
                        principalColumn: "AllianceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyAggregateCorporations",
                columns: table => new
                {
                    DailyAggregateCorporationID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    MembersCount = table.Column<int>(nullable: false),
                    KillsTotal = table.Column<int>(nullable: false),
                    LossesTotal = table.Column<int>(nullable: false),
                    KillsSubCap = table.Column<int>(nullable: false),
                    LossesSubCap = table.Column<int>(nullable: false),
                    KillsCapital = table.Column<int>(nullable: false),
                    LossesCapital = table.Column<int>(nullable: false),
                    KillsStrcture = table.Column<int>(nullable: false),
                    LossesStrcture = table.Column<int>(nullable: false),
                    ISKKilledTotal = table.Column<int>(nullable: false),
                    ISKLostTotal = table.Column<int>(nullable: false),
                    ISKKilledSubCap = table.Column<int>(nullable: false),
                    ISKLostSubCap = table.Column<int>(nullable: false),
                    ISKKilledCapital = table.Column<int>(nullable: false),
                    ISKLostCapital = table.Column<int>(nullable: false),
                    ISKKilledStructure = table.Column<int>(nullable: false),
                    ISKLostStructure = table.Column<int>(nullable: false),
                    DamageDealtTotal = table.Column<int>(nullable: false),
                    DamageTakenTotal = table.Column<int>(nullable: false),
                    DamageDealtSubCap = table.Column<int>(nullable: false),
                    DamageTakenSubCAp = table.Column<int>(nullable: false),
                    DamageDealtCapital = table.Column<int>(nullable: false),
                    DamageTakenCapital = table.Column<int>(nullable: false),
                    DamageDealtStructure = table.Column<int>(nullable: false),
                    DamageTakenStructure = table.Column<int>(nullable: false),
                    PointsKilledTotal = table.Column<int>(nullable: false),
                    PointsLostTotal = table.Column<int>(nullable: false),
                    PointsKilledSubCap = table.Column<int>(nullable: false),
                    PointsLostSubCap = table.Column<int>(nullable: false),
                    PointsKilledCapital = table.Column<int>(nullable: false),
                    PointsLostCapital = table.Column<int>(nullable: false),
                    PointsKilledStructure = table.Column<int>(nullable: false),
                    PointsLostStructure = table.Column<int>(nullable: false),
                    RorqualKills = table.Column<int>(nullable: false),
                    DreadKills = table.Column<int>(nullable: false),
                    CarrierKills = table.Column<int>(nullable: false),
                    FaxesKills = table.Column<int>(nullable: false),
                    MediumStrctureKills = table.Column<int>(nullable: false),
                    LargetrctureKills = table.Column<int>(nullable: false),
                    XLStrctureKills = table.Column<int>(nullable: false),
                    CorporationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyAggregateCorporations", x => x.DailyAggregateCorporationID);
                    table.ForeignKey(
                        name: "FK_DailyAggregateCorporations_Corporations_CorporationID",
                        column: x => x.CorporationID,
                        principalTable: "Corporations",
                        principalColumn: "CorporationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyAggregateAlliances_AllianceID",
                table: "DailyAggregateAlliances",
                column: "AllianceID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyAggregateCorporations_CorporationID",
                table: "DailyAggregateCorporations",
                column: "CorporationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyAggregateAlliances");

            migrationBuilder.DropTable(
                name: "DailyAggregateCorporations");

            migrationBuilder.DropTable(
                name: "Killmails");

            migrationBuilder.DropTable(
                name: "Alliances");

            migrationBuilder.DropTable(
                name: "Corporations");
        }
    }
}
