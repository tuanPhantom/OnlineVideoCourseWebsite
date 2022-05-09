using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _V2__OnlineVideoCourseWebsite.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Topic_TopicId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_TopicId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Video");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7ce9644b-37d8-4a60-b01e-d35129931718");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f007c2a1-a38f-492c-a075-e02cbb8aa616");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2dd6cef5-3cfe-488c-b3b4-df28db46e7a9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TopicId",
                table: "Video",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "02e63747-ffcd-4a69-84d6-360a846b1d7e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d9f7badb-f0df-4de8-9acf-331c3c679d05");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2fff25a9-19a8-46ad-8351-1d8df730219a");

            migrationBuilder.CreateIndex(
                name: "IX_Video_TopicId",
                table: "Video",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Topic_TopicId",
                table: "Video",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "TopicId");
        }
    }
}
