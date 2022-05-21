using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _V2__OnlineVideoCourseWebsite.Migrations
{
    public partial class goldv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "96c86b8f-5793-450a-9cd5-9242448f6b42");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e542fd2a-abe6-4951-a2c1-04e44e305409");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "7f1b9a5f-18bf-4a77-9a89-e008bcf8f1d0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "58bd4d95-cc72-4fe5-b56f-61843e9098c1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "60ae996e-fea9-4b49-9384-0c9718fb3c55");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "151b3967-6422-4dce-952f-afbe28ade199");
        }
    }
}
