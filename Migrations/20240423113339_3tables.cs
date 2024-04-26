using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HobbiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class _3tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    HobbyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HobbyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.PeopleId);
                });

            migrationBuilder.CreateTable(
                name: "HobbyEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Links = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FKPeopleId = table.Column<int>(type: "int", nullable: false),
                    FKHobbyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HobbyEnrollments_Hobbies_FKHobbyId",
                        column: x => x.FKHobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbyEnrollments_Peoples_FKPeopleId",
                        column: x => x.FKPeopleId,
                        principalTable: "Peoples",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HobbyEnrollments_FKHobbyId",
                table: "HobbyEnrollments",
                column: "FKHobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyEnrollments_FKPeopleId",
                table: "HobbyEnrollments",
                column: "FKPeopleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HobbyEnrollments");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Peoples");
        }
    }
}
