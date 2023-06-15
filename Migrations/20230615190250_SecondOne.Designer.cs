﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdminScol.Migrations
{
    [DbContext(typeof(AdminScolDbContext))]
    [Migration("20230615190250_SecondOne")]
    partial class SecondOne
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdminScol.Models.AnneeAcademique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnneeScolaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Statut")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AnneeAcademiques");
                });

            modelBuilder.Entity("AdminScol.Models.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnneeAcademiqueId")
                        .HasColumnType("int");

                    b.Property<int?>("EtudiantId")
                        .HasColumnType("int");

                    b.Property<string>("Niveau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnneeAcademiqueId");

                    b.HasIndex("EtudiantId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("AdminScol.Models.Cour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClasseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomCours")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.ToTable("Cours");
                });

            modelBuilder.Entity("AdminScol.Models.Etudiant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClasseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Maladie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatutMatrimonial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.ToTable("Etudiants");
                });

            modelBuilder.Entity("AdminScol.Models.Classe", b =>
                {
                    b.HasOne("AdminScol.Models.AnneeAcademique", "AnneeAcademique")
                        .WithMany("Classes")
                        .HasForeignKey("AnneeAcademiqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdminScol.Models.Etudiant", null)
                        .WithMany("Classes")
                        .HasForeignKey("EtudiantId");

                    b.Navigation("AnneeAcademique");
                });

            modelBuilder.Entity("AdminScol.Models.Cour", b =>
                {
                    b.HasOne("AdminScol.Models.Classe", "Classe")
                        .WithMany("Cours")
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("AdminScol.Models.Etudiant", b =>
                {
                    b.HasOne("AdminScol.Models.Classe", "Classe")
                        .WithMany()
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("AdminScol.Models.AnneeAcademique", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("AdminScol.Models.Classe", b =>
                {
                    b.Navigation("Cours");
                });

            modelBuilder.Entity("AdminScol.Models.Etudiant", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}