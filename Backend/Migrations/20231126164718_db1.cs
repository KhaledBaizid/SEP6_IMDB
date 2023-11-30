using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class db1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Moviem_id",
                table: "Peoples",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Moviem_id1",
                table: "Peoples",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_Moviem_id",
                table: "Peoples",
                column: "Moviem_id");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_Moviem_id1",
                table: "Peoples",
                column: "Moviem_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Peoples_Movies_Moviem_id",
                table: "Peoples",
                column: "Moviem_id",
                principalTable: "Movies",
                principalColumn: "m_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Peoples_Movies_Moviem_id1",
                table: "Peoples",
                column: "Moviem_id1",
                principalTable: "Movies",
                principalColumn: "m_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peoples_Movies_Moviem_id",
                table: "Peoples");

            migrationBuilder.DropForeignKey(
                name: "FK_Peoples_Movies_Moviem_id1",
                table: "Peoples");

            migrationBuilder.DropIndex(
                name: "IX_Peoples_Moviem_id",
                table: "Peoples");

            migrationBuilder.DropIndex(
                name: "IX_Peoples_Moviem_id1",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "Moviem_id",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "Moviem_id1",
                table: "Peoples");
        }
    }
}
