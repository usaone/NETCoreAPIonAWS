﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCoreAPI.Migrations
{
    public partial class initializeandseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Name" },
                values: new object[,]
                {
                    { 1, "Mico Yuk" },
                    { 2, "Arlan Hamilton" },
                    { 3, "Minda Harts" },
                    { 4, "Susanne Tedrick" },
                    { 5, "Abisoye Ajayi-Akinfolarin" },
                    { 6, "Kesha Williams" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Data Visualization for Dummies" },
                    { 2, 2, "It's About Damn Time" },
                    { 3, 3, "The Memo" },
                    { 4, 4, "Women of Color in Tech" },
                    { 5, 5, "I WOKE UP AT 30: How I Utilised Inertia for Global Impact" },
                    { 6, 6, "No books but check out her Pluralsight courses!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
