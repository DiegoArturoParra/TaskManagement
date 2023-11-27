using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TemplateCRUDNet7.Migrations
{
    /// <inheritdoc />
    public partial class InitialTaskManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TASKS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NameTask = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASKS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TASKS_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("09545053-100d-4d65-b5f4-30dc76de76f5"), "laura@gmail.com", "Laura", "laura1234" },
                    { new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b"), "pilar@gmail.com", "Pilar", "pilar1234" },
                    { new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a"), "diegop177@hotmail.com", "Diego Parra", "diego1234" }
                });

            migrationBuilder.InsertData(
                table: "TASKS",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsCompleted", "IsDeleted", "NameTask", "UserId" },
                values: new object[,]
                {
                    { new Guid("0302f8f8-db25-43e6-bff5-f511a43800e0"), new DateTime(2023, 11, 29, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2771), null, "eliminar una tarea", true, false, "Tarea 2", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("031f1070-cfa6-4f30-8c68-70c7d4bede9c"), new DateTime(2023, 12, 17, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2950), null, "agregar una tarea al backlog", true, false, "Tarea 20", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("03841d45-17a4-4350-b624-c426db30db5c"), new DateTime(2023, 12, 3, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2807), null, "agregar una tarea al backlog", true, false, "Tarea 6", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("138c70c7-b804-41e6-a675-4ed095d81d68"), new DateTime(2023, 12, 29, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3095), null, "generar el jwt", true, false, "Tarea 32", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("1aaed3bf-da8c-4d7c-8f7f-9d8f20075363"), new DateTime(2024, 1, 14, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3250), null, "generar el jwt", true, false, "Tarea 48", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("1cfa40e0-658f-49b8-901a-9f8dcc693cb5"), new DateTime(2023, 12, 21, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3036), null, "agregar una tarea al backlog", true, false, "Tarea 24", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("20657245-8c4d-483e-9abd-d6ad019bc0b6"), new DateTime(2023, 12, 15, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2936), null, "generar el jwt", true, false, "Tarea 18", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("27207a42-b790-495b-bc03-34110da5c379"), new DateTime(2023, 12, 25, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3068), null, "generar el jwt", true, false, "Tarea 28", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("2ca45c38-b3dc-4878-b7cd-42b4d3b4fbca"), new DateTime(2024, 1, 10, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3222), null, "generar el jwt", true, false, "Tarea 44", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("2e33b687-6bca-49d5-b723-a4cff44003e1"), new DateTime(2023, 12, 24, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3061), null, "agregar una tarea al backlog", false, false, "Tarea 27", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("2fd01184-5bc3-46f0-9903-a9bff961be7a"), new DateTime(2023, 12, 23, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3054), null, "hacer el login", true, false, "Tarea 26", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("2fe952c8-ac08-4682-956d-6a6dcd323ac4"), new DateTime(2024, 1, 2, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3129), null, "hacer el login", true, false, "Tarea 36", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("320e503f-e352-44e7-9c90-e74ecdc191fd"), new DateTime(2023, 12, 4, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2815), null, "agregar una tarea al backlog", false, false, "Tarea 7", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("3cbc395b-3504-43fb-8713-90db4366b5b1"), new DateTime(2024, 1, 15, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3259), null, "eliminar una tarea", false, false, "Tarea 49", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("3e76d582-7158-4529-ba03-fbb427fdc3fc"), new DateTime(2023, 11, 28, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2665), null, "generar el jwt", false, false, "Tarea 1", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("45493534-b7df-47ef-9ea7-657955bb3cb1"), new DateTime(2023, 12, 2, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2796), null, "agregar una tarea al backlog", false, false, "Tarea 5", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("4ec63f6d-1573-45a7-ab02-540232fe107e"), new DateTime(2023, 12, 16, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2943), null, "eliminar una tarea", false, false, "Tarea 19", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("4edb9109-9e17-4595-81d8-47c16adc2441"), new DateTime(2023, 12, 10, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2897), null, "agregar una tarea al backlog", false, false, "Tarea 13", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("4f505301-c136-4e1e-8a0b-d09629bafb33"), new DateTime(2024, 1, 6, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3155), null, "generar el jwt", true, false, "Tarea 40", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("5a8c5612-ed9e-493d-930e-020cecdd63b5"), new DateTime(2024, 1, 3, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3136), null, "hacer el registro", false, false, "Tarea 37", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("5c385f9b-3aea-4eeb-ba1e-0a91c02d31c4"), new DateTime(2024, 1, 9, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3178), null, "generar el jwt", false, false, "Tarea 43", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("5e737ad7-633b-4637-8a84-cd53d62a55e5"), new DateTime(2023, 12, 19, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3022), null, "agregar una tarea al backlog", true, false, "Tarea 22", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("6018f5fe-6be2-4965-869b-ee4ef94cb66f"), new DateTime(2023, 12, 5, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2821), null, "agregar una tarea al backlog", true, false, "Tarea 8", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("6a7f4445-a3e0-44de-b1df-8fbff914f31d"), new DateTime(2023, 12, 28, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3088), null, "hacer el login", false, false, "Tarea 31", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("6a9dc62c-93c2-4043-a154-aafd68add68b"), new DateTime(2024, 1, 16, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3267), null, "eliminar una tarea", true, false, "Tarea 50", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("6c9c8c65-c1ab-4f62-8ec9-2311ad73fafc"), new DateTime(2023, 12, 14, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2926), null, "eliminar una tarea", false, false, "Tarea 17", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("759382d4-c6f7-48ca-b35a-fdfbb1f278e1"), new DateTime(2024, 1, 11, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3230), null, "agregar una tarea al backlog", false, false, "Tarea 45", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("7c6fcf07-5763-4740-a2f1-bd60e6ebb501"), new DateTime(2024, 1, 13, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3243), null, "agregar una tarea al backlog", false, false, "Tarea 47", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("84c092ad-8f7c-4492-90f5-0f24b5790704"), new DateTime(2023, 12, 12, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2910), null, "hacer el login", false, false, "Tarea 15", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("85e81027-2521-4fc3-bec8-06e91e691c86"), new DateTime(2024, 1, 12, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3237), null, "hacer el registro", true, false, "Tarea 46", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("8837997a-e342-4059-bfc7-8a296bbb01c9"), new DateTime(2023, 12, 26, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3074), null, "eliminar una tarea", false, false, "Tarea 29", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("8d223f61-967b-4083-ba7e-9ef0da640f20"), new DateTime(2023, 12, 18, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3013), null, "generar el jwt", false, false, "Tarea 21", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("92cf422c-52d9-44a5-b402-efa66f391a9b"), new DateTime(2023, 12, 11, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2904), null, "hacer el login", true, false, "Tarea 14", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("99e35573-3840-415d-beb4-5ca7bfc1419a"), new DateTime(2023, 11, 30, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2780), null, "agregar una tarea al backlog", false, false, "Tarea 3", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("9dda38e1-25d0-4781-8978-3f9d5c4b5bcb"), new DateTime(2024, 1, 8, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3171), null, "hacer el login", true, false, "Tarea 42", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("a413d69e-f203-4616-bc52-d88ebc76f009"), new DateTime(2023, 12, 8, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2881), null, "agregar una tarea al backlog", false, false, "Tarea 11", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("aab0af23-e589-4f73-95fd-8ea73b4d93f3"), new DateTime(2023, 12, 1, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2788), null, "agregar una tarea al backlog", true, false, "Tarea 4", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("ab99b95f-ea6d-475a-b1f7-faacda163936"), new DateTime(2023, 12, 30, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3104), null, "hacer el login", false, false, "Tarea 33", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("b70206e2-84d2-4385-a08e-58388b85d8fa"), new DateTime(2023, 12, 13, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2917), null, "hacer el login", true, false, "Tarea 16", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("d2ed0ce4-65e4-4a5b-a6cb-a0ccef47de66"), new DateTime(2023, 12, 31, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3114), null, "agregar una tarea al backlog", true, false, "Tarea 34", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("d30bd962-ae8c-4fec-822b-a9c6cf3a8952"), new DateTime(2023, 12, 22, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3047), null, "generar el jwt", false, false, "Tarea 25", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("da28584e-a631-49de-bb73-2fbc273511a4"), new DateTime(2023, 12, 20, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3029), null, "eliminar una tarea", false, false, "Tarea 23", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("db20a7de-81ab-499d-a195-29c541853d03"), new DateTime(2024, 1, 5, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3149), null, "hacer el login", false, false, "Tarea 39", new Guid("a73c074a-cf36-42d7-a21d-c2912ac8031a") },
                    { new Guid("e00b644a-f8dd-4191-aea4-43decc98cea0"), new DateTime(2023, 12, 9, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2889), null, "agregar una tarea al backlog", true, false, "Tarea 12", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("e6e5bfa2-8618-4adf-af82-031177e0b1b0"), new DateTime(2023, 12, 27, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3081), null, "agregar una tarea al backlog", true, false, "Tarea 30", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("f26bb131-f79e-47b8-ac21-6c56cce6f415"), new DateTime(2023, 12, 7, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2842), null, "hacer el login", true, false, "Tarea 10", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("f5a5ed65-6a60-418f-88f1-e3a18b1a68dd"), new DateTime(2023, 12, 6, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(2832), null, "eliminar una tarea", false, false, "Tarea 9", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("f67a5084-cf69-4c9d-8c6c-f54e03260a09"), new DateTime(2024, 1, 7, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3164), null, "generar el jwt", false, false, "Tarea 41", new Guid("09545053-100d-4d65-b5f4-30dc76de76f5") },
                    { new Guid("fc7572a9-644c-4e4b-83eb-91b4450f02d9"), new DateTime(2024, 1, 1, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3122), null, "eliminar una tarea", false, false, "Tarea 35", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") },
                    { new Guid("fd861f11-f19a-4fb1-9b49-5b1f54b6c419"), new DateTime(2024, 1, 4, 15, 27, 0, 223, DateTimeKind.Local).AddTicks(3142), null, "eliminar una tarea", true, false, "Tarea 38", new Guid("3c85ef10-5ed2-4563-9f2d-600f9d01397b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TASKS_UserId",
                table: "TASKS",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TASKS");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
