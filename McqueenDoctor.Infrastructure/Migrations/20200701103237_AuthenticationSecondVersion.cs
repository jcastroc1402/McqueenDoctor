using Microsoft.EntityFrameworkCore.Migrations;

namespace McqueenDoctor.Infrastructure.Migrations
{
    public partial class AuthenticationSecondVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Securities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Username = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Securities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Securities");
        }
    }
}
