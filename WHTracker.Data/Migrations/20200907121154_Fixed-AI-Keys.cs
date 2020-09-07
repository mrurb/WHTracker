using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WHTracker.Data.Migrations
{
    public partial class FixedAIKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyAggregateAlliances_Alliances_AllianceID",
                table: "DailyAggregateAlliances");

            migrationBuilder.RenameColumn(
                name: "KiilmailID",
                table: "Killmails",
                newName: "KiilmailId");

            migrationBuilder.RenameColumn(
                name: "DailyAggregateCorporationID",
                table: "DailyAggregateCorporations",
                newName: "DailyAggregateCorporationId");

            migrationBuilder.RenameColumn(
                name: "AllianceID",
                table: "DailyAggregateAlliances",
                newName: "AllianceId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyAggregateAlliances_AllianceID",
                table: "DailyAggregateAlliances",
                newName: "IX_DailyAggregateAlliances_AllianceId");

            migrationBuilder.RenameColumn(
                name: "CorporationID",
                table: "Corporations",
                newName: "CorporationId");

            migrationBuilder.RenameColumn(
                name: "AllianceID",
                table: "Alliances",
                newName: "AllianceId");

            migrationBuilder.AlterColumn<int>(
                name: "CorporationId",
                table: "Corporations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "AllianceId",
                table: "Alliances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyAggregateAlliances_Alliances_AllianceId",
                table: "DailyAggregateAlliances",
                column: "AllianceId",
                principalTable: "Alliances",
                principalColumn: "AllianceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyAggregateAlliances_Alliances_AllianceId",
                table: "DailyAggregateAlliances");

            migrationBuilder.RenameColumn(
                name: "KiilmailId",
                table: "Killmails",
                newName: "KiilmailID");

            migrationBuilder.RenameColumn(
                name: "DailyAggregateCorporationId",
                table: "DailyAggregateCorporations",
                newName: "DailyAggregateCorporationID");

            migrationBuilder.RenameColumn(
                name: "AllianceId",
                table: "DailyAggregateAlliances",
                newName: "AllianceID");

            migrationBuilder.RenameIndex(
                name: "IX_DailyAggregateAlliances_AllianceId",
                table: "DailyAggregateAlliances",
                newName: "IX_DailyAggregateAlliances_AllianceID");

            migrationBuilder.RenameColumn(
                name: "CorporationId",
                table: "Corporations",
                newName: "CorporationID");

            migrationBuilder.RenameColumn(
                name: "AllianceId",
                table: "Alliances",
                newName: "AllianceID");

            migrationBuilder.AlterColumn<int>(
                name: "CorporationID",
                table: "Corporations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "AllianceID",
                table: "Alliances",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyAggregateAlliances_Alliances_AllianceID",
                table: "DailyAggregateAlliances",
                column: "AllianceID",
                principalTable: "Alliances",
                principalColumn: "AllianceID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
