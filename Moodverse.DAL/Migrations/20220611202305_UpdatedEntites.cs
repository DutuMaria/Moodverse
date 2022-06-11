using Microsoft.EntityFrameworkCore.Migrations;

namespace Moodverse.DAL.Migrations
{
    public partial class UpdatedEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Ambiences_IdAmbience",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Backgrounds_IdBackground",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DailyQuotes_IdDailyQuote",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Streaks_IdStreak",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ToDoLists_IdToDoList",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdStreak",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdToDoList",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "IdToDoList",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdStreak",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdDailyQuote",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdBackground",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdAmbience",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdStreak",
                table: "AspNetUsers",
                column: "IdStreak",
                unique: true,
                filter: "[IdStreak] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdToDoList",
                table: "AspNetUsers",
                column: "IdToDoList",
                unique: true,
                filter: "[IdToDoList] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Ambiences_IdAmbience",
                table: "AspNetUsers",
                column: "IdAmbience",
                principalTable: "Ambiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Backgrounds_IdBackground",
                table: "AspNetUsers",
                column: "IdBackground",
                principalTable: "Backgrounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DailyQuotes_IdDailyQuote",
                table: "AspNetUsers",
                column: "IdDailyQuote",
                principalTable: "DailyQuotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Streaks_IdStreak",
                table: "AspNetUsers",
                column: "IdStreak",
                principalTable: "Streaks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ToDoLists_IdToDoList",
                table: "AspNetUsers",
                column: "IdToDoList",
                principalTable: "ToDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Ambiences_IdAmbience",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Backgrounds_IdBackground",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DailyQuotes_IdDailyQuote",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Streaks_IdStreak",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ToDoLists_IdToDoList",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdStreak",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdToDoList",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "IdToDoList",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdStreak",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdDailyQuote",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdBackground",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdAmbience",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdStreak",
                table: "AspNetUsers",
                column: "IdStreak",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdToDoList",
                table: "AspNetUsers",
                column: "IdToDoList",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Ambiences_IdAmbience",
                table: "AspNetUsers",
                column: "IdAmbience",
                principalTable: "Ambiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Backgrounds_IdBackground",
                table: "AspNetUsers",
                column: "IdBackground",
                principalTable: "Backgrounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DailyQuotes_IdDailyQuote",
                table: "AspNetUsers",
                column: "IdDailyQuote",
                principalTable: "DailyQuotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Streaks_IdStreak",
                table: "AspNetUsers",
                column: "IdStreak",
                principalTable: "Streaks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ToDoLists_IdToDoList",
                table: "AspNetUsers",
                column: "IdToDoList",
                principalTable: "ToDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
