﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weekly_Shopping.Data;

#nullable disable

namespace Weekly_Shopping.Migrations
{
    [DbContext(typeof(MealPlannerContext))]
    [Migration("20240707194158_shoppingListIngredients")]
    partial class shoppingListIngredients
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BradleyHouse.Data.Models.MealPrep.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("BradleyHouse.Data.Models.MealPrep.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int?>("MealId")
                        .HasColumnType("int");

                    b.Property<string>("Measurement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("MealId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("BradleyHouse.Data.Models.MealPrep.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfServings")
                        .HasColumnType("int");

                    b.Property<int>("StockCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("BradleyHouse.Data.Models.MealPrep.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ShoppingList");
                });

            modelBuilder.Entity("BradleyHouse.Data.Models.MealPrep.ShoppingListIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<bool>("Picked")
                        .HasColumnType("bit");

                    b.Property<int?>("ShoppingListMealId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("ShoppingListMealId");

                    b.ToTable("ShoppingListIngredient");
                });

            modelBuilder.Entity("BradleyHouse.Data.Models.MealPrep.ShoppingListMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ShoppingListMeal");
                });

            modelBuilder.Entity("ShoppingListShoppingListMeal", b =>
                {
                    b.Property<int>("MealsId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingListId")
                        .HasColumnType("int");

                    b.HasKey("MealsId", "ShoppingListId");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("ShoppingListShoppingListMeal");
                });

            modelBuilder.Entity("BradleyHouse.Data.Models.MealPrep.Ingredient", b =>
                {
                    b.HasOne("BradleyHouse.Data.Models.MealPrep.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BradleyHouse.Data.Models.MealPrep.Meal", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("MealId");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("BradleyHouse.Data.Models.MealPrep.ShoppingListIngredient", b =>
                {
                    b.HasOne("BradleyHouse.Data.Models.MealPrep.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BradleyHouse.Data.Models.MealPrep.ShoppingListMeal", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("ShoppingListMealId");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("ShoppingListShoppingListMeal", b =>
                {
                    b.HasOne("BradleyHouse.Data.Models.MealPrep.ShoppingListMeal", null)
                        .WithMany()
                        .HasForeignKey("MealsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BradleyHouse.Data.Models.MealPrep.ShoppingList", null)
                        .WithMany()
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BradleyHouse.Data.Models.MealPrep.Meal", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("BradleyHouse.Data.Models.MealPrep.ShoppingListMeal", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
