using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class db2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_moviem_id",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Movies_Moviem_id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropIndex(
                name: "IX_Users_Moviem_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Moviem_id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "mail",
                table: "Users",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "u_id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_rating",
                table: "UserRatings",
                newName: "RatingValue");

            migrationBuilder.RenameColumn(
                name: "votes",
                table: "Ratings",
                newName: "Votes");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Ratings",
                newName: "RatingValue");

            migrationBuilder.RenameColumn(
                name: "moviem_id",
                table: "Ratings",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_moviem_id",
                table: "Ratings",
                newName: "IX_Ratings_MovieId");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "Movies",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Movies",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "m_id",
                table: "Movies",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "UserRatings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserRatings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Stars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Stars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Movies",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Directors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Directors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Favourites_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favourites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Birth = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_MovieId",
                table: "UserRatings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_UserId",
                table: "UserRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stars_MovieId",
                table: "Stars",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Stars_PersonId",
                table: "Stars",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_MovieId",
                table: "Directors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_PersonId",
                table: "Directors",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_MovieId",
                table: "Favourites",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Movies_MovieId",
                table: "Directors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Persons_PersonId",
                table: "Directors",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_Movies_MovieId",
                table: "Stars",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_Persons_PersonId",
                table: "Stars",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Movies_MovieId",
                table: "UserRatings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Users_UserId",
                table: "UserRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Movies_MovieId",
                table: "Directors");

            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Persons_PersonId",
                table: "Directors");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Stars_Movies_MovieId",
                table: "Stars");

            migrationBuilder.DropForeignKey(
                name: "FK_Stars_Persons_PersonId",
                table: "Stars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Movies_MovieId",
                table: "UserRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Users_UserId",
                table: "UserRatings");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_UserRatings_MovieId",
                table: "UserRatings");

            migrationBuilder.DropIndex(
                name: "IX_UserRatings_UserId",
                table: "UserRatings");

            migrationBuilder.DropIndex(
                name: "IX_Stars_MovieId",
                table: "Stars");

            migrationBuilder.DropIndex(
                name: "IX_Stars_PersonId",
                table: "Stars");

            migrationBuilder.DropIndex(
                name: "IX_Directors_MovieId",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Directors_PersonId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Directors");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Users",
                newName: "mail");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "u_id");

            migrationBuilder.RenameColumn(
                name: "RatingValue",
                table: "UserRatings",
                newName: "user_rating");

            migrationBuilder.RenameColumn(
                name: "Votes",
                table: "Ratings",
                newName: "votes");

            migrationBuilder.RenameColumn(
                name: "RatingValue",
                table: "Ratings",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Ratings",
                newName: "moviem_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                newName: "IX_Ratings_moviem_id");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Movies",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movies",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movies",
                newName: "m_id");

            migrationBuilder.AddColumn<int>(
                name: "Moviem_id",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "year",
                table: "Movies",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    p_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Moviem_id = table.Column<int>(type: "integer", nullable: true),
                    Moviem_id1 = table.Column<int>(type: "integer", nullable: true),
                    birth = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.p_id);
                    table.ForeignKey(
                        name: "FK_Peoples_Movies_Moviem_id",
                        column: x => x.Moviem_id,
                        principalTable: "Movies",
                        principalColumn: "m_id");
                    table.ForeignKey(
                        name: "FK_Peoples_Movies_Moviem_id1",
                        column: x => x.Moviem_id1,
                        principalTable: "Movies",
                        principalColumn: "m_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Moviem_id",
                table: "Users",
                column: "Moviem_id");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_Moviem_id",
                table: "Peoples",
                column: "Moviem_id");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_Moviem_id1",
                table: "Peoples",
                column: "Moviem_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_moviem_id",
                table: "Ratings",
                column: "moviem_id",
                principalTable: "Movies",
                principalColumn: "m_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Movies_Moviem_id",
                table: "Users",
                column: "Moviem_id",
                principalTable: "Movies",
                principalColumn: "m_id");
        }
    }
}
