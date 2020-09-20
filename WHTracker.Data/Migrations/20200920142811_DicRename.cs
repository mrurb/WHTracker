using Microsoft.EntityFrameworkCore.Migrations;

namespace WHTracker.Data.Migrations
{
    public partial class DicRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISKkilledDic",
                table: "MonthlyAggregateCorporations",
                newName: "ISKKilledDic");

            migrationBuilder.RenameColumn(
                name: "ISKkilledDic",
                table: "MonthlyAggregateAlliances",
                newName: "ISKKilledDic");

            migrationBuilder.RenameColumn(
                name: "ISKkilledDic",
                table: "DailyAggregateCorporations",
                newName: "ISKKilledDic");

            migrationBuilder.RenameColumn(
                name: "ISKkilledDic",
                table: "DailyAggregateAlliances",
                newName: "ISKKilledDic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISKKilledDic",
                table: "MonthlyAggregateCorporations",
                newName: "ISKkilledDic");

            migrationBuilder.RenameColumn(
                name: "ISKKilledDic",
                table: "MonthlyAggregateAlliances",
                newName: "ISKkilledDic");

            migrationBuilder.RenameColumn(
                name: "ISKKilledDic",
                table: "DailyAggregateCorporations",
                newName: "ISKkilledDic");

            migrationBuilder.RenameColumn(
                name: "ISKKilledDic",
                table: "DailyAggregateAlliances",
                newName: "ISKkilledDic");
        }
    }
}
