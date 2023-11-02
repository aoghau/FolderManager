using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoldersApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FolderLinksNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_PreviousFolderId",
                table: "Folders");

            migrationBuilder.AlterColumn<int[]>(
                name: "SubFolders",
                table: "Folders",
                type: "integer[]",
                nullable: true,
                oldClrType: typeof(int[]),
                oldType: "integer[]");

            migrationBuilder.AlterColumn<int>(
                name: "PreviousFolderId",
                table: "Folders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_PreviousFolderId",
                table: "Folders",
                column: "PreviousFolderId",
                principalTable: "Folders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_PreviousFolderId",
                table: "Folders");

            migrationBuilder.AlterColumn<int[]>(
                name: "SubFolders",
                table: "Folders",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0],
                oldClrType: typeof(int[]),
                oldType: "integer[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PreviousFolderId",
                table: "Folders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_PreviousFolderId",
                table: "Folders",
                column: "PreviousFolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
