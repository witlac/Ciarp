using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicProductivity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Credit = table.Column<bool>(nullable: false),
                    NumberOfAuthors = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: true),
                    JournalType = table.Column<string>(nullable: true),
                    ArticleType = table.Column<string>(nullable: true),
                    JournalName = table.Column<string>(nullable: true),
                    Issn = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    BookType = table.Column<string>(nullable: true),
                    PublicationDate = table.Column<DateTime>(nullable: true),
                    Languaje = table.Column<string>(nullable: true),
                    Isbn = table.Column<string>(nullable: true),
                    Editorial = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: true),
                    EventType = table.Column<string>(nullable: true),
                    Event_Languaje = table.Column<string>(nullable: true),
                    EventPlace = table.Column<string>(nullable: true),
                    EventWeb = table.Column<string>(nullable: true),
                    Memories = table.Column<string>(nullable: true),
                    Event_Isbn = table.Column<string>(nullable: true),
                    Event_Issn = table.Column<string>(nullable: true),
                    Headline = table.Column<string>(nullable: true),
                    Impact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicProductivity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductivityId = table.Column<int>(nullable: true),
                    DateRequest = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    AssignedPoints = table.Column<decimal>(nullable: false),
                    EstimatedPoints = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_AcademicProductivity_ProductivityId",
                        column: x => x.ProductivityId,
                        principalTable: "AcademicProductivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suport",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    AcademicProductivityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suport", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Suport_AcademicProductivity_AcademicProductivityId",
                        column: x => x.AcademicProductivityId,
                        principalTable: "AcademicProductivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DocumentId = table.Column<string>(nullable: true),
                    DocumentType = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DedicationTime = table.Column<string>(nullable: true),
                    InvestigationGroup = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    ClaimDate = table.Column<DateTime>(nullable: false),
                    RequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_RequestId",
                table: "Claims",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ProductivityId",
                table: "Request",
                column: "ProductivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Suport_AcademicProductivityId",
                table: "Suport",
                column: "AcademicProductivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Suport");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AcademicProductivity");
        }
    }
}
