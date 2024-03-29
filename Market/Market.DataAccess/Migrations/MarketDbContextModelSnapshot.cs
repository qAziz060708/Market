﻿// <auto-generated />
using System;
using Market.DataAccess.DbConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Market.DataAccess.Migrations
{
    [DbContext(typeof(MarketDbContext))]
    partial class MarketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Market.DataAccess.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CategoryType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Market.DataAccess.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactAdd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Market.DataAccess.Models.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DeliveryId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DeliveryId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("Market.DataAccess.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentId"));

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Market.DataAccess.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ShoppingOrdersAndProductsId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Market.DataAccess.Models.Seller", b =>
                {
                    b.Property<int>("SellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SellerId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SellerId");

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("Market.DataAccess.Models.ShoppingOrder", b =>
                {
                    b.Property<int>("ShoppingOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ShoppingOrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ShoppingDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ShoppingOrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentId")
                        .IsUnique();

                    b.ToTable("ShoppingOrders");
                });

            modelBuilder.Entity("Market.DataAccess.Models.ShoppingOrdersAndProducts", b =>
                {
                    b.Property<int>("ShoppingOrdersAndProductsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ShoppingOrdersAndProductsId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("ShoppingOrderId")
                        .HasColumnType("integer");

                    b.HasKey("ShoppingOrdersAndProductsId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingOrderId");

                    b.ToTable("ShoppingOrdersAndProducts");
                });

            modelBuilder.Entity("Market.DataAccess.Models.TransactionReport", b =>
                {
                    b.Property<int>("TransactionReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TransactionReportId"));

                    b.Property<int>("ShoppingOrderId")
                        .HasColumnType("integer");

                    b.HasKey("TransactionReportId");

                    b.HasIndex("ShoppingOrderId")
                        .IsUnique();

                    b.ToTable("TransactionReports");
                });

            modelBuilder.Entity("Market.DataAccess.Models.Delivery", b =>
                {
                    b.HasOne("Market.DataAccess.Models.Customer", "Customer")
                        .WithMany("Deliveries")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Market.DataAccess.Models.Product", b =>
                {
                    b.HasOne("Market.DataAccess.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Market.DataAccess.Models.Seller", b =>
                {
                    b.HasOne("Market.DataAccess.Models.Category", "Category")
                        .WithOne("Seller")
                        .HasForeignKey("Market.DataAccess.Models.Seller", "CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Market.DataAccess.Models.ShoppingOrder", b =>
                {
                    b.HasOne("Market.DataAccess.Models.Customer", "Customer")
                        .WithMany("ShoppingOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Market.DataAccess.Models.Payment", "Payment")
                        .WithOne("ShoppingOrder")
                        .HasForeignKey("Market.DataAccess.Models.ShoppingOrder", "PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Market.DataAccess.Models.ShoppingOrdersAndProducts", b =>
                {
                    b.HasOne("Market.DataAccess.Models.Product", "Product")
                        .WithMany("ShoppingOrdersAndProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Market.DataAccess.Models.ShoppingOrder", "ShoppingOrder")
                        .WithMany("ShoppingOrdersAndProducts")
                        .HasForeignKey("ShoppingOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingOrder");
                });

            modelBuilder.Entity("Market.DataAccess.Models.TransactionReport", b =>
                {
                    b.HasOne("Market.DataAccess.Models.ShoppingOrder", "ShoppingOrder")
                        .WithOne("TransactionReport")
                        .HasForeignKey("Market.DataAccess.Models.TransactionReport", "ShoppingOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingOrder");
                });

            modelBuilder.Entity("Market.DataAccess.Models.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Seller")
                        .IsRequired();
                });

            modelBuilder.Entity("Market.DataAccess.Models.Customer", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("ShoppingOrders");
                });

            modelBuilder.Entity("Market.DataAccess.Models.Payment", b =>
                {
                    b.Navigation("ShoppingOrder")
                        .IsRequired();
                });

            modelBuilder.Entity("Market.DataAccess.Models.Product", b =>
                {
                    b.Navigation("ShoppingOrdersAndProducts");
                });

            modelBuilder.Entity("Market.DataAccess.Models.ShoppingOrder", b =>
                {
                    b.Navigation("ShoppingOrdersAndProducts");

                    b.Navigation("TransactionReport")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
