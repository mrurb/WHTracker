using Microsoft.EntityFrameworkCore.Migrations;

namespace WHTracker.Data.Migrations
{
    public partial class NewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KillsStrcture",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "LargetrctureKills",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "LossesStrcture",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "MediumStrctureKills",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "PointsKilledCapital",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "PointsKilledStructure",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "PointsKilledSubCap",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "PointsKilledTotal",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "PointsLostCapital",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "PointsLostStructure",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "PointsLostSubCap",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "PointsLostTotal",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "XLStrctureKills",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "KillsStrcture",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "LargetrctureKills",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "LossesStrcture",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "MediumStrctureKills",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "PointsKilledCapital",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "PointsKilledStructure",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "PointsKilledSubCap",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "PointsKilledTotal",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "PointsLostCapital",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "PointsLostStructure",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "PointsLostSubCap",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "PointsLostTotal",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "XLStrctureKills",
                table: "DailyAggregateAlliances");

            migrationBuilder.AddColumn<int>(
                name: "CarrierLosses",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DreadLosses",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FaxesLosses",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KillsStructure",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LargeStructureKills",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LargeStructureLosses",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesStructure",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MediumStructureKills",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MediumStructureLosses",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RorqualLosses",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XLStructureKills",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XLStructureLosses",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarrierLosses",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DreadLosses",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FaxesLosses",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KillsStructure",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LargeStructureKills",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LargeStructureLosses",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesStructure",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MediumStructureKills",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MediumStructureLosses",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RorqualLosses",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XLStructureKills",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XLStructureLosses",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrierLosses",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "DreadLosses",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "FaxesLosses",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "KillsStructure",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "LargeStructureKills",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "LargeStructureLosses",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "LossesStructure",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "MediumStructureKills",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "MediumStructureLosses",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "RorqualLosses",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "XLStructureKills",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "XLStructureLosses",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "CarrierLosses",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "DreadLosses",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "FaxesLosses",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "KillsStructure",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "LargeStructureKills",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "LargeStructureLosses",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "LossesStructure",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "MediumStructureKills",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "MediumStructureLosses",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "RorqualLosses",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "XLStructureKills",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "XLStructureLosses",
                table: "DailyAggregateAlliances");

            migrationBuilder.AddColumn<int>(
                name: "KillsStrcture",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LargetrctureKills",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesStrcture",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MediumStrctureKills",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsKilledCapital",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsKilledStructure",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsKilledSubCap",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsKilledTotal",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsLostCapital",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsLostStructure",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsLostSubCap",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsLostTotal",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XLStrctureKills",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KillsStrcture",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LargetrctureKills",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesStrcture",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MediumStrctureKills",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsKilledCapital",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsKilledStructure",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsKilledSubCap",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsKilledTotal",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsLostCapital",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsLostStructure",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsLostSubCap",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsLostTotal",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XLStrctureKills",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
