using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _V2__OnlineVideoCourseWebsite.Migrations
{
    public partial class goldv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Video_VideoId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOffering_Course_CourseId",
                table: "CourseOffering");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_CourseOffering_CourseOfferingId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Topic_TopicId",
                table: "Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_CourseOffering_CourseOfferingId",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicVideo_Topic_TopicId",
                table: "TopicVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicVideo_Video_VideoId",
                table: "TopicVideos");

            migrationBuilder.AlterColumn<long>(
                name: "VideoId",
                table: "TopicVideos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TopicId",
                table: "TopicVideos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CourseOfferingId",
                table: "Topic",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TopicId",
                table: "Resource",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Enrollment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CourseOfferingId",
                table: "Enrollment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "CourseOffering",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CourseOffering",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "CourseOffering",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "VideoId",
                table: "Comment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Comment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Video_VideoId",
                table: "Comment",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOffering_Course_CourseId",
                table: "CourseOffering",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserId",
                table: "Enrollment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_CourseOffering_CourseOfferingId",
                table: "Enrollment",
                column: "CourseOfferingId",
                principalTable: "CourseOffering",
                principalColumn: "CourseOfferingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Topic_TopicId",
                table: "Resource",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_CourseOffering_CourseOfferingId",
                table: "Topic",
                column: "CourseOfferingId",
                principalTable: "CourseOffering",
                principalColumn: "CourseOfferingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicVideo_Topic_TopicId",
                table: "TopicVideos",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicVideo_Video_VideoId",
                table: "TopicVideos",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Video_VideoId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOffering_Course_CourseId",
                table: "CourseOffering");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_CourseOffering_CourseOfferingId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Topic_TopicId",
                table: "Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_CourseOffering_CourseOfferingId",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicVideo_Topic_TopicId",
                table: "TopicVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicVideo_Video_VideoId",
                table: "TopicVideos");

            migrationBuilder.AlterColumn<long>(
                name: "VideoId",
                table: "TopicVideos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "TopicId",
                table: "TopicVideos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CourseOfferingId",
                table: "Topic",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "TopicId",
                table: "Resource",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Enrollment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<long>(
                name: "CourseOfferingId",
                table: "Enrollment",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "CourseOffering",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CourseOffering",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "CourseOffering",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "VideoId",
                table: "Comment",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Comment",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Comment",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comment",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Video_VideoId",
                table: "Comment",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOffering_Course_CourseId",
                table: "CourseOffering",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserId",
                table: "Enrollment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_CourseOffering_CourseOfferingId",
                table: "Enrollment",
                column: "CourseOfferingId",
                principalTable: "CourseOffering",
                principalColumn: "CourseOfferingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Topic_TopicId",
                table: "Resource",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_CourseOffering_CourseOfferingId",
                table: "Topic",
                column: "CourseOfferingId",
                principalTable: "CourseOffering",
                principalColumn: "CourseOfferingId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicVideo_Topic_TopicId",
                table: "TopicVideos",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicVideo_Video_VideoId",
                table: "TopicVideos",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "VideoId");
        }
    }
}
