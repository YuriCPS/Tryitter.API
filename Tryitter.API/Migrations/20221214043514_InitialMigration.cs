using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryitter.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tweets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fundamentos" },
                    { 2, "Front-end" },
                    { 3, "Back-end" },
                    { 4, "Ciencia da Computação" },
                    { 5, "Beyond" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Email", "FirstName", "ImageUrl", "LastName", "ModuleId", "Password", "UserName" },
                values: new object[] { 1, "Administrador do Tryitter", "admin@email.com.br", "Admin", "https://via.placeholder.com/300/09f/fff.jpg", "Tryitter", 5, "admin123", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Email", "FirstName", "ImageUrl", "LastName", "ModuleId", "Password", "UserName" },
                values: new object[] { 2, "Criador do Tryitter", "yuri@email.com.br", "Yuri", "https://via.placeholder.com/300/09f/fff.jpg", "Carvalho", 5, "yuri123", "Yuri" });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "Id", "Content", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Esté é o primeiro tweet do Tryitter", new DateTime(2022, 12, 14, 1, 35, 13, 874, DateTimeKind.Local).AddTicks(8097), new DateTime(2022, 12, 14, 1, 35, 13, 874, DateTimeKind.Local).AddTicks(8105), 2 },
                    { 2, "Olá, mundo!", new DateTime(2022, 12, 14, 1, 35, 13, 874, DateTimeKind.Local).AddTicks(8107), new DateTime(2022, 12, 14, 1, 35, 13, 874, DateTimeKind.Local).AddTicks(8107), 1 },
                    { 3, "Este é meu segundo tweet", new DateTime(2022, 12, 14, 1, 35, 13, 874, DateTimeKind.Local).AddTicks(8108), new DateTime(2022, 12, 14, 1, 35, 13, 874, DateTimeKind.Local).AddTicks(8109), 2 },
                    { 4, "Seja bem vindo ao Tryitter", new DateTime(2022, 12, 14, 1, 35, 13, 874, DateTimeKind.Local).AddTicks(8110), new DateTime(2022, 12, 14, 1, 35, 13, 874, DateTimeKind.Local).AddTicks(8110), 1 },
                    { 5, "Este é o meu último tweet", new DateTime(2022, 12, 14, 1, 35, 13, 874, DateTimeKind.Local).AddTicks(8112), new DateTime(2022, 12, 14, 1, 35, 13, 874, DateTimeKind.Local).AddTicks(8112), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_UserId",
                table: "Tweets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModuleId",
                table: "Users",
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
