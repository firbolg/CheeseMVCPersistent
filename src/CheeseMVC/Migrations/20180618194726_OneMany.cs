using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CheeseMVC.Migrations
{
    public partial class OneMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Cheez",
                newName: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Cheez_CategoryID",
                table: "Cheez",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheez_Categorees_CategoryID",
                table: "Cheez",
                column: "CategoryID",
                principalTable: "Categorees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheez_Categorees_CategoryID",
                table: "Cheez");

            migrationBuilder.DropIndex(
                name: "IX_Cheez_CategoryID",
                table: "Cheez");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Cheez",
                newName: "Type");
        }
    }
}
