using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _V2__OnlineVideoCourseWebstie.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Topic_TopicVideoId",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicVideo_Topic_TopicId1",
                table: "TopicVideo");

            migrationBuilder.DropIndex(
                name: "IX_TopicVideo_TopicId1",
                table: "TopicVideo");

            migrationBuilder.DropIndex(
                name: "IX_Topic_TopicVideoId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "TopicVideoId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "TopicId1",
                table: "TopicVideo");

            migrationBuilder.DropColumn(
                name: "TopicVideoId",
                table: "Topic");

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
                name: "IX_TopicVideo_TopicId",
                table: "TopicVideo",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicVideo_Topic_TopicId",
                table: "TopicVideo",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicVideo_Topic_TopicId",
                table: "TopicVideo");

            migrationBuilder.DropIndex(
                name: "IX_TopicVideo_TopicId",
                table: "TopicVideo");

            migrationBuilder.AddColumn<long>(
                name: "TopicVideoId",
                table: "Video",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TopicId1",
                table: "TopicVideo",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TopicVideoId",
                table: "Topic",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e0692a53-651d-48f9-9c9d-0df732b9241b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "36242f28-cb5c-477f-a041-43b68824e22b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "20590cf4-495e-46d5-95b8-cc77db49668b");

            migrationBuilder.CreateIndex(
                name: "IX_TopicVideo_TopicId1",
                table: "TopicVideo",
                column: "TopicId1");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_TopicVideoId",
                table: "Topic",
                column: "TopicVideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Topic_TopicVideoId",
                table: "Topic",
                column: "TopicVideoId",
                principalTable: "Topic",
                principalColumn: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicVideo_Topic_TopicId1",
                table: "TopicVideo",
                column: "TopicId1",
                principalTable: "Topic",
                principalColumn: "TopicId");
        }
    }
}
