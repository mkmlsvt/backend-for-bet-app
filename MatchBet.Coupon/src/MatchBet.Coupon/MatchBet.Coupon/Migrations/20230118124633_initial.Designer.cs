﻿// <auto-generated />
using MatchBet.Coupon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MatchBet.Coupon.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230118124633_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MatchBet.Coupon.Models.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("isActive");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("ownerId");

                    b.Property<bool>("Result")
                        .HasColumnType("boolean")
                        .HasColumnName("result");

                    b.Property<double>("TotalRate")
                        .HasColumnType("double precision")
                        .HasColumnName("totalRate");

                    b.HasKey("Id");

                    b.ToTable("coupons", (string)null);
                });

            modelBuilder.Entity("MatchBet.Coupon.Models.MatchPredict", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CouponId")
                        .HasColumnType("integer")
                        .HasColumnName("couponId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("isActive");

                    b.Property<string>("MatchId")
                        .HasColumnType("text")
                        .HasColumnName("matchId");

                    b.Property<int>("Prediction")
                        .HasColumnType("integer")
                        .HasColumnName("prediction");

                    b.Property<float>("Rate")
                        .HasColumnType("real")
                        .HasColumnName("rate");

                    b.Property<bool>("Result")
                        .HasColumnType("boolean")
                        .HasColumnName("result");

                    b.HasKey("Id");

                    b.HasIndex("CouponId");

                    b.ToTable("matchPredicts", (string)null);
                });

            modelBuilder.Entity("MatchBet.Coupon.Models.MatchPredict", b =>
                {
                    b.HasOne("MatchBet.Coupon.Models.Coupon", "Coupon")
                        .WithMany("MatchPredicts")
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coupon");
                });

            modelBuilder.Entity("MatchBet.Coupon.Models.Coupon", b =>
                {
                    b.Navigation("MatchPredicts");
                });
#pragma warning restore 612, 618
        }
    }
}
