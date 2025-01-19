using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ilişki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AppUserId",
                table: "Messages",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CategoryId",
                table: "Messages",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_AppUserId",
                table: "Messages",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Categories_CategoryId",
                table: "Messages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_AppUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Categories_CategoryId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_AppUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CategoryId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Messages");
        }
    }
}
