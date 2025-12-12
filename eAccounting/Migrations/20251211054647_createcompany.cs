using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAccounting.Migrations
{
    /// <inheritdoc />
    public partial class createcompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GSTTIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PANNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateCode = table.Column<int>(type: "int", nullable: false),
                    RegistrationType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
