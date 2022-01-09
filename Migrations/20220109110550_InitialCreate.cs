using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KanbanBoard.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Signup",
                columns: table => new
                {
                    signup_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email_id = table.Column<string>(nullable: true),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    phone_number = table.Column<int>(nullable: false),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signup", x => x.signup_id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    task_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    task_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.task_id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    login_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    signup_id = table.Column<int>(nullable: false),
                    email_id = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.login_id);
                    table.ForeignKey(
                        name: "FK_Login_Signup_signup_id",
                        column: x => x.signup_id,
                        principalTable: "Signup",
                        principalColumn: "signup_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    project_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    project_name = table.Column<string>(nullable: true),
                    task_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.project_id);
                    table.ForeignKey(
                        name: "FK_Project_Tasks_task_id",
                        column: x => x.task_id,
                        principalTable: "Tasks",
                        principalColumn: "task_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    teammember_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    teammember_name = table.Column<string>(nullable: true),
                    teammember_designation = table.Column<string>(nullable: true),
                    project_id = table.Column<int>(nullable: false),
                    task_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.teammember_id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Project_project_id",
                        column: x => x.project_id,
                        principalTable: "Project",
                        principalColumn: "project_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Tasks_task_id",
                        column: x => x.task_id,
                        principalTable: "Tasks",
                        principalColumn: "task_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_designation = table.Column<string>(nullable: true),
                    teammember_id = table.Column<int>(nullable: false),
                    project_id = table.Column<int>(nullable: false),
                    task_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_Users_Project_project_id",
                        column: x => x.project_id,
                        principalTable: "Project",
                        principalColumn: "project_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Tasks_task_id",
                        column: x => x.task_id,
                        principalTable: "Tasks",
                        principalColumn: "task_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_TeamMembers_teammember_id",
                        column: x => x.teammember_id,
                        principalTable: "TeamMembers",
                        principalColumn: "teammember_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Login_signup_id",
                table: "Login",
                column: "signup_id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_task_id",
                table: "Project",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_project_id",
                table: "TeamMembers",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_task_id",
                table: "TeamMembers",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_project_id",
                table: "Users",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_task_id",
                table: "Users",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_teammember_id",
                table: "Users",
                column: "teammember_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Signup");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
