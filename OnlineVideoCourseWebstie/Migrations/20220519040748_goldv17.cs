using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _V2__OnlineVideoCourseWebsite.Migrations
{
    public partial class goldv17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicVideo");

            migrationBuilder.CreateTable(
                name: "TopicVideo",
                columns: table => new
                {
                    TopicVideoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<long>(type: "bigint", nullable: false),
                    VideoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicVideo", x => x.TopicVideoId);
                    table.ForeignKey(
                        name: "FK_TopicVideo_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicVideo_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "df94fdc0-0f85-432f-91f2-da9909a96502");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0b97d250-bb01-459d-b9ac-c302328f67fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "1ec565cb-c580-4404-bb09-a506968e8662");

            migrationBuilder.CreateIndex(
                name: "IX_TopicVideo_TopicId",
                table: "TopicVideo",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicVideo_VideoId",
                table: "TopicVideo",
                column: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicVideo");

            migrationBuilder.CreateTable(
                name: "TopicVideos",
                columns: table => new
                {
                    TopicVideoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<long>(type: "bigint", nullable: false),
                    VideoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicVideos", x => x.TopicVideoId);
                    table.ForeignKey(
                        name: "FK_TopicVideos_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicVideos_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6f18d198-702d-4af7-b547-15460019927d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "eae9b945-25b8-46bc-ac53-611c570382b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "e98b7235-bafd-43a4-9cc1-928aeef85b52");

            migrationBuilder.CreateIndex(
                name: "IX_TopicVideos_TopicId",
                table: "TopicVideos",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicVideos_VideoId",
                table: "TopicVideos",
                column: "VideoId");
        }
    }
}
