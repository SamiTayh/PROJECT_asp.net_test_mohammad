﻿// <auto-generated />
using System;
using Asp.DALL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Asp.DALL.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20230523085059_travelll")]
    partial class travelll
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Asp.DALL.Entites.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genderid")
                        .HasColumnType("int");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ListBooksId")
                        .HasColumnType("int");

                    b.Property<int>("Listid")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Genderid");

                    b.HasIndex("ListBooksId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Fileextention", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genderid")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Genderid");

                    b.ToTable("fileextention");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Languges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Extention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genderid")
                        .HasColumnType("int");

                    b.Property<string>("LangugeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LangugeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LangugeTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ListBooksId")
                        .HasColumnType("int");

                    b.Property<int>("listid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Genderid");

                    b.HasIndex("ListBooksId");

                    b.ToTable("Langugess");
                });

            modelBuilder.Entity("Asp.DALL.Entites.ListBooks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameBooks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ListBooks");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Majales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genderid")
                        .HasColumnType("int");

                    b.Property<int?>("ListBooksId")
                        .HasColumnType("int");

                    b.Property<int>("Listid")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Genderid");

                    b.HasIndex("ListBooksId");

                    b.ToTable("Majaless");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Mohammad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genderid")
                        .HasColumnType("int");

                    b.Property<int?>("ListBooksId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("listsid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Genderid");

                    b.HasIndex("ListBooksId");

                    b.ToTable("Mohammads");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Asp.DALL.Entites.PromationBook", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionBook")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("PriceBook")
                        .IsRequired()
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("promations");
                });

            modelBuilder.Entity("Asp.DALL.Entites.PromationReaserch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genderid")
                        .HasColumnType("int");

                    b.Property<int?>("ListBooksId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("listsid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Genderid");

                    b.HasIndex("ListBooksId");

                    b.ToTable("PromationReaserchs");
                });

            modelBuilder.Entity("Asp.DALL.Entites.ScientaficPromation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Extention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genderid")
                        .HasColumnType("int");

                    b.Property<int?>("ListBooksId")
                        .HasColumnType("int");

                    b.Property<string>("PromationDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PromationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("PromationRate")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<int>("listid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Genderid");

                    b.HasIndex("ListBooksId");

                    b.ToTable("scientaficPromationss");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Student", b =>
                {
                    b.Property<int>("Studentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Studentid"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Extentions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genderid")
                        .HasColumnType("int");

                    b.Property<int?>("ListBooksId")
                        .HasColumnType("int");

                    b.Property<int>("Listid")
                        .HasColumnType("int");

                    b.Property<int>("Studentage")
                        .HasColumnType("int");

                    b.Property<string>("Studentdescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Studentemail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Studentname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Studentphone")
                        .HasColumnType("int");

                    b.Property<string>("Studentposetion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Studentid");

                    b.HasIndex("Genderid");

                    b.HasIndex("ListBooksId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Extention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genderid")
                        .HasColumnType("int");

                    b.Property<int?>("ListBooksId")
                        .HasColumnType("int");

                    b.Property<int>("Listid")
                        .HasColumnType("int");

                    b.Property<string>("SurveyDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurveyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Genderid");

                    b.HasIndex("ListBooksId");

                    b.ToTable("surveys");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genderid")
                        .HasColumnType("int");

                    b.Property<int?>("ListBooksId")
                        .HasColumnType("int");

                    b.Property<int>("Listid")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Genderid");

                    b.HasIndex("ListBooksId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Employee", b =>
                {
                    b.HasOne("Asp.DALL.Entites.Gender", "Gender")
                        .WithMany("Employees")
                        .HasForeignKey("Genderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.DALL.Entites.ListBooks", "ListBooks")
                        .WithMany("Employees")
                        .HasForeignKey("ListBooksId");

                    b.Navigation("Gender");

                    b.Navigation("ListBooks");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Fileextention", b =>
                {
                    b.HasOne("Asp.DALL.Entites.Gender", "Gender")
                        .WithMany("Fileextentions")
                        .HasForeignKey("Genderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Languges", b =>
                {
                    b.HasOne("Asp.DALL.Entites.Gender", "Gender")
                        .WithMany("Languges")
                        .HasForeignKey("Genderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.DALL.Entites.ListBooks", "ListBooks")
                        .WithMany("Languges")
                        .HasForeignKey("ListBooksId");

                    b.Navigation("Gender");

                    b.Navigation("ListBooks");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Majales", b =>
                {
                    b.HasOne("Asp.DALL.Entites.Gender", "Gender")
                        .WithMany("Majaless")
                        .HasForeignKey("Genderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.DALL.Entites.ListBooks", "ListBooks")
                        .WithMany("Majaless")
                        .HasForeignKey("ListBooksId");

                    b.Navigation("Gender");

                    b.Navigation("ListBooks");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Mohammad", b =>
                {
                    b.HasOne("Asp.DALL.Entites.Gender", "Gender")
                        .WithMany("Mohammads")
                        .HasForeignKey("Genderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.DALL.Entites.ListBooks", "ListBooks")
                        .WithMany("Mohammads")
                        .HasForeignKey("ListBooksId");

                    b.Navigation("Gender");

                    b.Navigation("ListBooks");
                });

            modelBuilder.Entity("Asp.DALL.Entites.PromationReaserch", b =>
                {
                    b.HasOne("Asp.DALL.Entites.Gender", "Gender")
                        .WithMany("PromationReaserchs")
                        .HasForeignKey("Genderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.DALL.Entites.ListBooks", "ListBooks")
                        .WithMany("PromationReaserchs")
                        .HasForeignKey("ListBooksId");

                    b.Navigation("Gender");

                    b.Navigation("ListBooks");
                });

            modelBuilder.Entity("Asp.DALL.Entites.ScientaficPromation", b =>
                {
                    b.HasOne("Asp.DALL.Entites.Gender", "Gender")
                        .WithMany("scientaficPromations")
                        .HasForeignKey("Genderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.DALL.Entites.ListBooks", "ListBooks")
                        .WithMany("scientafics")
                        .HasForeignKey("ListBooksId");

                    b.Navigation("Gender");

                    b.Navigation("ListBooks");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Student", b =>
                {
                    b.HasOne("Asp.DALL.Entites.Gender", "Gender")
                        .WithMany("Students")
                        .HasForeignKey("Genderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.DALL.Entites.ListBooks", "ListBooks")
                        .WithMany("Students")
                        .HasForeignKey("ListBooksId");

                    b.Navigation("Gender");

                    b.Navigation("ListBooks");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Survey", b =>
                {
                    b.HasOne("Asp.DALL.Entites.Gender", "Gender")
                        .WithMany("surveys")
                        .HasForeignKey("Genderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.DALL.Entites.ListBooks", "ListBooks")
                        .WithMany("surveyss")
                        .HasForeignKey("ListBooksId");

                    b.Navigation("Gender");

                    b.Navigation("ListBooks");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Travel", b =>
                {
                    b.HasOne("Asp.DALL.Entites.Gender", "Gender")
                        .WithMany("Travels")
                        .HasForeignKey("Genderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.DALL.Entites.ListBooks", "ListBooks")
                        .WithMany("Travels")
                        .HasForeignKey("ListBooksId");

                    b.Navigation("Gender");

                    b.Navigation("ListBooks");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Gender", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Fileextentions");

                    b.Navigation("Languges");

                    b.Navigation("Majaless");

                    b.Navigation("Mohammads");

                    b.Navigation("PromationReaserchs");

                    b.Navigation("Students");

                    b.Navigation("Travels");

                    b.Navigation("scientaficPromations");

                    b.Navigation("surveys");
                });

            modelBuilder.Entity("Asp.DALL.Entites.ListBooks", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Languges");

                    b.Navigation("Majaless");

                    b.Navigation("Mohammads");

                    b.Navigation("PromationReaserchs");

                    b.Navigation("Students");

                    b.Navigation("Travels");

                    b.Navigation("scientafics");

                    b.Navigation("surveyss");
                });
#pragma warning restore 612, 618
        }
    }
}
