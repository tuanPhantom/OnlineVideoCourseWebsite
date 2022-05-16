using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _V2__OnlineVideoCourseWebsite.Migrations
{
    public partial class goldv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0847e4ef-a219-48a6-a3c3-fd10378ca980");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8f52d874-36c4-4cd6-b666-20bc33670dc8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f10ae555-1f8f-4ae3-95e5-7ec1e335335f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8824947a-504a-4967-a92c-7eadbba69411");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "04fd53fa-e9b3-4443-8b71-288fd9b404e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "7f40e46c-db38-4ece-84b1-890dec924a5b");
        }
    }
}
