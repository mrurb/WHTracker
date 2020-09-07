using Microsoft.EntityFrameworkCore.Migrations;

namespace WHTracker.Data.Migrations
{
    public partial class pods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DamageDealtPod",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageTakenPod",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ISKKilledPod",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ISKLostPod",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "KillsPod",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesPod",
                table: "DailyAggregateCorporations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageDealtPod",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageTakenPod",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ISKKilledPod",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ISKLostPod",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "KillsPod",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LossesPod",
                table: "DailyAggregateAlliances",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamageDealtPod",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "DamageTakenPod",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "ISKKilledPod",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "ISKLostPod",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "KillsPod",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "LossesPod",
                table: "DailyAggregateCorporations");

            migrationBuilder.DropColumn(
                name: "DamageDealtPod",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "DamageTakenPod",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "ISKKilledPod",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "ISKLostPod",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "KillsPod",
                table: "DailyAggregateAlliances");

            migrationBuilder.DropColumn(
                name: "LossesPod",
                table: "DailyAggregateAlliances");
        }
    }
}
