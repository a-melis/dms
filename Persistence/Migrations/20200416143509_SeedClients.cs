using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Clients",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Thanos", "Melistas" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 2, "Michalis", "Melistas" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 3, "Eva", "Melista" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Clients");
        }
    }
}
