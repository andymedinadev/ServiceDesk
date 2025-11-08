using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceDesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGuidForInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Tickets_Users_CreatedById", table: "Tickets");
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_AssignedToId",
                table: "Tickets"
            );
            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachments_Users_UploadedById",
                table: "TicketAttachments"
            );
            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Users_AuthorId",
                table: "TicketComments"
            );
            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatusHistory_Users_ChangedById",
                table: "TicketStatusHistory"
            );

            migrationBuilder.DropIndex(name: "IX_Tickets_CreatedById", table: "Tickets");
            migrationBuilder.DropIndex(name: "IX_Tickets_AssignedToId", table: "Tickets");
            migrationBuilder.DropIndex(
                name: "IX_TicketAttachments_UploadedById",
                table: "TicketAttachments"
            );
            migrationBuilder.DropIndex(name: "IX_TicketComments_AuthorId", table: "TicketComments");
            migrationBuilder.DropIndex(
                name: "IX_TicketStatusHistory_ChangedById",
                table: "TicketStatusHistory"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_Users", table: "Users");

            migrationBuilder.DropColumn(name: "Id", table: "Users");

            migrationBuilder
                .AddColumn<int>(
                    name: "Id",
                    table: "Users",
                    type: "int",
                    nullable: false,
                    defaultValue: 0
                )
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(name: "PK_Users", table: "Users", column: "Id");

            migrationBuilder.DropColumn(name: "CreatedById", table: "Tickets");
            migrationBuilder.DropColumn(name: "AssignedToId", table: "Tickets");
            migrationBuilder.DropColumn(name: "UploadedById", table: "TicketAttachments");
            migrationBuilder.DropColumn(name: "AuthorId", table: "TicketComments");
            migrationBuilder.DropColumn(name: "ChangedById", table: "TicketStatusHistory");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<int>(
                name: "AssignedToId",
                table: "Tickets",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UploadedById",
                table: "TicketAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "TicketComments",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<int>(
                name: "ChangedById",
                table: "TicketStatusHistory",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatedById",
                table: "Tickets",
                column: "CreatedById"
            );
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssignedToId",
                table: "Tickets",
                column: "AssignedToId"
            );
            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachments_UploadedById",
                table: "TicketAttachments",
                column: "UploadedById"
            );
            migrationBuilder.CreateIndex(
                name: "IX_TicketComments_AuthorId",
                table: "TicketComments",
                column: "AuthorId"
            );
            migrationBuilder.CreateIndex(
                name: "IX_TicketStatusHistory_ChangedById",
                table: "TicketStatusHistory",
                column: "ChangedById"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_CreatedById",
                table: "Tickets",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_AssignedToId",
                table: "Tickets",
                column: "AssignedToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachments_Users_UploadedById",
                table: "TicketAttachments",
                column: "UploadedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Users_AuthorId",
                table: "TicketComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatusHistory_Users_ChangedById",
                table: "TicketStatusHistory",
                column: "ChangedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Tickets_Users_CreatedById", table: "Tickets");
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_AssignedToId",
                table: "Tickets"
            );
            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachments_Users_UploadedById",
                table: "TicketAttachments"
            );
            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Users_AuthorId",
                table: "TicketComments"
            );
            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatusHistory_Users_ChangedById",
                table: "TicketStatusHistory"
            );

            migrationBuilder.DropIndex(name: "IX_Tickets_CreatedById", table: "Tickets");
            migrationBuilder.DropIndex(name: "IX_Tickets_AssignedToId", table: "Tickets");
            migrationBuilder.DropIndex(
                name: "IX_TicketAttachments_UploadedById",
                table: "TicketAttachments"
            );
            migrationBuilder.DropIndex(name: "IX_TicketComments_AuthorId", table: "TicketComments");
            migrationBuilder.DropIndex(
                name: "IX_TicketStatusHistory_ChangedById",
                table: "TicketStatusHistory"
            );

            migrationBuilder.DropColumn(name: "CreatedById", table: "Tickets");
            migrationBuilder.DropColumn(name: "AssignedToId", table: "Tickets");
            migrationBuilder.DropColumn(name: "UploadedById", table: "TicketAttachments");
            migrationBuilder.DropColumn(name: "AuthorId", table: "TicketComments");
            migrationBuilder.DropColumn(name: "ChangedById", table: "TicketStatusHistory");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false
            );

            migrationBuilder.AddColumn<Guid>(
                name: "AssignedToId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true
            );

            migrationBuilder.AddColumn<Guid>(
                name: "UploadedById",
                table: "TicketAttachments",
                type: "uniqueidentifier",
                nullable: false
            );

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "TicketComments",
                type: "uniqueidentifier",
                nullable: false
            );

            migrationBuilder.AddColumn<Guid>(
                name: "ChangedById",
                table: "TicketStatusHistory",
                type: "uniqueidentifier",
                nullable: false
            );

            migrationBuilder.DropPrimaryKey(name: "PK_Users", table: "Users");
            migrationBuilder.DropColumn(name: "Id", table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()"
            );

            migrationBuilder.AddPrimaryKey(name: "PK_Users", table: "Users", column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatedById",
                table: "Tickets",
                column: "CreatedById"
            );
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssignedToId",
                table: "Tickets",
                column: "AssignedToId"
            );
            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachments_UploadedById",
                table: "TicketAttachments",
                column: "UploadedById"
            );
            migrationBuilder.CreateIndex(
                name: "IX_TicketComments_AuthorId",
                table: "TicketComments",
                column: "AuthorId"
            );
            migrationBuilder.CreateIndex(
                name: "IX_TicketStatusHistory_ChangedById",
                table: "TicketStatusHistory",
                column: "ChangedById"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_CreatedById",
                table: "Tickets",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_AssignedToId",
                table: "Tickets",
                column: "AssignedToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachments_Users_UploadedById",
                table: "TicketAttachments",
                column: "UploadedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Users_AuthorId",
                table: "TicketComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatusHistory_Users_ChangedById",
                table: "TicketStatusHistory",
                column: "ChangedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction
            );
        }
    }
}
