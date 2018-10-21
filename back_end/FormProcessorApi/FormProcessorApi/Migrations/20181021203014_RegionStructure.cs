using Microsoft.EntityFrameworkCore.Migrations;

namespace FormProcessorApi.Migrations
{
    public partial class RegionStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_APoint_RegionBottomLeftAPointId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_APoint_RegionBottomRightAPointId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_APoint_RegionTopLeftAPointId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_APoint_RegionTopRightAPointId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_APoint_RegionBottomLeftAPointId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_APoint_RegionBottomRightAPointId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_APoint_RegionTopLeftAPointId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_APoint_RegionTopRightAPointId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "APoint");

            migrationBuilder.DropIndex(
                name: "IX_Question_RegionBottomLeftAPointId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_RegionBottomRightAPointId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_RegionTopLeftAPointId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Answer_RegionBottomLeftAPointId",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_RegionBottomRightAPointId",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_RegionTopLeftAPointId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "RegionBottomLeftAPointId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "RegionBottomRightAPointId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "RegionTopLeftAPointId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "RegionBottomLeftAPointId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "RegionBottomRightAPointId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "RegionTopLeftAPointId",
                table: "Answer");

            migrationBuilder.RenameColumn(
                name: "RegionTopRightAPointId",
                table: "Question",
                newName: "RegionARectangleId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_RegionTopRightAPointId",
                table: "Question",
                newName: "IX_Question_RegionARectangleId");

            migrationBuilder.RenameColumn(
                name: "RegionTopRightAPointId",
                table: "Answer",
                newName: "RegionARectangleId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_RegionTopRightAPointId",
                table: "Answer",
                newName: "IX_Answer_RegionARectangleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_ARectangle_RegionARectangleId",
                table: "Answer",
                column: "RegionARectangleId",
                principalTable: "ARectangle",
                principalColumn: "ARectangleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_ARectangle_RegionARectangleId",
                table: "Question",
                column: "RegionARectangleId",
                principalTable: "ARectangle",
                principalColumn: "ARectangleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_ARectangle_RegionARectangleId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_ARectangle_RegionARectangleId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "ARectangle");

            migrationBuilder.RenameColumn(
                name: "RegionARectangleId",
                table: "Question",
                newName: "RegionTopRightAPointId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_RegionARectangleId",
                table: "Question",
                newName: "IX_Question_RegionTopRightAPointId");

            migrationBuilder.RenameColumn(
                name: "RegionARectangleId",
                table: "Answer",
                newName: "RegionTopRightAPointId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_RegionARectangleId",
                table: "Answer",
                newName: "IX_Answer_RegionTopRightAPointId");

            migrationBuilder.AddColumn<int>(
                name: "RegionBottomLeftAPointId",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionBottomRightAPointId",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionTopLeftAPointId",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionBottomLeftAPointId",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionBottomRightAPointId",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionTopLeftAPointId",
                table: "Answer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "APoint",
                columns: table => new
                {
                    APointId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APoint", x => x.APointId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_RegionBottomLeftAPointId",
                table: "Question",
                column: "RegionBottomLeftAPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_RegionBottomRightAPointId",
                table: "Question",
                column: "RegionBottomRightAPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_RegionTopLeftAPointId",
                table: "Question",
                column: "RegionTopLeftAPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_RegionBottomLeftAPointId",
                table: "Answer",
                column: "RegionBottomLeftAPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_RegionBottomRightAPointId",
                table: "Answer",
                column: "RegionBottomRightAPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_RegionTopLeftAPointId",
                table: "Answer",
                column: "RegionTopLeftAPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_APoint_RegionBottomLeftAPointId",
                table: "Answer",
                column: "RegionBottomLeftAPointId",
                principalTable: "APoint",
                principalColumn: "APointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_APoint_RegionBottomRightAPointId",
                table: "Answer",
                column: "RegionBottomRightAPointId",
                principalTable: "APoint",
                principalColumn: "APointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_APoint_RegionTopLeftAPointId",
                table: "Answer",
                column: "RegionTopLeftAPointId",
                principalTable: "APoint",
                principalColumn: "APointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_APoint_RegionTopRightAPointId",
                table: "Answer",
                column: "RegionTopRightAPointId",
                principalTable: "APoint",
                principalColumn: "APointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_APoint_RegionBottomLeftAPointId",
                table: "Question",
                column: "RegionBottomLeftAPointId",
                principalTable: "APoint",
                principalColumn: "APointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_APoint_RegionBottomRightAPointId",
                table: "Question",
                column: "RegionBottomRightAPointId",
                principalTable: "APoint",
                principalColumn: "APointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_APoint_RegionTopLeftAPointId",
                table: "Question",
                column: "RegionTopLeftAPointId",
                principalTable: "APoint",
                principalColumn: "APointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_APoint_RegionTopRightAPointId",
                table: "Question",
                column: "RegionTopRightAPointId",
                principalTable: "APoint",
                principalColumn: "APointId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
