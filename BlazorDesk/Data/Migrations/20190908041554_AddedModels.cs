using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorDesk.Data.Migrations
{
    public partial class AddedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestCategory_CategoryId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestStatus_StatusId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_AspNetUsers_UserId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestApproval_Request_RequestId",
                table: "RequestApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestApproval_ApprovalStatus_StatusId",
                table: "RequestApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestAttachment_Request_RequestId",
                table: "RequestAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestNote_Request_RequestId",
                table: "RequestNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestStatus",
                table: "RequestStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestNote",
                table: "RequestNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestCategory",
                table: "RequestCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestAttachment",
                table: "RequestAttachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestApproval",
                table: "RequestApproval");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApprovalStatus",
                table: "ApprovalStatus");

            migrationBuilder.RenameTable(
                name: "RequestStatus",
                newName: "RequestStatuses");

            migrationBuilder.RenameTable(
                name: "RequestNote",
                newName: "RequestNotes");

            migrationBuilder.RenameTable(
                name: "RequestCategory",
                newName: "RequestCategories");

            migrationBuilder.RenameTable(
                name: "RequestAttachment",
                newName: "RequestAttachments");

            migrationBuilder.RenameTable(
                name: "RequestApproval",
                newName: "RequestApprovals");

            migrationBuilder.RenameTable(
                name: "Request",
                newName: "Requests");

            migrationBuilder.RenameTable(
                name: "ApprovalStatus",
                newName: "ApprovalStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_RequestNote_RequestId",
                table: "RequestNotes",
                newName: "IX_RequestNotes_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestAttachment_RequestId",
                table: "RequestAttachments",
                newName: "IX_RequestAttachments_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestApproval_StatusId",
                table: "RequestApprovals",
                newName: "IX_RequestApprovals_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestApproval_RequestId",
                table: "RequestApprovals",
                newName: "IX_RequestApprovals_RequestId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Requests",
                newName: "RequesterId");

            migrationBuilder.RenameColumn(
                name: "Requester",
                table: "Requests",
                newName: "History");

            migrationBuilder.RenameColumn(
                name: "AssignedTo",
                table: "Requests",
                newName: "AssignedToId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_UserId",
                table: "Requests",
                newName: "IX_Requests_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_StatusId",
                table: "Requests",
                newName: "IX_Requests_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_CategoryId",
                table: "Requests",
                newName: "IX_Requests_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "RequesterId",
                table: "RequestApprovals",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApproverId",
                table: "RequestApprovals",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssignedToId",
                table: "Requests",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestNotes",
                table: "RequestNotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestCategories",
                table: "RequestCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestAttachments",
                table: "RequestAttachments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestApprovals",
                table: "RequestApprovals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalStatuses",
                table: "ApprovalStatuses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RequestReplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 20000, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestReplies_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestReplies_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Content = table.Column<string>(maxLength: 20000, nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    Views = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solutions_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReplyAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(maxLength: 200, nullable: false),
                    PathToFile = table.Column<string>(maxLength: 1000, nullable: false),
                    ReplyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplyAttachments_RequestReplies_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "RequestReplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolutionAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(maxLength: 200, nullable: false),
                    PathToFile = table.Column<string>(maxLength: 1000, nullable: false),
                    SolutionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionAttachments_Solutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApprovalStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Approved" },
                    { 3, "Denied" }
                });

            migrationBuilder.InsertData(
                table: "RequestCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "First Category" },
                    { 2, "Second Category" },
                    { 3, "Third Category" },
                    { 4, "Fourth Category" },
                    { 5, "Fifth Category" }
                });

            migrationBuilder.InsertData(
                table: "RequestStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Closed" },
                    { 3, "Rejected" },
                    { 4, "On Hold" },
                    { 5, "For Approval" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestApprovals_ApproverId",
                table: "RequestApprovals",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestApprovals_RequesterId",
                table: "RequestApprovals",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AssignedToId",
                table: "Requests",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyAttachments_ReplyId",
                table: "ReplyAttachments",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestReplies_AuthorId",
                table: "RequestReplies",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestReplies_RequestId",
                table: "RequestReplies",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionAttachments_SolutionId",
                table: "SolutionAttachments",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_AuthorId",
                table: "Solutions",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestApprovals_AspNetUsers_ApproverId",
                table: "RequestApprovals",
                column: "ApproverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestApprovals_Requests_RequestId",
                table: "RequestApprovals",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestApprovals_AspNetUsers_RequesterId",
                table: "RequestApprovals",
                column: "RequesterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestApprovals_ApprovalStatuses_StatusId",
                table: "RequestApprovals",
                column: "StatusId",
                principalTable: "ApprovalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestAttachments_Requests_RequestId",
                table: "RequestAttachments",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestNotes_Requests_RequestId",
                table: "RequestNotes",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_AssignedToId",
                table: "Requests",
                column: "AssignedToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestCategories_CategoryId",
                table: "Requests",
                column: "CategoryId",
                principalTable: "RequestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_RequesterId",
                table: "Requests",
                column: "RequesterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestStatuses_StatusId",
                table: "Requests",
                column: "StatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestApprovals_AspNetUsers_ApproverId",
                table: "RequestApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestApprovals_Requests_RequestId",
                table: "RequestApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestApprovals_AspNetUsers_RequesterId",
                table: "RequestApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestApprovals_ApprovalStatuses_StatusId",
                table: "RequestApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestAttachments_Requests_RequestId",
                table: "RequestAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestNotes_Requests_RequestId",
                table: "RequestNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_AssignedToId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestCategories_CategoryId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_RequesterId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestStatuses_StatusId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "ReplyAttachments");

            migrationBuilder.DropTable(
                name: "SolutionAttachments");

            migrationBuilder.DropTable(
                name: "RequestReplies");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_AssignedToId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestNotes",
                table: "RequestNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestCategories",
                table: "RequestCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestAttachments",
                table: "RequestAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestApprovals",
                table: "RequestApprovals");

            migrationBuilder.DropIndex(
                name: "IX_RequestApprovals_ApproverId",
                table: "RequestApprovals");

            migrationBuilder.DropIndex(
                name: "IX_RequestApprovals_RequesterId",
                table: "RequestApprovals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApprovalStatuses",
                table: "ApprovalStatuses");

            migrationBuilder.DeleteData(
                table: "ApprovalStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApprovalStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApprovalStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RequestCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RequestCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RequestCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RequestCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RequestCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "RequestApprovals");

            migrationBuilder.RenameTable(
                name: "RequestStatuses",
                newName: "RequestStatus");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "Request");

            migrationBuilder.RenameTable(
                name: "RequestNotes",
                newName: "RequestNote");

            migrationBuilder.RenameTable(
                name: "RequestCategories",
                newName: "RequestCategory");

            migrationBuilder.RenameTable(
                name: "RequestAttachments",
                newName: "RequestAttachment");

            migrationBuilder.RenameTable(
                name: "RequestApprovals",
                newName: "RequestApproval");

            migrationBuilder.RenameTable(
                name: "ApprovalStatuses",
                newName: "ApprovalStatus");

            migrationBuilder.RenameColumn(
                name: "RequesterId",
                table: "Request",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "History",
                table: "Request",
                newName: "Requester");

            migrationBuilder.RenameColumn(
                name: "AssignedToId",
                table: "Request",
                newName: "AssignedTo");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_StatusId",
                table: "Request",
                newName: "IX_Request_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequesterId",
                table: "Request",
                newName: "IX_Request_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_CategoryId",
                table: "Request",
                newName: "IX_Request_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestNotes_RequestId",
                table: "RequestNote",
                newName: "IX_RequestNote_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestAttachments_RequestId",
                table: "RequestAttachment",
                newName: "IX_RequestAttachment_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestApprovals_StatusId",
                table: "RequestApproval",
                newName: "IX_RequestApproval_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestApprovals_RequestId",
                table: "RequestApproval",
                newName: "IX_RequestApproval_RequestId");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedTo",
                table: "Request",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequesterId",
                table: "RequestApproval",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestStatus",
                table: "RequestStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestNote",
                table: "RequestNote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestCategory",
                table: "RequestCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestAttachment",
                table: "RequestAttachment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestApproval",
                table: "RequestApproval",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalStatus",
                table: "ApprovalStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestCategory_CategoryId",
                table: "Request",
                column: "CategoryId",
                principalTable: "RequestCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestStatus_StatusId",
                table: "Request",
                column: "StatusId",
                principalTable: "RequestStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_AspNetUsers_UserId",
                table: "Request",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestApproval_Request_RequestId",
                table: "RequestApproval",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestApproval_ApprovalStatus_StatusId",
                table: "RequestApproval",
                column: "StatusId",
                principalTable: "ApprovalStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestAttachment_Request_RequestId",
                table: "RequestAttachment",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestNote_Request_RequestId",
                table: "RequestNote",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
