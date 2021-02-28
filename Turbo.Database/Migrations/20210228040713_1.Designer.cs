﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Turbo.Database.Context;

namespace Turbo.Database.Migrations
{
    [DbContext(typeof(TurboContext))]
    [Migration("20210228040713_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Turbo.Database.Entities.Furniture.FurnitureDefinitionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("CanGroup")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_group");

                    b.Property<bool>("CanLay")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_lay");

                    b.Property<bool>("CanRecycle")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_recycle");

                    b.Property<bool>("CanSell")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_sell");

                    b.Property<bool>("CanSit")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_sit");

                    b.Property<bool>("CanStack")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_stack");

                    b.Property<bool>("CanTrade")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_trade");

                    b.Property<bool>("CanWalk")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_walk");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<bool>("ExtraData")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("extra_data");

                    b.Property<string>("Logic")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("logic");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("product_name");

                    b.Property<string>("PublicName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("public_name");

                    b.Property<int>("SpriteId")
                        .HasColumnType("int")
                        .HasColumnName("sprite_id");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("type");

                    b.Property<int>("X")
                        .HasColumnType("int")
                        .HasColumnName("x");

                    b.Property<int>("Y")
                        .HasColumnType("int")
                        .HasColumnName("y");

                    b.Property<double>("Z")
                        .HasColumnType("double")
                        .HasColumnName("z");

                    b.HasKey("Id");

                    b.ToTable("furniture_definitions");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Furniture.FurnitureEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<int?>("FurnitureDefinitionEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FurnitureDefinitionEntityId");

                    b.ToTable("furniture");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Players.PlayerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<string>("Motto")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("motto");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("players");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Furniture.FurnitureEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Furniture.FurnitureDefinitionEntity", "FurnitureDefinitionEntity")
                        .WithMany()
                        .HasForeignKey("FurnitureDefinitionEntityId");

                    b.Navigation("FurnitureDefinitionEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
