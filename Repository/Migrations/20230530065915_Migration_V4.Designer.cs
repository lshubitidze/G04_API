﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Database;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(TBCDbContext))]
    [Migration("20230530065915_Migration_V4")]
    partial class Migration_V4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fasade.DTO.CityDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Fasade.DTO.PersonDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("PhoneType")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Poersons");
                });

            modelBuilder.Entity("Fasade.DTO.RelatedPersonDTO", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedPersonId")
                        .HasColumnType("int");

                    b.Property<int>("RelationType")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "RelatedPersonId");

                    b.HasIndex("RelatedPersonId");

                    b.ToTable("RelatedPeople");
                });

            modelBuilder.Entity("Fasade.DTO.UserDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasAlternateKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Fasade.DTO.PersonDTO", b =>
                {
                    b.HasOne("Fasade.DTO.CityDTO", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Fasade.DTO.RelatedPersonDTO", b =>
                {
                    b.HasOne("Fasade.DTO.PersonDTO", "Person")
                        .WithMany("RelatedPeople")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fasade.DTO.PersonDTO", "RelatedPerson")
                        .WithMany("RelatedPeopleOf")
                        .HasForeignKey("RelatedPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("RelatedPerson");
                });

            modelBuilder.Entity("Fasade.DTO.PersonDTO", b =>
                {
                    b.Navigation("RelatedPeople");

                    b.Navigation("RelatedPeopleOf");
                });
#pragma warning restore 612, 618
        }
    }
}