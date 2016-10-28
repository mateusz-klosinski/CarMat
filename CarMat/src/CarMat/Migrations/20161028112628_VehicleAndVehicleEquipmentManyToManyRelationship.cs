using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarMat.Migrations
{
    public partial class VehicleAndVehicleEquipmentManyToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleEquipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleVehicleEquipment",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleVehicleEquipment", x => new { x.VehicleId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_VehicleVehicleEquipment_VehicleEquipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "VehicleEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleVehicleEquipment_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleVehicleEquipment_EquipmentId",
                table: "VehicleVehicleEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleVehicleEquipment_VehicleId",
                table: "VehicleVehicleEquipment",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleVehicleEquipment");

            migrationBuilder.DropTable(
                name: "VehicleEquipments");
        }
    }
}
