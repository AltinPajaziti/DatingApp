using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class photoentityupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Users_AppUsserId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_AppUsserId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "AppUsserId",
                table: "Photo");

            migrationBuilder.AddColumn<int>(
                name: "Appuserid",
                table: "Photo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_Appuserid",
                table: "Photo",
                column: "Appuserid");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Users_Appuserid",
                table: "Photo",
                column: "Appuserid",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Users_Appuserid",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_Appuserid",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Appuserid",
                table: "Photo");

            migrationBuilder.AddColumn<int>(
                name: "AppUsserId",
                table: "Photo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AppUsserId",
                table: "Photo",
                column: "AppUsserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Users_AppUsserId",
                table: "Photo",
                column: "AppUsserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
