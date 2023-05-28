using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Migration_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatedPersonDTO_Poersons_PersonId",
                table: "RelatedPersonDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatedPersonDTO_Poersons_RelatedPersonId",
                table: "RelatedPersonDTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedPersonDTO",
                table: "RelatedPersonDTO");

            migrationBuilder.RenameTable(
                name: "RelatedPersonDTO",
                newName: "RelatedPeople");

            migrationBuilder.RenameIndex(
                name: "IX_RelatedPersonDTO_RelatedPersonId",
                table: "RelatedPeople",
                newName: "IX_RelatedPeople_RelatedPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedPeople",
                table: "RelatedPeople",
                columns: new[] { "PersonId", "RelatedPersonId" });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedPeople_Poersons_PersonId",
                table: "RelatedPeople",
                column: "PersonId",
                principalTable: "Poersons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedPeople_Poersons_RelatedPersonId",
                table: "RelatedPeople",
                column: "RelatedPersonId",
                principalTable: "Poersons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatedPeople_Poersons_PersonId",
                table: "RelatedPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatedPeople_Poersons_RelatedPersonId",
                table: "RelatedPeople");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedPeople",
                table: "RelatedPeople");

            migrationBuilder.RenameTable(
                name: "RelatedPeople",
                newName: "RelatedPersonDTO");

            migrationBuilder.RenameIndex(
                name: "IX_RelatedPeople_RelatedPersonId",
                table: "RelatedPersonDTO",
                newName: "IX_RelatedPersonDTO_RelatedPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedPersonDTO",
                table: "RelatedPersonDTO",
                columns: new[] { "PersonId", "RelatedPersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedPersonDTO_Poersons_PersonId",
                table: "RelatedPersonDTO",
                column: "PersonId",
                principalTable: "Poersons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedPersonDTO_Poersons_RelatedPersonId",
                table: "RelatedPersonDTO",
                column: "RelatedPersonId",
                principalTable: "Poersons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
