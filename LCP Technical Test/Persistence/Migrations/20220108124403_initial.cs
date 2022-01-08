using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "Address", "CreatedDate", "Email", "FirstName", "LastName", "ModifiedDate", "PhoneNumber", "Postcode" },
                values: new object[] { 1, "123 code lane", new DateTime(2022, 1, 8, 12, 44, 3, 121, DateTimeKind.Local).AddTicks(2780), "bob.thompson@gmail.com", "Bob", "Thompson", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "07546378945", "ET10 9RG" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "Address", "CreatedDate", "Email", "FirstName", "LastName", "ModifiedDate", "PhoneNumber", "Postcode" },
                values: new object[] { 2, "987 lanehouse road", new DateTime(2022, 1, 8, 12, 44, 3, 123, DateTimeKind.Local).AddTicks(3221), "brenda@outlook.com", "Brenda", "Danby", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "07147616544", "AB12 3CD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
