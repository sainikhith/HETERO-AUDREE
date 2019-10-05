using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIdentityJwt.Migrations
{
    public partial class AddedNewModelsInContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersInRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FunctionItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Menu = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    UsersInRolesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FunctionItems_UsersInRoles_UsersInRolesId",
                        column: x => x.UsersInRolesId,
                        principalTable: "UsersInRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FunctionItems_UsersInRolesId",
                table: "FunctionItems",
                column: "UsersInRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInRoles_RoleId",
                table: "UsersInRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInRoles_UserId",
                table: "UsersInRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FunctionItems");

            migrationBuilder.DropTable(
                name: "UsersInRoles");
        }
    }
}
