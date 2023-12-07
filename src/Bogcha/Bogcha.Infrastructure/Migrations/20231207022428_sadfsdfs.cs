using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bogcha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sadfsdfs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Adminlar",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guruh",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuruhName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guruh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bola",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ism = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Familiya = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuruhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bola", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bola_Guruh_GuruhId",
                        column: x => x.GuruhId,
                        principalSchema: "dbo",
                        principalTable: "Guruh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarbiyachi",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ism = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Familiya = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    GuruhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarbiyachi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarbiyachi_Guruh_GuruhId",
                        column: x => x.GuruhId,
                        principalSchema: "dbo",
                        principalTable: "Guruh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Davomat",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ishtirok = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    BolaId = table.Column<int>(type: "int", nullable: false),
                    TarbiyachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Davomat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Davomat_Bola_BolaId",
                        column: x => x.BolaId,
                        principalSchema: "dbo",
                        principalTable: "Bola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Davomat_Tarbiyachi_TarbiyachId",
                        column: x => x.TarbiyachId,
                        principalSchema: "dbo",
                        principalTable: "Tarbiyachi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Adminlar",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Admin", "Admin", "Admin" },
                    { 2, "Tarbiyachi", "Tarbiyachi", "Tarbiyachi" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Guruh",
                columns: new[] { "Id", "GuruhName" },
                values: new object[,]
                {
                    { 1, "Kamalak" },
                    { 2, "Kapalak" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Bola",
                columns: new[] { "Id", "Familiya", "GuruhId", "Ism" },
                values: new object[,]
                {
                    { 1, "Turdiyev", 1, "Yusuf" },
                    { 2, "Usmonov", 2, "Sardor" },
                    { 3, "Rustamova", 1, "Iymona" },
                    { 4, "Xoldorxonov", 2, "Po'latXo'ja" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tarbiyachi",
                columns: new[] { "Id", "Familiya", "GuruhId", "Ism" },
                values: new object[,]
                {
                    { 1, "Xolmatov", 1, "Asilbek" },
                    { 2, "Xajiqurbonov", 2, "Azizbek" },
                    { 3, "Turdiyeva", 1, "E'zoza" },
                    { 4, "Matqosimova", 2, "Mohigul" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Davomat",
                columns: new[] { "Id", "BolaId", "TarbiyachId", "Ishtirok" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 2, 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Davomat",
                columns: new[] { "Id", "BolaId", "TarbiyachId" },
                values: new object[] { 4, 4, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Bola_GuruhId",
                schema: "dbo",
                table: "Bola",
                column: "GuruhId");

            migrationBuilder.CreateIndex(
                name: "IX_Davomat_BolaId",
                schema: "dbo",
                table: "Davomat",
                column: "BolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Davomat_TarbiyachId",
                schema: "dbo",
                table: "Davomat",
                column: "TarbiyachId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarbiyachi_GuruhId",
                schema: "dbo",
                table: "Tarbiyachi",
                column: "GuruhId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminlar",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Davomat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Bola",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tarbiyachi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Guruh",
                schema: "dbo");
        }
    }
}
