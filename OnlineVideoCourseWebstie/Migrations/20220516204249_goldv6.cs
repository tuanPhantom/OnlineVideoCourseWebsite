using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _V2__OnlineVideoCourseWebsite.Migrations
{
    public partial class goldv6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserId",
                table: "Enrollment");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Enrollment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cc7ebb4a-9c57-4de3-8aaa-11cedfbeb9a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5716c408-6ac2-48bf-85fb-ae7f4182500b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ff0504be-7cde-4be2-84e8-7b532f55e0de");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserId",
                table: "Enrollment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserId",
                table: "Enrollment");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Enrollment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserId",
                table: "Enrollment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
