using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarMat.Migrations
{
    public partial class AddedDbSetsForNotofications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotification_Notification_NotificationId",
                table: "UserNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotification_Notifications_NotificationId",
                table: "UserNotification",
                column: "NotificationId",
                principalTable: "Notification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotification_Notifications_NotificationId",
                table: "UserNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotification_Notification_NotificationId",
                table: "UserNotification",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");
        }
    }
}
