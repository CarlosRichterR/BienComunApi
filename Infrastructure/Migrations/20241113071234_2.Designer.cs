﻿// <auto-generated />
using System;
using BIenComun.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BienComun.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241113071234_2")]
    partial class _2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BienComun.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 11, 10, 20, 0, 0, 0, DateTimeKind.Utc),
                            Email = "testuser@example.com",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "password123",
                            Username = "TestUser"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 11, 10, 20, 15, 0, 0, DateTimeKind.Utc),
                            Email = "janedoe@example.com",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "password456",
                            Username = "JaneDoe"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 11, 10, 20, 30, 0, 0, DateTimeKind.Utc),
                            Email = "johnsmith@example.com",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "password789",
                            Username = "JohnSmith"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}