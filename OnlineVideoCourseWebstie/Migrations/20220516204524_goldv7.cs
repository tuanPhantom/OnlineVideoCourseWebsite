using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _V2__OnlineVideoCourseWebsite.Migrations
{
    public partial class goldv7 : Migration
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
                value: "a3699897-d747-4320-acbf-0ec5fe26cc07");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "59f1b15a-d1ff-418c-8add-4f590c0db7d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "303b7975-cb1f-498a-9277-5b9393c49cbe");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserId",
                table: "Enrollment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
    }
}
