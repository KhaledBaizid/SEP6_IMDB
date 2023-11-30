using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class db6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Director_Movies_MovieId",
                table: "Director");

            migrationBuilder.DropForeignKey(
                name: "FK_Director_Persons_PersonId",
                table: "Director");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourite_Movies_MovieId",
                table: "Favourite");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourite_User_UserId",
                table: "Favourite");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Movies_MovieId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Star_Movies_MovieId",
                table: "Star");

            migrationBuilder.DropForeignKey(
                name: "FK_Star_Persons_PersonId",
                table: "Star");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRating_Movies_MovieId",
                table: "UserRating");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRating_User_UserId",
                table: "UserRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRating",
                table: "UserRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Star",
                table: "Star");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourite",
                table: "Favourite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Director",
                table: "Director");

            migrationBuilder.RenameTable(
                name: "UserRating",
                newName: "UserRatings");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Star",
                newName: "Stars");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "Favourite",
                newName: "Favourites");

            migrationBuilder.RenameTable(
                name: "Director",
                newName: "Directors");

            migrationBuilder.RenameIndex(
                name: "IX_UserRating_UserId",
                table: "UserRatings",
                newName: "IX_UserRatings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Star_PersonId",
                table: "Stars",
                newName: "IX_Stars_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Favourite_UserId",
                table: "Favourites",
                newName: "IX_Favourites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Director_PersonId",
                table: "Directors",
                newName: "IX_Directors_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRatings",
                table: "UserRatings",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stars",
                table: "Stars",
                columns: new[] { "MovieId", "PersonId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                columns: new[] { "MovieId", "PersonId" });

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
                name: "FK_Favourites_Movies_MovieId",
                table: "Favourites",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites",
                column: "UserId",
                principalTable: "Users",
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
                name: "FK_Favourites_Movies_MovieId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRatings",
                table: "UserRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stars",
                table: "Stars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UserRatings",
                newName: "UserRating");

            migrationBuilder.RenameTable(
                name: "Stars",
                newName: "Star");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameTable(
                name: "Favourites",
                newName: "Favourite");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Director");

            migrationBuilder.RenameIndex(
                name: "IX_UserRatings_UserId",
                table: "UserRating",
                newName: "IX_UserRating_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Stars_PersonId",
                table: "Star",
                newName: "IX_Star_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Favourites_UserId",
                table: "Favourite",
                newName: "IX_Favourite_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Directors_PersonId",
                table: "Director",
                newName: "IX_Director_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRating",
                table: "UserRating",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Star",
                table: "Star",
                columns: new[] { "MovieId", "PersonId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourite",
                table: "Favourite",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Director",
                table: "Director",
                columns: new[] { "MovieId", "PersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Director_Movies_MovieId",
                table: "Director",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Director_Persons_PersonId",
                table: "Director",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourite_Movies_MovieId",
                table: "Favourite",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourite_User_UserId",
                table: "Favourite",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Movies_MovieId",
                table: "Rating",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Star_Movies_MovieId",
                table: "Star",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Star_Persons_PersonId",
                table: "Star",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRating_Movies_MovieId",
                table: "UserRating",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRating_User_UserId",
                table: "UserRating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
