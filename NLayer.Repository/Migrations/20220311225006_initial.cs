using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryBorders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name4 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name5 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name6 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name7 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name8 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name9 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryBorders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryBorders_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAN", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MEX", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLZ", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTM", null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLV", null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HND", null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NIC", null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRI", null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PAN", null }
                });

            migrationBuilder.InsertData(
                table: "CountryBorders",
                columns: new[] { "Id", "CountryId", "CreatedDate", "Name1", "Name2", "Name3", "Name4", "Name5", "Name6", "Name7", "Name8", "Name9", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6458), "USA", "CAN", null, null, null, null, null, null, null, null },
                    { 2, 2, new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6524), "USA", "MEX", null, null, null, null, null, null, null, null },
                    { 3, 3, new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6533), "USA", "MEX", "BLZ", null, null, null, null, null, null, null },
                    { 4, 4, new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6537), "USA", "MEX", "GTM", null, null, null, null, null, null, null },
                    { 5, 5, new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6546), "USA", "MEX", "GTM", "SLV", null, null, null, null, null, null },
                    { 6, 6, new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6555), "USA", "MEX", "GTM", "HND", null, null, null, null, null, null },
                    { 7, 7, new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6563), "USA", "MEX", "GTM", "HND", "NIC", null, null, null, null, null },
                    { 8, 8, new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6573), "USA", "MEX", "GTM", "HND", "NIC", "CRI", null, null, null, null },
                    { 9, 9, new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6582), "USA", "MEX", "GTM", "HND", "NIC", "CRI", "PAN", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryBorders_CountryId",
                table: "CountryBorders",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryBorders");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
