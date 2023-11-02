﻿// <auto-generated />
using FoldersApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoldersApp.Data.Migrations
{
    [DbContext(typeof(FolderDataContext))]
    [Migration("20231031123750_FolderLinksFix")]
    partial class FolderLinksFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FoldersApp.Data.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PreviousFolderId")
                        .HasColumnType("integer");

                    b.Property<int[]>("SubFolders")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.HasKey("Id");

                    b.HasIndex("PreviousFolderId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("FoldersApp.Data.Folder", b =>
                {
                    b.HasOne("FoldersApp.Data.Folder", "PreviousFolder")
                        .WithMany()
                        .HasForeignKey("PreviousFolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreviousFolder");
                });
#pragma warning restore 612, 618
        }
    }
}
