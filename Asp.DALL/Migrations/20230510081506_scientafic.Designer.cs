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
    [Migration("20230510081506_scientafic")]
    partial class scientafic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<string>("PromationDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PromationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("PromationRate")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<int?>("listBooksId")
                        .HasColumnType("int");

                    b.Property<int>("listid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Genderid");

                    b.HasIndex("listBooksId");

                    b.ToTable("scientaficPromationss");
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

            modelBuilder.Entity("Asp.DALL.Entites.ScientaficPromation", b =>
                {
                    b.HasOne("Asp.DALL.Entites.Gender", "Gender")
                        .WithMany("scientaficPromations")
                        .HasForeignKey("Genderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.DALL.Entites.ListBooks", "listBooks")
                        .WithMany("scientafics")
                        .HasForeignKey("listBooksId");

                    b.Navigation("Gender");

                    b.Navigation("listBooks");
                });

            modelBuilder.Entity("Asp.DALL.Entites.Gender", b =>
                {
                    b.Navigation("Fileextentions");

                    b.Navigation("scientaficPromations");
                });

            modelBuilder.Entity("Asp.DALL.Entites.ListBooks", b =>
                {
                    b.Navigation("scientafics");
                });
#pragma warning restore 612, 618
        }
    }
}
