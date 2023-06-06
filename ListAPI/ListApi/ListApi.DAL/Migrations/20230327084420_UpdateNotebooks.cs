using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListApi.DAL.Migrations
{
    public partial class UpdateNotebooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lines_Notebooks_NotebookId1",
                table: "Lines");

            migrationBuilder.DropIndex(
                name: "IX_Lines_NotebookId1",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "NotebookId1",
                table: "Lines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NotebookId1",
                table: "Lines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lines_NotebookId1",
                table: "Lines",
                column: "NotebookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lines_Notebooks_NotebookId1",
                table: "Lines",
                column: "NotebookId1",
                principalTable: "Notebooks",
                principalColumn: "Id");
        }
    }
}
