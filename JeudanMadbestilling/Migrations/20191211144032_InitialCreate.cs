using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JeudanMadbestilling.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Madmenu",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu = table.Column<string>(nullable: true),
                    Med_Hjem_Køkken = table.Column<string>(nullable: true),
                    Dato = table.Column<DateTime>(nullable: false),
                    Uge = table.Column<int>(nullable: false),
                    UgeNavn = table.Column<string>(nullable: true),
                    MenuStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Madmenu", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Madbestillings",
                columns: table => new
                {
                    MadbestillingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(nullable: false),
                    MenuDato = table.Column<DateTime>(nullable: false),
                    MenuTekst = table.Column<string>(nullable: true),
                    AntalBestillinger = table.Column<int>(nullable: false),
                    BestilingsType = table.Column<string>(nullable: true),
                    BestillingsDateTime = table.Column<DateTime>(nullable: false),
                    Bruger = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Madbestillings", x => x.MadbestillingId);
                    table.ForeignKey(
                        name: "FK_Madbestillings_Madmenu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Madmenu",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Madbestillings_MenuId",
                table: "Madbestillings",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Madbestillings");

            migrationBuilder.DropTable(
                name: "Madmenu");
        }
    }
}
