using Microsoft.EntityFrameworkCore.Migrations;

namespace WHTracker.Data.Migrations
{
    public partial class Hic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DamageDealtHic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageTakenHic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ISKLostHic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ISKkilledHic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "KillsHic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesHic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageDealtHic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageTakenHic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ISKLostHic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ISKkilledHic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "KillsHic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesHic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageDealtHic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageTakenHic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ISKLostHic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ISKkilledHic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "KillsHic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesHic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageDealtHic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageTakenHic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ISKLostHic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ISKkilledHic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "KillsHic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesHic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamageDealtHic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "DamageTakenHic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "ISKLostHic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "ISKkilledHic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "KillsHic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "LossesHic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "DamageDealtHic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "DamageTakenHic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "ISKLostHic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "ISKkilledHic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "KillsHic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "LossesHic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "DamageDealtHic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "DamageTakenHic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "ISKLostHic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "ISKkilledHic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "KillsHic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "LossesHic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "DamageDealtHic",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "DamageTakenHic",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "ISKLostHic",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "ISKkilledHic",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "KillsHic",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "LossesHic",
                table: "DailyAggregateAlliances");
        }
    }
}
