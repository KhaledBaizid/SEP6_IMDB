using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
#pragma warning disable CS8981
    public partial class vote : Migration
#pragma warning restore CS8981
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vote",
                table: "UserRatings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "vote",
                table: "UserRatings",
                type: "real",
                nullable: true);
        }
    }
}
