using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WHTracker.Data.Migrations
{
    public partial class MonthlyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyAggregateAlliances",
                columns: table => new
                {
                    MonthlyAggregateAllianceID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    MembersCount = table.Column<int>(nullable: false),
                    KillsTotal = table.Column<int>(nullable: false),
                    LossesTotal = table.Column<int>(nullable: false),
                    KillsSubCap = table.Column<int>(nullable: false),
                    LossesSubCap = table.Column<int>(nullable: false),
                    KillsPod = table.Column<int>(nullable: false),
                    LossesPod = table.Column<int>(nullable: false),
                    KillsCapital = table.Column<int>(nullable: false),
                    LossesCapital = table.Column<int>(nullable: false),
                    KillsStructure = table.Column<int>(nullable: false),
                    LossesStructure = table.Column<int>(nullable: false),
                    ISKKilledTotal = table.Column<float>(nullable: false),
                    ISKLostTotal = table.Column<float>(nullable: false),
                    ISKKilledPod = table.Column<float>(nullable: false),
                    ISKLostPod = table.Column<float>(nullable: false),
                    ISKKilledSubCap = table.Column<float>(nullable: false),
                    ISKLostSubCap = table.Column<float>(nullable: false),
                    ISKKilledCapital = table.Column<float>(nullable: false),
                    ISKLostCapital = table.Column<float>(nullable: false),
                    ISKKilledStructure = table.Column<float>(nullable: false),
                    ISKLostStructure = table.Column<float>(nullable: false),
                    DamageDealtTotal = table.Column<int>(nullable: false),
                    DamageTakenTotal = table.Column<int>(nullable: false),
                    DamageDealtPod = table.Column<int>(nullable: false),
                    DamageTakenPod = table.Column<int>(nullable: false),
                    DamageDealtSubCap = table.Column<int>(nullable: false),
                    DamageTakenSubCap = table.Column<int>(nullable: false),
                    DamageDealtCapital = table.Column<int>(nullable: false),
                    DamageTakenCapital = table.Column<int>(nullable: false),
                    DamageDealtStructure = table.Column<int>(nullable: false),
                    DamageTakenStructure = table.Column<int>(nullable: false),
                    RorqualKills = table.Column<int>(nullable: false),
                    RorqualLosses = table.Column<int>(nullable: false),
                    DreadKills = table.Column<int>(nullable: false),
                    DreadLosses = table.Column<int>(nullable: false),
                    CarrierKills = table.Column<int>(nullable: false),
                    CarrierLosses = table.Column<int>(nullable: false),
                    FaxesKills = table.Column<int>(nullable: false),
                    FaxesLosses = table.Column<int>(nullable: false),
                    MediumStructureKills = table.Column<int>(nullable: false),
                    MediumStructureLosses = table.Column<int>(nullable: false),
                    LargeStructureKills = table.Column<int>(nullable: false),
                    LargeStructureLosses = table.Column<int>(nullable: false),
                    XLStructureKills = table.Column<int>(nullable: false),
                    XLStructureLosses = table.Column<int>(nullable: false),
                    AllianceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyAggregateAlliances", x => x.MonthlyAggregateAllianceID);
                    table.ForeignKey(
                        name: "FK_MonthlyAggregateAlliances_Alliances_AllianceId",
                        column: x => x.AllianceId,
                        principalTable: "Alliances",
                        principalColumn: "AllianceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyAggregateCorporations",
                columns: table => new
                {
                    MonthlyAggregateCorporationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    MembersCount = table.Column<int>(nullable: false),
                    KillsTotal = table.Column<int>(nullable: false),
                    LossesTotal = table.Column<int>(nullable: false),
                    KillsSubCap = table.Column<int>(nullable: false),
                    LossesSubCap = table.Column<int>(nullable: false),
                    KillsPod = table.Column<int>(nullable: false),
                    LossesPod = table.Column<int>(nullable: false),
                    KillsCapital = table.Column<int>(nullable: false),
                    LossesCapital = table.Column<int>(nullable: false),
                    KillsStructure = table.Column<int>(nullable: false),
                    LossesStructure = table.Column<int>(nullable: false),
                    ISKKilledTotal = table.Column<float>(nullable: false),
                    ISKLostTotal = table.Column<float>(nullable: false),
                    ISKKilledPod = table.Column<float>(nullable: false),
                    ISKLostPod = table.Column<float>(nullable: false),
                    ISKKilledSubCap = table.Column<float>(nullable: false),
                    ISKLostSubCap = table.Column<float>(nullable: false),
                    ISKKilledCapital = table.Column<float>(nullable: false),
                    ISKLostCapital = table.Column<float>(nullable: false),
                    ISKKilledStructure = table.Column<float>(nullable: false),
                    ISKLostStructure = table.Column<float>(nullable: false),
                    DamageDealtTotal = table.Column<int>(nullable: false),
                    DamageTakenTotal = table.Column<int>(nullable: false),
                    DamageDealtPod = table.Column<int>(nullable: false),
                    DamageTakenPod = table.Column<int>(nullable: false),
                    DamageDealtSubCap = table.Column<int>(nullable: false),
                    DamageTakenSubCap = table.Column<int>(nullable: false),
                    DamageDealtCapital = table.Column<int>(nullable: false),
                    DamageTakenCapital = table.Column<int>(nullable: false),
                    DamageDealtStructure = table.Column<int>(nullable: false),
                    DamageTakenStructure = table.Column<int>(nullable: false),
                    RorqualKills = table.Column<int>(nullable: false),
                    RorqualLosses = table.Column<int>(nullable: false),
                    DreadKills = table.Column<int>(nullable: false),
                    DreadLosses = table.Column<int>(nullable: false),
                    CarrierKills = table.Column<int>(nullable: false),
                    CarrierLosses = table.Column<int>(nullable: false),
                    FaxesKills = table.Column<int>(nullable: false),
                    FaxesLosses = table.Column<int>(nullable: false),
                    MediumStructureKills = table.Column<int>(nullable: false),
                    MediumStructureLosses = table.Column<int>(nullable: false),
                    LargeStructureKills = table.Column<int>(nullable: false),
                    LargeStructureLosses = table.Column<int>(nullable: false),
                    XLStructureKills = table.Column<int>(nullable: false),
                    XLStructureLosses = table.Column<int>(nullable: false),
                    CorporationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyAggregateCorporations", x => x.MonthlyAggregateCorporationId);
                    table.ForeignKey(
                        name: "FK_MonthlyAggregateCorporations_Corporations_CorporationID",
                        column: x => x.CorporationID,
                        principalTable: "Corporations",
                        principalColumn: "CorporationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyAggregateAlliances_AllianceId",
                table: "MonthlyAggregateAlliances",
                column: "AllianceId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyAggregateCorporations_CorporationID",
                table: "MonthlyAggregateCorporations",
                column: "CorporationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyAggregateAlliances");

            migrationBuilder.DropTable(
                name: "MonthlyAggregateCorporations");
        }
    }
}
