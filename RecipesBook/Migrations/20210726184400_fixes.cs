using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipesBook.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_AuthorId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeUser_Users_UsersThatLikedId",
                table: "RecipeUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UsersThatLikedId",
                table: "RecipeUser",
                newName: "UsersThatLikedEmail");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeUser_UsersThatLikedId",
                table: "RecipeUser",
                newName: "IX_RecipeUser_UsersThatLikedEmail");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Recipes",
                newName: "AuthorEmail");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_AuthorId",
                table: "Recipes",
                newName: "IX_Recipes_AuthorEmail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_AuthorEmail",
                table: "Recipes",
                column: "AuthorEmail",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeUser_Users_UsersThatLikedEmail",
                table: "RecipeUser",
                column: "UsersThatLikedEmail",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_AuthorEmail",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeUser_Users_UsersThatLikedEmail",
                table: "RecipeUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UsersThatLikedEmail",
                table: "RecipeUser",
                newName: "UsersThatLikedId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeUser_UsersThatLikedEmail",
                table: "RecipeUser",
                newName: "IX_RecipeUser_UsersThatLikedId");

            migrationBuilder.RenameColumn(
                name: "AuthorEmail",
                table: "Recipes",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_AuthorEmail",
                table: "Recipes",
                newName: "IX_Recipes_AuthorId");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_AuthorId",
                table: "Recipes",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeUser_Users_UsersThatLikedId",
                table: "RecipeUser",
                column: "UsersThatLikedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
