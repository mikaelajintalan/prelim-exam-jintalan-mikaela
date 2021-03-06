﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prelim_exam_jintalan_mikaela.Models;

namespace prelim_exam_jintalan_mikaela.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20201105080608_[addDirector]")]
    partial class addDirector
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                 .HasAnnotation("ProductVersion", "3.1.8")
                 .HasAnnotation("Relational:MaxIdentifierLength", 128)
                 .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("prelim_exam_jintalan_mikaela.Models.Director", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("id");

                b.ToTable("Directors");
            });

            modelBuilder.Entity("prelim_exam_jintalan_mikaela.Models.Movie", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int?>("DirectorID")
                    .HasColumnType("int");

                b.Property<string>("Genre")
                    .IsRequired()
                    .HasColumnType("nvarchar(30)")
                    .HasMaxLength(30);

                b.Property<decimal>("Price")
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("Rating")
                    .IsRequired()
                    .HasColumnType("nvarchar(5)")
                    .HasMaxLength(5);

                b.Property<DateTime>("ReleaseDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnType("nvarchar(60)")
                    .HasMaxLength(60);

                b.HasKey("id");

                b.HasIndex("DirectorID");

                b.ToTable("Movies");
            });

            modelBuilder.Entity("prelim_exam_jintalan_mikaela.Models.Movie", b =>
            {
                b.HasOne("prelim_exam_jintalan_mikaela.Models.Director", "Director")
                    .WithMany("Movies")
                    .HasForeignKey("DirectorID");
            });
#pragma warning restore 612, 618
        }
    }
}
