using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ODataSample.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "odata");

            migrationBuilder.CreateTable(
                name: "Activities",
                schema: "odata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "odata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerActivities",
                schema: "odata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    ActivityId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "odata",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerActivities_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "odata",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "odata",
                table: "Activities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description", "October Fest" },
                    { 2, "Description", "Kurban Bayramı" },
                    { 3, "Description", "Ramazan Bayramı" },
                    { 4, "Description", "Yılbaşı" },
                    { 5, "Description", "23 Nisan Ulusal Egemenlik ve Çocuk Bayramı" }
                });

            migrationBuilder.InsertData(
                schema: "odata",
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Hakan", "Altındiş" },
                    { 2, "John", "Deere" }
                });

            migrationBuilder.InsertData(
                schema: "odata",
                table: "Customers",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName" },
                values: new object[] { 3, "Joe", true, "Smith" });

            migrationBuilder.InsertData(
                schema: "odata",
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 4, "Sezen", "Altındiş" });

            migrationBuilder.InsertData(
                schema: "odata",
                table: "CustomerActivities",
                columns: new[] { "Id", "ActivityId", "CustomerId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 4, 1 },
                    { 4, 1, 2 },
                    { 5, 3, 1 },
                    { 6, 5, 1 },
                    { 7, 1, 3 },
                    { 8, 3, 3 },
                    { 9, 2, 4 },
                    { 10, 1, 4 },
                    { 11, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerActivities_ActivityId",
                schema: "odata",
                table: "CustomerActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerActivities_CustomerId",
                schema: "odata",
                table: "CustomerActivities",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerActivities",
                schema: "odata");

            migrationBuilder.DropTable(
                name: "Activities",
                schema: "odata");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "odata");
        }
    }
}
