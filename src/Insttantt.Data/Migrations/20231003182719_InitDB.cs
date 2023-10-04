using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insttantt.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    FieldID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.FieldID);
                });

            migrationBuilder.CreateTable(
                name: "Flows",
                columns: table => new
                {
                    FlowID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flows", x => x.FlowID);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    StepID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowID = table.Column<int>(type: "int", nullable: false),
                    InputFieldID = table.Column<int>(type: "int", nullable: false),
                    OutputFieldID = table.Column<int>(type: "int", nullable: false),
                    FieldID = table.Column<int>(type: "int", nullable: true),
                    FieldID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.StepID);
                    table.ForeignKey(
                        name: "FK_Steps_Fields_FieldID",
                        column: x => x.FieldID,
                        principalTable: "Fields",
                        principalColumn: "FieldID");
                    table.ForeignKey(
                        name: "FK_Steps_Fields_FieldID1",
                        column: x => x.FieldID1,
                        principalTable: "Fields",
                        principalColumn: "FieldID");
                    table.ForeignKey(
                        name: "FK_Steps_Fields_InputFieldID",
                        column: x => x.InputFieldID,
                        principalTable: "Fields",
                        principalColumn: "FieldID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Steps_Fields_OutputFieldID",
                        column: x => x.OutputFieldID,
                        principalTable: "Fields",
                        principalColumn: "FieldID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Steps_Flows_FlowID",
                        column: x => x.FlowID,
                        principalTable: "Flows",
                        principalColumn: "FlowID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Steps_FieldID",
                table: "Steps",
                column: "FieldID");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_FieldID1",
                table: "Steps",
                column: "FieldID1");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_FlowID",
                table: "Steps",
                column: "FlowID");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_InputFieldID",
                table: "Steps",
                column: "InputFieldID");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_OutputFieldID",
                table: "Steps",
                column: "OutputFieldID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Flows");
        }
    }
}
