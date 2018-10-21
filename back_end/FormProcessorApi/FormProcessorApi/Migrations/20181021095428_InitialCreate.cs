using Microsoft.EntityFrameworkCore.Migrations;

namespace FormProcessorApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormDetails",
                columns: table => new
                {
                    FormDetailsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemplateId = table.Column<int>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    IsTemplate = table.Column<bool>(nullable: false)
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: true),
                    RegionTopLeft = table.Column<int>(nullable: false),
                    RegionBottomLeft = table.Column<int>(nullable: false),
                    RegionTopRight = table.Column<int>(nullable: false),
                    RegionBottomRight = table.Column<int>(nullable: false),
                    FormDetailsId = table.Column<int>(nullable: true)
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerId = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    PixelCount = table.Column<int>(nullable: false),
                    Selected = table.Column<bool>(nullable: false),
                    RegionTopLeft = table.Column<int>(nullable: false),
                    RegionBottomLeft = table.Column<int>(nullable: false),
                    RegionTopRight = table.Column<int>(nullable: false),
                    RegionBottomRight = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: true)
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_FormDetailsId",
                table: "Question",
                column: "FormDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "FormDetails");
        }
    }
}
