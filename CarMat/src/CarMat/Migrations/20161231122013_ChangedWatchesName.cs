using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarMat.Migrations
{
    public partial class ChangedWatchesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watch_Offers_WatchedOfferId",
                table: "Watch");

            migrationBuilder.DropForeignKey(
                name: "FK_Watch_AspNetUsers_WatcherId",
                table: "Watch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Watch",
                table: "Watch");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Watches",
                table: "Watch",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_Offers_WatchedOfferId",
                table: "Watch",
                column: "WatchedOfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_AspNetUsers_WatcherId",
                table: "Watch",
                column: "WatcherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Watch_WatcherId",
                table: "Watch",
                newName: "IX_Watches_WatcherId");

            migrationBuilder.RenameIndex(
                name: "IX_Watch_WatchedOfferId",
                table: "Watch",
                newName: "IX_Watches_WatchedOfferId");

            migrationBuilder.RenameTable(
                name: "Watch",
                newName: "Watches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watches_Offers_WatchedOfferId",
                table: "Watches");

            migrationBuilder.DropForeignKey(
                name: "FK_Watches_AspNetUsers_WatcherId",
                table: "Watches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Watches",
                table: "Watches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Watch",
                table: "Watches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Watch_Offers_WatchedOfferId",
                table: "Watches",
                column: "WatchedOfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watch_AspNetUsers_WatcherId",
                table: "Watches",
                column: "WatcherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Watches_WatcherId",
                table: "Watches",
                newName: "IX_Watch_WatcherId");

            migrationBuilder.RenameIndex(
                name: "IX_Watches_WatchedOfferId",
                table: "Watches",
                newName: "IX_Watch_WatchedOfferId");

            migrationBuilder.RenameTable(
                name: "Watches",
                newName: "Watch");
        }
    }
}
