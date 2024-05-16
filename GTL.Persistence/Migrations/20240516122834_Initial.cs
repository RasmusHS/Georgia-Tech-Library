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
            migrationBuilder.CreateTable(
                name: "item_catalog_entities",
                columns: table => new
                {
                    item_catalog_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isbn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subject_area = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    edition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item_catalog_entities", x => x.item_catalog_id);
                });

            migrationBuilder.CreateTable(
                name: "member_entities",
                columns: table => new
                {
                    member_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    home_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    campus_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ssn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    card_expiration_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    employee_position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_member_entities", x => x.member_id);
                });

            migrationBuilder.CreateTable(
                name: "author_entities",
                columns: table => new
                {
                    item_catalog_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_author_entities", x => new { x.item_catalog_id, x.name });
                    table.ForeignKey(
                        name: "fk_itemcatalog_id",
                        column: x => x.item_catalog_id,
                        principalTable: "item_catalog_entities",
                        principalColumn: "item_catalog_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_entities",
                columns: table => new
                {
                    item_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    item_catalog_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_lendable = table.Column<bool>(type: "bit", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item_entities", x => x.item_id);
                    table.ForeignKey(
                        name: "fkitem_catalog_id",
                        column: x => x.item_catalog_id,
                        principalTable: "item_catalog_entities",
                        principalColumn: "item_catalog_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "acquisition_entities",
                columns: table => new
                {
                    item_catalog_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    member_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    request_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_acquisition_entities", x => new { x.member_id, x.item_catalog_id, x.request_date });
                    table.ForeignKey(
                        name: "fk_item_catalogid",
                        column: x => x.item_catalog_id,
                        principalTable: "item_catalog_entities",
                        principalColumn: "item_catalog_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_member_id",
                        column: x => x.member_id,
                        principalTable: "member_entities",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reserve_item_entities",
                columns: table => new
                {
                    member_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    item_catalog_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date_reserved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reserve_item_entities", x => new { x.item_catalog_id, x.member_id });
                    table.ForeignKey(
                        name: "fk_itemcatalogid",
                        column: x => x.item_catalog_id,
                        principalTable: "item_catalog_entities",
                        principalColumn: "item_catalog_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_memberid",
                        column: x => x.member_id,
                        principalTable: "member_entities",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_borrowing_entities",
                columns: table => new
                {
                    member_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    item_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    due = table.Column<DateTime>(type: "datetime2", nullable: false),
                    returned_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item_borrowing_entities", x => new { x.member_id, x.item_id, x.start_date });
                    table.ForeignKey(
                        name: "fk_item_id",
                        column: x => x.item_id,
                        principalTable: "item_entities",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fkmember_id",
                        column: x => x.member_id,
                        principalTable: "member_entities",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_acquisition_entities_item_catalog_id",
                table: "acquisition_entities",
                column: "item_catalog_id");

            migrationBuilder.CreateIndex(
                name: "ix_item_borrowing_entities_item_id",
                table: "item_borrowing_entities",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_item_catalog_entities_subject_area",
                table: "item_catalog_entities",
                column: "subject_area");

            migrationBuilder.CreateIndex(
                name: "ix_item_catalog_entities_title",
                table: "item_catalog_entities",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_item_entities_item_catalog_id",
                table: "item_entities",
                column: "item_catalog_id");

            migrationBuilder.CreateIndex(
                name: "ix_reserve_item_entities_member_id",
                table: "reserve_item_entities",
                column: "member_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acquisition_entities");

            migrationBuilder.DropTable(
                name: "author_entities");

            migrationBuilder.DropTable(
                name: "item_borrowing_entities");

            migrationBuilder.DropTable(
                name: "reserve_item_entities");

            migrationBuilder.DropTable(
                name: "item_entities");

            migrationBuilder.DropTable(
                name: "member_entities");

            migrationBuilder.DropTable(
                name: "item_catalog_entities");
        }
    }
}
