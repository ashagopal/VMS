using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class InitialSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UiName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AttributeId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Attribute",
                columns: new[] { "Id", "Name", "UiName", "VehicleTypeId" },
                values: new object[] { 1, "Doors", "Doors", 1 });

            migrationBuilder.InsertData(
                table: "Attribute",
                columns: new[] { "Id", "Name", "UiName", "VehicleTypeId" },
                values: new object[] { 2, "Engine", "Engine", 1 });

            migrationBuilder.InsertData(
                table: "Attribute",
                columns: new[] { "Id", "Name", "UiName", "VehicleTypeId" },
                values: new object[] { 3, "BodyType", "Body Type", 1 });

            migrationBuilder.InsertData(
                table: "Attribute",
                columns: new[] { "Id", "Name", "UiName", "VehicleTypeId" },
                values: new object[] { 4, "Wheel", "Wheels", 1 });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Car" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "AttributeValue");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
