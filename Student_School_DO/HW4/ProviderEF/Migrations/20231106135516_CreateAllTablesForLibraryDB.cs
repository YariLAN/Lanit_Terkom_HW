using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProviderEF.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllTablesForLibraryDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories_books",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "genre_type",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "readers",
                columns: table => new
                {
                    ReaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    patronymic = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    id_category = table.Column<int>(type: "int", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_reader", x => x.ReaderId);
                    table.ForeignKey(
                        name: "FK_readers_categories_books_id_category",
                        column: x => x.id_category,
                        principalTable: "categories_books",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name_book = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_genre = table.Column<int>(type: "int", nullable: false),
                    collateral_value = table.Column<int>(type: "int", nullable: false),
                    rental_cost = table.Column<int>(type: "int", nullable: false),
                    count_book = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_books_genre_type_id_genre",
                        column: x => x.id_genre,
                        principalTable: "genre_type",
                        principalColumn: "GenreId");
                });

            migrationBuilder.CreateTable(
                name: "issued",
                columns: table => new
                {
                    IssuedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_reader = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_book = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date_issue = table.Column<DateTime>(type: "date", nullable: false),
                    date_due = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_issued", x => x.IssuedId);
                    table.ForeignKey(
                        name: "FK_issued_books_id_book",
                        column: x => x.id_book,
                        principalTable: "books",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_issued_readers_id_reader",
                        column: x => x.id_reader,
                        principalTable: "readers",
                        principalColumn: "ReaderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_id_genre",
                table: "books",
                column: "id_genre");

            migrationBuilder.CreateIndex(
                name: "IX_issued_id_book",
                table: "issued",
                column: "id_book");

            migrationBuilder.CreateIndex(
                name: "IX_issued_id_reader",
                table: "issued",
                column: "id_reader");

            migrationBuilder.CreateIndex(
                name: "IX_readers_id_category",
                table: "readers",
                column: "id_category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "issued");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "readers");

            migrationBuilder.DropTable(
                name: "genre_type");

            migrationBuilder.DropTable(
                name: "categories_books");
        }
    }
}
