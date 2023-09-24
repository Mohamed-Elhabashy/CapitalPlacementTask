using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capital_Placement_Task.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeySkillsRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramBenefits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationCriteria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationOpen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationClose = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMonths = table.Column<int>(type: "int", nullable: false),
                    ProgramLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinQualifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxApplications = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    ParagraphValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortAnswerValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YESNO = table.Column<bool>(type: "bit", nullable: true),
                    DatetValue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberValue = table.Column<double>(type: "float", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choice_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Option_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choice_QuestionId",
                table: "Choice",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_QuestionId",
                table: "Option",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "ProgramApplications");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
