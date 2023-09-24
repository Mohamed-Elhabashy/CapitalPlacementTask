using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capital_Placement_Task.Migrations
{
    public partial class CreateDBqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ApplicationForm_ApplicationFormId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationForm",
                table: "ApplicationForm");

            migrationBuilder.RenameTable(
                name: "ApplicationForm",
                newName: "ApplicationForms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationForms",
                table: "ApplicationForms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ApplicationForms_ApplicationFormId",
                table: "Questions",
                column: "ApplicationFormId",
                principalTable: "ApplicationForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ApplicationForms_ApplicationFormId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationForms",
                table: "ApplicationForms");

            migrationBuilder.RenameTable(
                name: "ApplicationForms",
                newName: "ApplicationForm");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationForm",
                table: "ApplicationForm",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ApplicationForm_ApplicationFormId",
                table: "Questions",
                column: "ApplicationFormId",
                principalTable: "ApplicationForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
