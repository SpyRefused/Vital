using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vital.Doctor.Migrations
{
    public partial class _20170607 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorMedicalConcepts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalConcepts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorTaxInformationCerficates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cif = table.Column<string>(nullable: true),
                    Fee = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Withholdings = table.Column<float>(nullable: false),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorTaxInformationCerficates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorMedicalConceptResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DoctorMedicalConceptId = table.Column<Guid>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalConceptResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalConceptResources_DoctorMedicalConcepts_DoctorMedicalConceptId",
                        column: x => x.DoctorMedicalConceptId,
                        principalTable: "DoctorMedicalConcepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalConceptResources_DoctorMedicalConceptId",
                table: "DoctorMedicalConceptResources",
                column: "DoctorMedicalConceptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorMedicalConceptResources");

            migrationBuilder.DropTable(
                name: "DoctorTaxInformationCerficates");

            migrationBuilder.DropTable(
                name: "DoctorMedicalConcepts");
        }
    }
}
