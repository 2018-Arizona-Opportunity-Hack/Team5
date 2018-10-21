using Microsoft.EntityFrameworkCore.Migrations;

namespace FormProcessorApi.Migrations
{
    public partial class RegionTypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionBottomLeft",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "RegionBottomRight",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "RegionTopLeft",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "RegionTopRight",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "RegionBottomLeft",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "RegionBottomRight",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "RegionTopLeft",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "RegionTopRight",
                table: "Answer");

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
                name: "RegionTopRightAPointId",
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

            migrationBuilder.AddColumn<int>(
                name: "RegionTopRightAPointId",
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
                name: "IX_Question_RegionTopRightAPointId",
                table: "Question",
                column: "RegionTopRightAPointId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Answer_RegionTopRightAPointId",
                table: "Answer",
                column: "RegionTopRightAPointId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IX_Question_RegionTopRightAPointId",
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

            migrationBuilder.DropIndex(
                name: "IX_Answer_RegionTopRightAPointId",
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
                name: "RegionTopRightAPointId",
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

            migrationBuilder.DropColumn(
                name: "RegionTopRightAPointId",
                table: "Answer");

            migrationBuilder.AddColumn<int>(
                name: "RegionBottomLeft",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionBottomRight",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionTopLeft",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionTopRight",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionBottomLeft",
                table: "Answer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionBottomRight",
                table: "Answer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionTopLeft",
                table: "Answer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionTopRight",
                table: "Answer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
