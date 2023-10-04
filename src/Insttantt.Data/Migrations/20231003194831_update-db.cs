using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insttantt.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Fields_FieldID",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Fields_FieldID1",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Fields_InputFieldID",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Fields_OutputFieldID",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Flows_FlowID",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Steps_FieldID",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Steps_FieldID1",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "FieldID",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "FieldID1",
                table: "Steps");

            migrationBuilder.RenameColumn(
                name: "FlowID",
                table: "Steps",
                newName: "FlowId");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_FlowID",
                table: "Steps",
                newName: "IX_Steps_FlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Fields_InputFieldID",
                table: "Steps",
                column: "InputFieldID",
                principalTable: "Fields",
                principalColumn: "FieldID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Fields_OutputFieldID",
                table: "Steps",
                column: "OutputFieldID",
                principalTable: "Fields",
                principalColumn: "FieldID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Flows_FlowId",
                table: "Steps",
                column: "FlowId",
                principalTable: "Flows",
                principalColumn: "FlowID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Fields_InputFieldID",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Fields_OutputFieldID",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Flows_FlowId",
                table: "Steps");

            migrationBuilder.RenameColumn(
                name: "FlowId",
                table: "Steps",
                newName: "FlowID");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_FlowId",
                table: "Steps",
                newName: "IX_Steps_FlowID");

            migrationBuilder.AddColumn<int>(
                name: "FieldID",
                table: "Steps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FieldID1",
                table: "Steps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Steps_FieldID",
                table: "Steps",
                column: "FieldID");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_FieldID1",
                table: "Steps",
                column: "FieldID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Fields_FieldID",
                table: "Steps",
                column: "FieldID",
                principalTable: "Fields",
                principalColumn: "FieldID");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Fields_FieldID1",
                table: "Steps",
                column: "FieldID1",
                principalTable: "Fields",
                principalColumn: "FieldID");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Fields_InputFieldID",
                table: "Steps",
                column: "InputFieldID",
                principalTable: "Fields",
                principalColumn: "FieldID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Fields_OutputFieldID",
                table: "Steps",
                column: "OutputFieldID",
                principalTable: "Fields",
                principalColumn: "FieldID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Flows_FlowID",
                table: "Steps",
                column: "FlowID",
                principalTable: "Flows",
                principalColumn: "FlowID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
