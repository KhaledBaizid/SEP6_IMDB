﻿// <auto-generated />
using System;
using Backend.EFCData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231126164718_db1")]
    partial class db1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shared.Directors", b =>
                {
                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Shared.Movie", b =>
                {
                    b.Property<int>("m_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("m_id"));

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("year")
                        .HasColumnType("integer");

                    b.HasKey("m_id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Shared.People", b =>
                {
                    b.Property<int>("p_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("p_id"));

                    b.Property<int?>("Moviem_id")
                        .HasColumnType("integer");

                    b.Property<int?>("Moviem_id1")
                        .HasColumnType("integer");

                    b.Property<int>("birth")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("p_id");

                    b.HasIndex("Moviem_id");

                    b.HasIndex("Moviem_id1");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("Shared.Rating", b =>
                {
                    b.Property<int>("moviem_id")
                        .HasColumnType("integer");

                    b.Property<float>("rating")
                        .HasColumnType("real");

                    b.Property<int>("votes")
                        .HasColumnType("integer");

                    b.HasIndex("moviem_id");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Shared.Stars", b =>
                {
                    b.ToTable("Stars");
                });

            modelBuilder.Entity("Shared.User", b =>
                {
                    b.Property<int>("u_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("u_id"));

                    b.Property<int?>("Moviem_id")
                        .HasColumnType("integer");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("u_id");

                    b.HasIndex("Moviem_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Shared.UserRating", b =>
                {
                    b.Property<float>("user_rating")
                        .HasColumnType("real");

                    b.ToTable("UserRatings");
                });

            modelBuilder.Entity("Shared.People", b =>
                {
                    b.HasOne("Shared.Movie", null)
                        .WithMany("Directors")
                        .HasForeignKey("Moviem_id");

                    b.HasOne("Shared.Movie", null)
                        .WithMany("Stars")
                        .HasForeignKey("Moviem_id1");
                });

            modelBuilder.Entity("Shared.Rating", b =>
                {
                    b.HasOne("Shared.Movie", "movie")
                        .WithMany()
                        .HasForeignKey("moviem_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movie");
                });

            modelBuilder.Entity("Shared.User", b =>
                {
                    b.HasOne("Shared.Movie", null)
                        .WithMany("Users")
                        .HasForeignKey("Moviem_id");
                });

            modelBuilder.Entity("Shared.Movie", b =>
                {
                    b.Navigation("Directors");

                    b.Navigation("Stars");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
