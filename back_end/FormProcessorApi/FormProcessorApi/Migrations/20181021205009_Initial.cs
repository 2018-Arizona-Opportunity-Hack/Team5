using Microsoft.EntityFrameworkCore.Migrations;

namespace FormProcessorApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARectangle",
                columns: table => new
                {
                    ARectangleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARectangle", x => x.ARectangleId);
                });

            migrationBuilder.CreateTable(
                name: "FormDetails",
                columns: table => new
                {
                    FormDetailsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemplateId = table.Column<int>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    IsTemplate = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormDetails", x => x.FormDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: true),
                    RegionARectangleId = table.Column<int>(nullable: true),
                    FormDetailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Question_FormDetails_FormDetailsId",
                        column: x => x.FormDetailsId,
                        principalTable: "FormDetails",
                        principalColumn: "FormDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_ARectangle_RegionARectangleId",
                        column: x => x.RegionARectangleId,
                        principalTable: "ARectangle",
                        principalColumn: "ARectangleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerId = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    PixelCount = table.Column<int>(nullable: false),
                    Selected = table.Column<bool>(nullable: false),
                    RegionARectangleId = table.Column<int>(nullable: true),
                    QuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_ARectangle_RegionARectangleId",
                        column: x => x.RegionARectangleId,
                        principalTable: "ARectangle",
                        principalColumn: "ARectangleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_RegionARectangleId",
                table: "Answer",
                column: "RegionARectangleId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_FormDetailsId",
                table: "Question",
                column: "FormDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_RegionARectangleId",
                table: "Question",
                column: "RegionARectangleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "FormDetails");

            migrationBuilder.DropTable(
                name: "ARectangle");
        }
    }
}
