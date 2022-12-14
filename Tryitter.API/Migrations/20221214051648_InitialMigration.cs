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
                values: new object[] { 1, "Administrador do Tryitter", "admin@email.com.br", "Admin", "https://via.placeholder.com/300/09f/fff.jpg", "Tryitter", 5, "admin123", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Email", "FirstName", "ImageUrl", "LastName", "ModuleId", "Password", "UserName" },
                values: new object[] { 2, "Criador do Tryitter", "yuri@email.com.br", "Yuri", "https://via.placeholder.com/300/09f/fff.jpg", "Carvalho", 5, "yuri123", "yuri" });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "Id", "Content", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Esté é o primeiro tweet do Tryitter", new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7410), new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7418), 2 },
                    { 2, "Olá, mundo!", new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7420), new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7421), 1 },
                    { 3, "Este é meu segundo tweet", new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7422), new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7422), 2 },
                    { 4, "Seja bem vindo ao Tryitter", new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7423), new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7424), 1 },
                    { 5, "Este é o meu último tweet", new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7425), new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7425), 2 },
                    { 6, "Este é o último tweet do Tryitter e meu último tambem ", new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7426), new DateTime(2022, 12, 14, 2, 16, 48, 423, DateTimeKind.Local).AddTicks(7427), 1 }
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
