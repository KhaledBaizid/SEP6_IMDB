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
    [Migration("20231130181443_rating")]
#pragma warning disable CS8981
    partial class rating
#pragma warning restore CS8981
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shared.Director", b =>
                {
                    b.Property<long?>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.HasKey("MovieId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Shared.Favourite", b =>
                {
                    b.Property<long?>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("Shared.Movie", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Year")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Shared.Person", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<decimal?>("Birth")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Shared.Rating", b =>
                {
                    b.Property<long?>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<double?>("RatingValue")
                        .HasColumnType("double precision");

                    b.Property<long?>("Votes")
                        .HasColumnType("bigint");

                    b.HasKey("MovieId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Shared.Star", b =>
                {
                    b.Property<long?>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.HasKey("MovieId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("Shared.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Shared.UserRating", b =>
                {
                    b.Property<long?>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<float?>("RatingValue")
                        .HasColumnType("real");

                    b.Property<float?>("vote")
                        .HasColumnType("real");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRatings");
                });

            modelBuilder.Entity("Shared.Director", b =>
                {
                    b.HasOne("Shared.Movie", "Movie")
                        .WithMany("Directors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Person", "Person")
                        .WithMany("DirectedMovies")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Shared.Favourite", b =>
                {
                    b.HasOne("Shared.Movie", "Movie")
                        .WithMany("Favourites")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.User", "User")
                        .WithMany("Favourites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Rating", b =>
                {
                    b.HasOne("Shared.Movie", "Movie")
                        .WithOne("Rating")
                        .HasForeignKey("Shared.Rating", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Shared.Star", b =>
                {
                    b.HasOne("Shared.Movie", "Movie")
                        .WithMany("Stars")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Person", "Person")
                        .WithMany("StarredMovies")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Shared.UserRating", b =>
                {
                    b.HasOne("Shared.Movie", "Movie")
                        .WithMany("UserRatings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.User", "User")
                        .WithMany("UserRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Movie", b =>
                {
                    b.Navigation("Directors");

                    b.Navigation("Favourites");

                    b.Navigation("Rating");

                    b.Navigation("Stars");

                    b.Navigation("UserRatings");
                });

            modelBuilder.Entity("Shared.Person", b =>
                {
                    b.Navigation("DirectedMovies");

                    b.Navigation("StarredMovies");
                });

            modelBuilder.Entity("Shared.User", b =>
                {
                    b.Navigation("Favourites");

                    b.Navigation("UserRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
