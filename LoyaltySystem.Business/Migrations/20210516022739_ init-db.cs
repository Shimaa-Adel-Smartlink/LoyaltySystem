using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoyaltySystem.Business.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "configurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PurchaseRewardPerPoint = table.Column<int>(nullable: false),
                    PurchaseRewardForPoint = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transactionLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TransactionTimestamp = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Action = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionLogs_CreatedByNavigation",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionLogs_UpdatedByNavigation",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactionLogs_CreatedBy",
                table: "transactionLogs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_transactionLogs_UpdatedBy",
                table: "transactionLogs",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configurations");

            migrationBuilder.DropTable(
                name: "transactionLogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
