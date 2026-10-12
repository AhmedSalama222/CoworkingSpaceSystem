using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoworkingSpaceSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPictureUrlToSpace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Spaces",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Spaces");
        }
    }
}
