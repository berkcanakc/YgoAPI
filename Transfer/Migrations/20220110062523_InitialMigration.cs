using Microsoft.EntityFrameworkCore.Migrations;

namespace Transfer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Dbnm = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    desc = table.Column<string>(nullable: false),
                    atk = table.Column<int>(nullable: true),
                    def = table.Column<int>(nullable: true),
                    level = table.Column<int>(nullable: true),
                    race = table.Column<string>(nullable: false),
                    attribute = table.Column<string>(nullable: true),
                    scale = table.Column<int>(nullable: true),
                    linkval = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Dbnm);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");
        }
    }
}
