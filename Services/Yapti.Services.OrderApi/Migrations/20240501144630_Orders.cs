using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yapti.Services.OrderApi.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CategoryName", "DeadLine", "Description", "ImageUrl", "Message", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Какая-то категория", new DateTime(2024, 5, 1, 17, 46, 29, 646, DateTimeKind.Local).AddTicks(336), "Так как я больше не могу этим заниматься, псу 8 лет, Лабрадор", "", "", "Почистить зубы псу", 3000.0 },
                    { 2, "Какая-то категория", new DateTime(2024, 5, 1, 17, 46, 29, 646, DateTimeKind.Local).AddTicks(372), "На кухне и ванной", "", "", "Помыть полки", 1200.0 },
                    { 3, "Какая-то категория", new DateTime(2024, 5, 1, 17, 46, 29, 646, DateTimeKind.Local).AddTicks(381), "а то меня попросили, а я не умею", "", "", "Сделать макет сайта", 60000.0 },
                    { 4, "Какая-то категория", new DateTime(2024, 5, 1, 17, 46, 29, 646, DateTimeKind.Local).AddTicks(389), "Ключ у соседа", "", "", "Покормить кота по адресу", 15.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
