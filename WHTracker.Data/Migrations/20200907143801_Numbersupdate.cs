using Microsoft.EntityFrameworkCore.Migrations;

namespace WHTracker.Data.Migrations
{
    public partial class Numbersupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DamageTakenSubCAp",
                table: "DailyAggregateCorporations",
                newName: "DamageTakenSubCap");

            migrationBuilder.RenameColumn(
                name: "DamageTakenSubCAp",
                table: "DailyAggregateAlliances",
                newName: "DamageTakenSubCap");

            migrationBuilder.AlterColumn<float>(
                name: "ISKLostTotal",
                table: "DailyAggregateCorporations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKLostSubCap",
                table: "DailyAggregateCorporations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKLostStructure",
                table: "DailyAggregateCorporations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKLostCapital",
                table: "DailyAggregateCorporations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKKilledTotal",
                table: "DailyAggregateCorporations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKKilledSubCap",
                table: "DailyAggregateCorporations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKKilledStructure",
                table: "DailyAggregateCorporations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKKilledCapital",
                table: "DailyAggregateCorporations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKLostTotal",
                table: "DailyAggregateAlliances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKLostSubCap",
                table: "DailyAggregateAlliances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKLostStructure",
                table: "DailyAggregateAlliances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKLostCapital",
                table: "DailyAggregateAlliances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKKilledTotal",
                table: "DailyAggregateAlliances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKKilledSubCap",
                table: "DailyAggregateAlliances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKKilledStructure",
                table: "DailyAggregateAlliances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ISKKilledCapital",
                table: "DailyAggregateAlliances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DamageTakenSubCap",
                table: "DailyAggregateCorporations",
                newName: "DamageTakenSubCAp");

            migrationBuilder.RenameColumn(
                name: "DamageTakenSubCap",
                table: "DailyAggregateAlliances",
                newName: "DamageTakenSubCAp");

            migrationBuilder.AlterColumn<int>(
                name: "ISKLostTotal",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKLostSubCap",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKLostStructure",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKLostCapital",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKKilledTotal",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKKilledSubCap",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKKilledStructure",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKKilledCapital",
                table: "DailyAggregateCorporations",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKLostTotal",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKLostSubCap",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKLostStructure",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKLostCapital",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKKilledTotal",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKKilledSubCap",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKKilledStructure",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ISKKilledCapital",
                table: "DailyAggregateAlliances",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
