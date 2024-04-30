using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoardInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PostInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssigneeID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriorityLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BoardModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PostInfo_BoardInfo_BoardModelID",
                        column: x => x.BoardModelID,
                        principalTable: "BoardInfo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CommentInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PostID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostModelsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentInfo_PostInfo_PostModelsID",
                        column: x => x.PostModelsID,
                        principalTable: "PostInfo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CommentReplyDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PostID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentReplyDTOID = table.Column<int>(type: "int", nullable: true),
                    CommentsModelsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReplyDTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentReplyDTO_CommentInfo_CommentsModelsID",
                        column: x => x.CommentsModelsID,
                        principalTable: "CommentInfo",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CommentReplyDTO_CommentReplyDTO_CommentReplyDTOID",
                        column: x => x.CommentReplyDTOID,
                        principalTable: "CommentReplyDTO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentInfo_PostModelsID",
                table: "CommentInfo",
                column: "PostModelsID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReplyDTO_CommentReplyDTOID",
                table: "CommentReplyDTO",
                column: "CommentReplyDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReplyDTO_CommentsModelsID",
                table: "CommentReplyDTO",
                column: "CommentsModelsID");

            migrationBuilder.CreateIndex(
                name: "IX_PostInfo_BoardModelID",
                table: "PostInfo",
                column: "BoardModelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInfo");

            migrationBuilder.DropTable(
                name: "CommentReplyDTO");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "CommentInfo");

            migrationBuilder.DropTable(
                name: "PostInfo");

            migrationBuilder.DropTable(
                name: "BoardInfo");
        }
    }
}
