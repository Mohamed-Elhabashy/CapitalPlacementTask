using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capital_Placement_Task.Migrations
{
    public partial class CreateDBq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationFormId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BelongsTo",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Hide",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ApplicationForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ApplicationFormId",
                table: "Questions",
                column: "ApplicationFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ApplicationForm_ApplicationFormId",
                table: "Questions",
                column: "ApplicationFormId",
                principalTable: "ApplicationForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ApplicationForm_ApplicationFormId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "ApplicationForm");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ApplicationFormId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ApplicationFormId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "BelongsTo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Hide",
                table: "Questions");
        }
    }
}
