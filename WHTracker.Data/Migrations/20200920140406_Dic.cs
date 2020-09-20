using Microsoft.EntityFrameworkCore.Migrations;

namespace WHTracker.Data.Migrations
{
    public partial class Dic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DamageDealtDic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageTakenDic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ISKLostDic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ISKkilledDic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "KillsDic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesDic",
                table: "MonthlyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageDealtDic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageTakenDic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ISKLostDic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ISKkilledDic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "KillsDic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesDic",
                table: "MonthlyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageDealtDic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageTakenDic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ISKLostDic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ISKkilledDic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "KillsDic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesDic",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageDealtDic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageTakenDic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ISKLostDic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ISKkilledDic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "KillsDic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesDic",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamageDealtDic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "DamageTakenDic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "ISKLostDic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "ISKkilledDic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "KillsDic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "LossesDic",
                table: "MonthlyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "DamageDealtDic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "DamageTakenDic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "ISKLostDic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "ISKkilledDic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "KillsDic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "LossesDic",
                table: "MonthlyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "DamageDealtDic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "DamageTakenDic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "ISKLostDic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "ISKkilledDic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "KillsDic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "LossesDic",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "DamageDealtDic",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "DamageTakenDic",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "ISKLostDic",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "ISKkilledDic",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "KillsDic",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "LossesDic",
                table: "DailyAggregateAlliances");
        }
    }
}
