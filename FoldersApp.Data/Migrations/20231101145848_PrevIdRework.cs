using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoldersApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrevIdRework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_PreviousFolderId",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Folders_PreviousFolderId",
                table: "Folders");

            migrationBuilder.AlterColumn<int>(
                name: "PreviousFolderId",
                table: "Folders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PreviousFolderId",
                table: "Folders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_PreviousFolderId",
                table: "Folders",
                column: "PreviousFolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_PreviousFolderId",
                table: "Folders",
                column: "PreviousFolderId",
                principalTable: "Folders",
                principalColumn: "Id");
        }
    }
}
