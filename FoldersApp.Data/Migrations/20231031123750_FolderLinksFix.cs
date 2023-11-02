using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoldersApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FolderLinksFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int[]>(
                name: "SubFolders",
                table: "Folders",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubFolders",
                table: "Folders");
        }
    }
}
