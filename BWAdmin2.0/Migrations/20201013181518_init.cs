using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BWAdmin2._0.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StraatNaam = table.Column<string>(nullable: true),
                    HuisNummer = table.Column<string>(nullable: true),
                    BusNummer = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Gemeente = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TelefoonNummer = table.Column<string>(nullable: true),
                    BtwNummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PersonInfoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_PersonInfo_PersonInfoId",
                        column: x => x.PersonInfoId,
                        principalTable: "PersonInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientReference = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    InfoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_PersonInfo_InfoId",
                        column: x => x.InfoId,
                        principalTable: "PersonInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OfferNumber = table.Column<string>(nullable: true),
                    ExperationDate = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    VatPercentage = table.Column<int>(nullable: false),
                    PrePaid = table.Column<decimal>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    InvoiceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    NumberOfInvoiceInYear = table.Column<int>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    OfferId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    NettoPrice = table.Column<decimal>(nullable: false),
                    MarginPercentage = table.Column<decimal>(nullable: false),
                    InvoiceId = table.Column<Guid>(nullable: true),
                    OfferId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItem_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItem_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_InfoId",
                table: "Clients",
                column: "InfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientId",
                table: "Invoices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OfferId",
                table: "Invoices",
                column: "OfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ClientId",
                table: "Offers",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonInfoId",
                table: "Users",
                column: "PersonInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_InvoiceId",
                table: "WorkItem",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_OfferId",
                table: "WorkItem",
                column: "OfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkItem");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PersonInfo");
        }
    }
}
