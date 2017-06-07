using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Vital.Doctor;

namespace Vital.Doctor.Migrations
{
    [DbContext(typeof(DoctorVital))]
    [Migration("20170607091106_20170607")]
    partial class _20170607
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vital.Doctor.DoctorMedicalConcept", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("DoctorMedicalConcepts");
                });

            modelBuilder.Entity("Vital.Doctor.DoctorMedicalConceptResources", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("DoctorMedicalConceptId");

                    b.Property<string>("Key");

                    b.Property<string>("Language");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("DoctorMedicalConceptId");

                    b.ToTable("DoctorMedicalConceptResources");
                });

            modelBuilder.Entity("Vital.Doctor.DoctorTaxInformationCerficate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cif");

                    b.Property<float>("Fee");

                    b.Property<string>("Name");

                    b.Property<float>("Withholdings");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.ToTable("DoctorTaxInformationCerficates");
                });

            modelBuilder.Entity("Vital.Doctor.DoctorMedicalConceptResources", b =>
                {
                    b.HasOne("Vital.Doctor.DoctorMedicalConcept")
                        .WithMany("Resources")
                        .HasForeignKey("DoctorMedicalConceptId");
                });
        }
    }
}
