using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIdentityJwt.Migrations
{
    public partial class AddedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FunctionItems");

            migrationBuilder.CreateTable(
                name: "MenuMasterDto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Menu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMasterDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Menu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Submenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    MenuMasterId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submenus_MenuMasters_MenuMasterId",
                        column: x => x.MenuMasterId,
                        principalTable: "MenuMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submenus_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Submenus_MenuMasterId",
                table: "Submenus",
                column: "MenuMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Submenus_RoleId",
                table: "Submenus",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuMasterDto");

            migrationBuilder.DropTable(
                name: "Submenus");

            migrationBuilder.DropTable(
                name: "MenuMasters");

            migrationBuilder.CreateTable(
                name: "FunctionItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Controller = table.Column<string>(nullable: true),
                    Menu = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
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
        }
    }
}
