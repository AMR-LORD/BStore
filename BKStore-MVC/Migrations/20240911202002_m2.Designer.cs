﻿// <auto-generated />
using System;
using BKStore_MVC.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BKStore_MVC.Migrations
{
    [DbContext(typeof(BKstore_System))]
    [Migration("20240911202002_m2")]
    partial class m2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BKStore_MVC.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Biography")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("AuthorId");

                    b.HasIndex("CountryID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"));

                    b.Property<int?>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PublisherID")
                        .HasColumnType("int");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<int?>("StockQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("BookID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("PublisherID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int?>("GovernorateID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GovernorateID");

                    b.HasIndex("UserID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Governorate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CountryID");

                    b.ToTable("Governorate");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<bool>("DelivaryStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TotalAmount")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("BKStore_MVC.Models.OrderBook", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TSubPrice")
                        .HasColumnType("int");

                    b.HasKey("OrderID", "BookID");

                    b.HasIndex("BookID");

                    b.ToTable("OrderBook");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Publisher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Shipping", b =>
                {
                    b.Property<int>("ShippingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShippingID"));

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShippingMethod")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TrackingNumber")
                        .HasColumnType("int");

                    b.HasKey("ShippingID");

                    b.HasIndex("OrderID")
                        .IsUnique()
                        .HasFilter("[OrderID] IS NOT NULL");

                    b.ToTable("Shipping");
                });

            modelBuilder.Entity("BKStore_MVC.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Author", b =>
                {
                    b.HasOne("BKStore_MVC.Models.Country", "Country")
                        .WithMany("author")
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Book", b =>
                {
                    b.HasOne("BKStore_MVC.Models.Author", "Author")
                        .WithMany("books")
                        .HasForeignKey("AuthorID");

                    b.HasOne("BKStore_MVC.Models.Category", "Category")
                        .WithMany("Book")
                        .HasForeignKey("CategoryID");

                    b.HasOne("BKStore_MVC.Models.Publisher", "Publisher")
                        .WithMany("books")
                        .HasForeignKey("PublisherID");

                    b.Navigation("Author");

                    b.Navigation("Category");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Customer", b =>
                {
                    b.HasOne("BKStore_MVC.Models.Governorate", null)
                        .WithMany("customers")
                        .HasForeignKey("GovernorateID");

                    b.HasOne("BKStore_MVC.Models.User", "User")
                        .WithMany("Customer")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Governorate", b =>
                {
                    b.HasOne("BKStore_MVC.Models.Country", "Country")
                        .WithMany("Governorate")
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Order", b =>
                {
                    b.HasOne("BKStore_MVC.Models.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerID");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BKStore_MVC.Models.OrderBook", b =>
                {
                    b.HasOne("BKStore_MVC.Models.Book", "Book")
                        .WithMany("orderDetails")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BKStore_MVC.Models.Order", "Order")
                        .WithMany("OrderBook")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Shipping", b =>
                {
                    b.HasOne("BKStore_MVC.Models.Order", "Order")
                        .WithOne("Shipping")
                        .HasForeignKey("BKStore_MVC.Models.Shipping", "OrderID");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Author", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Book", b =>
                {
                    b.Navigation("orderDetails");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Category", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Country", b =>
                {
                    b.Navigation("Governorate");

                    b.Navigation("author");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Customer", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Governorate", b =>
                {
                    b.Navigation("customers");
                });

            modelBuilder.Entity("BKStore_MVC.Models.Order", b =>
                {
                    b.Navigation("OrderBook");

                    b.Navigation("Shipping")
                        .IsRequired();
                });

            modelBuilder.Entity("BKStore_MVC.Models.Publisher", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("BKStore_MVC.Models.User", b =>
                {
                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
