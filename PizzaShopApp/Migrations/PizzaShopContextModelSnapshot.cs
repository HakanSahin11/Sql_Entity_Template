﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaShopApp.Models;

#nullable disable

namespace PizzaShopApp.Migrations
{
    [DbContext(typeof(PizzaShopContext))]
    partial class PizzaShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("PizzaShopApp.Models.CustomersModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("PizzaShopApp.Models.OrderlineModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PizzaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("Orderline");
                });

            modelBuilder.Entity("PizzaShopApp.Models.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time_Of_Order")
                        .HasColumnType("TEXT");

                    b.Property<int>("Total_Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PizzaShopApp.Models.PizzaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ingredient_1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ingredient_2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ingredient_3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ingredient_4")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pizza_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("pizza");
                });

            modelBuilder.Entity("PizzaShopApp.Models.OrderlineModel", b =>
                {
                    b.HasOne("PizzaShopApp.Models.OrderModel", "Order")
                        .WithMany("orderlines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaShopApp.Models.PizzaModel", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaShopApp.Models.OrderModel", b =>
                {
                    b.HasOne("PizzaShopApp.Models.CustomersModel", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PizzaShopApp.Models.CustomersModel", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("PizzaShopApp.Models.OrderModel", b =>
                {
                    b.Navigation("orderlines");
                });
#pragma warning restore 612, 618
        }
    }
}
