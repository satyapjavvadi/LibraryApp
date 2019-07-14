﻿// <auto-generated />
using System;
using LibraryApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryApp.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20190714180159_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryApp.Account", b =>
                {
                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AccountCreated");

                    b.Property<int>("AccountType");

                    b.Property<int>("CheckedoutBooksCount");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("AccountNumber")
                        .HasName("PK_Accounts");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("LibraryApp.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountNumber");

                    b.Property<DateTime>("ActivityDate");

                    b.Property<int>("ActivityType");

                    b.Property<int>("BookCount");

                    b.Property<string>("Description");

                    b.HasKey("ActivityId")
                        .HasName("PK_Activities");

                    b.HasIndex("AccountNumber");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("LibraryApp.Activity", b =>
                {
                    b.HasOne("LibraryApp.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
