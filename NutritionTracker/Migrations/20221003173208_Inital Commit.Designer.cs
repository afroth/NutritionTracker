﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutritionTracker.Data;

namespace NutritionTracker.Migrations
{
    [DbContext(typeof(IngredientDbContext))]
    [Migration("20221003173208_Inital Commit")]
    partial class InitalCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25");

            modelBuilder.Entity("NutritionTracker.Models.Ingredient", b =>
                {
                    b.Property<string>("ingredientName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("calories")
                        .HasColumnType("INTEGER");

                    b.Property<int>("carbs")
                        .HasColumnType("INTEGER");

                    b.Property<int>("fats")
                        .HasColumnType("INTEGER");

                    b.Property<int>("protein")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sugar")
                        .HasColumnType("INTEGER");

                    b.HasKey("ingredientName");

                    b.ToTable("Ingredient");

                    b.HasData(
                        new
                        {
                            ingredientName = "Eggs",
                            calories = 90,
                            carbs = 0,
                            fats = 10,
                            protein = 20,
                            sugar = 0
                        },
                        new
                        {
                            ingredientName = "Tuna Fish",
                            calories = 60,
                            carbs = 0,
                            fats = 0,
                            protein = 36,
                            sugar = 0
                        },
                        new
                        {
                            ingredientName = "Oat Meal",
                            calories = 120,
                            carbs = 45,
                            fats = 5,
                            protein = 8,
                            sugar = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
