using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace McqueenDoctor.Infrastructure.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersInfo",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Rol = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInfo", x => x.UserInfoId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleRegisters",
                columns: table => new
                {
                    VehicleRegisterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Model = table.Column<int>(nullable: false),
                    Maker = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Matricule = table.Column<string>(nullable: true),
                    Img = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    DateInsertion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    UserInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRegisters", x => x.VehicleRegisterId);
                    table.ForeignKey(
                        name: "FK_VehicleRegisters_UsersInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UsersInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRegisters_UserInfoId",
                table: "VehicleRegisters",
                column: "UserInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleRegisters");

            migrationBuilder.DropTable(
                name: "UsersInfo");
        }
    }
}
