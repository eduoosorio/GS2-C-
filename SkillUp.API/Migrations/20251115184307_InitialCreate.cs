using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Instructor = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProficiencyLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Instructor", "Price", "Title", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 11, 15, 18, 43, 7, 112, DateTimeKind.Utc).AddTicks(6775), "Curso introdutório sobre Inteligência Artificial", 40, "Dr. João Silva", 299.99m, "Fundamentos de IA", null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Instructor", "Price", "Title", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 11, 15, 18, 43, 7, 112, DateTimeKind.Utc).AddTicks(6777), "Curso completo sobre Amazon Web Services", 60, "Maria Santos", 399.99m, "AWS Essentials", null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Instructor", "Price", "Title", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 11, 15, 18, 43, 7, 112, DateTimeKind.Utc).AddTicks(6778), "Análise de dados usando Python e Pandas", 50, "Carlos Oliveira", 349.99m, "Data Science com Python", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { 1, "Tecnologia", new DateTime(2025, 11, 15, 18, 43, 7, 112, DateTimeKind.Utc).AddTicks(6636), "Conhecimento em IA e Machine Learning", "Inteligência Artificial", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { 2, "Tecnologia", new DateTime(2025, 11, 15, 18, 43, 7, 112, DateTimeKind.Utc).AddTicks(6637), "Habilidades em serviços de nuvem (AWS, Azure, GCP)", "Cloud Computing", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { 3, "Tecnologia", new DateTime(2025, 11, 15, 18, 43, 7, 112, DateTimeKind.Utc).AddTicks(6638), "Análise de dados e estatística", "Data Science", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { 4, "Gestão", new DateTime(2025, 11, 15, 18, 43, 7, 112, DateTimeKind.Utc).AddTicks(6639), "Gestão de equipes em metodologias ágeis", "Liderança Ágil", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { 5, "Soft Skills", new DateTime(2025, 11, 15, 18, 43, 7, 112, DateTimeKind.Utc).AddTicks(6640), "Habilidades de comunicação em ambientes digitais", "Comunicação Digital", null });

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_UserId_SkillId",
                table: "UserSkills",
                columns: new[] { "UserId", "SkillId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
