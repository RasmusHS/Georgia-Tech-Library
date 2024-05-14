using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "book");

            migrationBuilder.EnsureSchema(
                name: "bookCatalog");

            migrationBuilder.EnsureSchema(
                name: "member");

            migrationBuilder.CreateTable(
                name: "BookCatalog",
                schema: "bookCatalog",
                columns: table => new
                {
                    book_catalog_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isbn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    authors = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subject_area = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    edition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_catalog", x => x.book_catalog_id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                schema: "member",
                columns: table => new
                {
                    member_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    home_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    campus_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ssn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    card_expiration_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_member", x => x.member_id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "book",
                columns: table => new
                {
                    book_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    book_catalog_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    catalog_book_catalog_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_lendable = table.Column<bool>(type: "bit", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book", x => x.book_id);
                    table.ForeignKey(
                        name: "fk_book_book_catalog_catalog_book_catalog_id",
                        column: x => x.catalog_book_catalog_id,
                        principalSchema: "bookCatalog",
                        principalTable: "BookCatalog",
                        principalColumn: "book_catalog_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_borrowing_entities",
                columns: table => new
                {
                    books_book_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    members_member_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    member_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    book_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    due = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    returned_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_borrowing_entities", x => new { x.books_book_id, x.members_member_id });
                    table.ForeignKey(
                        name: "fk_book_borrowing_entities_book_books_book_id",
                        column: x => x.books_book_id,
                        principalSchema: "book",
                        principalTable: "Book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_borrowing_entities_member_members_member_id",
                        column: x => x.members_member_id,
                        principalSchema: "member",
                        principalTable: "Member",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_book_catalog_book_catalog_id",
                schema: "book",
                table: "Book",
                column: "catalog_book_catalog_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_borrowing_entities_members_member_id",
                table: "book_borrowing_entities",
                column: "members_member_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_catalog_authors",
                schema: "bookCatalog",
                table: "BookCatalog",
                column: "authors");

            migrationBuilder.CreateIndex(
                name: "ix_book_catalog_isbn",
                schema: "bookCatalog",
                table: "BookCatalog",
                column: "isbn");

            migrationBuilder.CreateIndex(
                name: "ix_book_catalog_subject_area",
                schema: "bookCatalog",
                table: "BookCatalog",
                column: "subject_area");

            migrationBuilder.CreateIndex(
                name: "ix_book_catalog_title",
                schema: "bookCatalog",
                table: "BookCatalog",
                column: "title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_borrowing_entities");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "book");

            migrationBuilder.DropTable(
                name: "Member",
                schema: "member");

            migrationBuilder.DropTable(
                name: "BookCatalog",
                schema: "bookCatalog");
        }
    }
}
