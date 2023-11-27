using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TemplateCRUDNet7.Migrations
{
    /// <inheritdoc />
    public partial class InitialEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "QUALA");

            migrationBuilder.CreateTable(
                name: "CURRENCY",
                schema: "QUALA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURRENCY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BRANCH_OFFICES",
                schema: "QUALA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCH_OFFICES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRANCH_OFFICES_CURRENCY_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "QUALA",
                        principalTable: "CURRENCY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "QUALA",
                table: "CURRENCY",
                columns: new[] { "Id", "Acronym", "Description" },
                values: new object[,]
                {
                    { new Guid("0803e4e3-75cc-48c5-a3c9-b5bd27ad7b0d"), "CHF", "Franco suizo" },
                    { new Guid("2efb906f-3eb5-4143-b936-d19525389551"), "GBP", "Libra esterlina" },
                    { new Guid("3026df76-0919-4cab-99b6-972e76adbdb9"), "EUR", "Euro" },
                    { new Guid("30521493-3784-42a6-9c3a-6878a82cc718"), "AUD", "Dólar australiano" },
                    { new Guid("331a6bef-a1f1-4911-a0b2-123a2e9b0651"), "USD", "Dólar estadounidense" },
                    { new Guid("6d4abaf0-c7c7-48da-bdfd-d13a265b65e5"), "CAD", "Dólar canadiense" },
                    { new Guid("82e58f8e-fd8b-4601-9d2a-390ff05f5ef2"), "NZD", "Dólar neozelandés" },
                    { new Guid("998a498f-9bdd-438e-9363-129a82a8a3f1"), "JPY", "Yen japonés" },
                    { new Guid("bebd20c0-bf7d-40f5-99dd-27b5dbf65abf"), "CNY", "Yuan chino" },
                    { new Guid("c2551abf-cd74-4df4-bcdb-e056e8ade9a7"), "SEK", "Corona sueca" }
                });

            migrationBuilder.InsertData(
                schema: "QUALA",
                table: "BRANCH_OFFICES",
                columns: new[] { "Id", "Address", "Code", "CurrencyId", "DateCreated", "DateUpdated", "Description", "Identification", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("210617fe-7051-4bab-9b41-1408c95f13db"), "Address 3", 3, new Guid("bebd20c0-bf7d-40f5-99dd-27b5dbf65abf"), new DateTime(2023, 10, 29, 17, 19, 54, 755, DateTimeKind.Local).AddTicks(4345), null, "Boka", "Identification 3", false },
                    { new Guid("56d88913-4c91-48c5-bd10-d1207ff313fe"), "Address 1", 1, new Guid("30521493-3784-42a6-9c3a-6878a82cc718"), new DateTime(2023, 10, 27, 17, 19, 54, 755, DateTimeKind.Local).AddTicks(4047), null, "Quipitos", "Identification 1", false },
                    { new Guid("b4bfc08e-87cd-4cf0-9fb2-0dab76b746f8"), "Address 2", 2, new Guid("6d4abaf0-c7c7-48da-bdfd-d13a265b65e5"), new DateTime(2023, 10, 28, 17, 19, 54, 755, DateTimeKind.Local).AddTicks(4326), null, "Suntea", "Identification 2", false },
                    { new Guid("de24bc52-4f25-40ef-8b12-44d5bbd6a3e5"), "Address 4", 4, new Guid("2efb906f-3eb5-4143-b936-d19525389551"), new DateTime(2023, 10, 30, 17, 19, 54, 755, DateTimeKind.Local).AddTicks(4357), null, "Ricostilla", "Identification 4", false },
                    { new Guid("fc4a72f7-fb22-41c2-9f0f-0971c68311f9"), "Address 5", 5, new Guid("bebd20c0-bf7d-40f5-99dd-27b5dbf65abf"), new DateTime(2023, 10, 31, 17, 19, 54, 755, DateTimeKind.Local).AddTicks(4368), null, "Boka", "Identification 5", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BRANCH_OFFICES_CurrencyId",
                schema: "QUALA",
                table: "BRANCH_OFFICES",
                column: "CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BRANCH_OFFICES",
                schema: "QUALA");

            migrationBuilder.DropTable(
                name: "CURRENCY",
                schema: "QUALA");
        }
    }
}
