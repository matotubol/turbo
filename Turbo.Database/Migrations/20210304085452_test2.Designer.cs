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
    [Migration("20210304085452_test2")]
    partial class test2
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

                    b.Property<int>("FurnitureDefinitionEntityId")
                        .HasColumnType("int")
                        .HasColumnName("definition_id");

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

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomBanEntity", b =>
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

                    b.Property<int>("PlayerEntityId")
                        .HasColumnType("int")
                        .HasColumnName("player_id");

                    b.Property<int>("RoomEntityId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.HasKey("Id");

                    b.HasIndex("PlayerEntityId");

                    b.HasIndex("RoomEntityId");

                    b.ToTable("room_bans");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomEntity", b =>
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

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("name");

                    b.Property<int>("RoomModelEntityId")
                        .HasColumnType("int")
                        .HasColumnName("model_id");

                    b.HasKey("Id");

                    b.HasIndex("RoomModelEntityId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomModelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Custom")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("custom");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<int>("DoorDirection")
                        .HasColumnType("int")
                        .HasColumnName("door_direction");

                    b.Property<int>("DoorX")
                        .HasColumnType("int")
                        .HasColumnName("door_x");

                    b.Property<int>("DoorY")
                        .HasColumnType("int")
                        .HasColumnName("door_y");

                    b.Property<bool>("Enabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("enabled");

                    b.Property<string>("Model")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("model");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("room_models");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomMuteEntity", b =>
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

                    b.Property<int>("PlayerEntityId")
                        .HasColumnType("int")
                        .HasColumnName("player_id");

                    b.Property<int>("RoomEntityId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.HasKey("Id");

                    b.HasIndex("PlayerEntityId");

                    b.HasIndex("RoomEntityId");

                    b.ToTable("room_mutes");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomRightEntity", b =>
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

                    b.Property<int>("PlayerEntityId")
                        .HasColumnType("int")
                        .HasColumnName("player_id");

                    b.Property<int>("RoomEntityId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.HasKey("Id");

                    b.HasIndex("PlayerEntityId");

                    b.HasIndex("RoomEntityId");

                    b.ToTable("room_rights");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Security.SecurityTicketEntity", b =>
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

                    b.Property<string>("IpAddress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("ip_address");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_locked");

                    b.Property<int>("PlayerEntityId")
                        .HasColumnType("int")
                        .HasColumnName("player_id");

                    b.Property<string>("Ticket")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("ticket");

                    b.HasKey("Id");

                    b.HasIndex("PlayerEntityId");

                    b.ToTable("security_tickets");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Furniture.FurnitureEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Furniture.FurnitureDefinitionEntity", "FurnitureDefinitionEntity")
                        .WithMany("Furnitures")
                        .HasForeignKey("FurnitureDefinitionEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FurnitureDefinitionEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomBanEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Players.PlayerEntity", "PlayerEntity")
                        .WithMany()
                        .HasForeignKey("PlayerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turbo.Database.Entities.Room.RoomEntity", "RoomEntity")
                        .WithMany("RoomBans")
                        .HasForeignKey("RoomEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerEntity");

                    b.Navigation("RoomEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Room.RoomModelEntity", "RoomModelEntity")
                        .WithMany()
                        .HasForeignKey("RoomModelEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomModelEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomMuteEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Players.PlayerEntity", "PlayerEntity")
                        .WithMany()
                        .HasForeignKey("PlayerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turbo.Database.Entities.Room.RoomEntity", "RoomEntity")
                        .WithMany("RoomMutes")
                        .HasForeignKey("RoomEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerEntity");

                    b.Navigation("RoomEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomRightEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Players.PlayerEntity", "PlayerEntity")
                        .WithMany()
                        .HasForeignKey("PlayerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turbo.Database.Entities.Room.RoomEntity", "RoomEntity")
                        .WithMany("RoomRights")
                        .HasForeignKey("RoomEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerEntity");

                    b.Navigation("RoomEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Security.SecurityTicketEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Players.PlayerEntity", "PlayerEntity")
                        .WithMany("SecurityTickets")
                        .HasForeignKey("PlayerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Furniture.FurnitureDefinitionEntity", b =>
                {
                    b.Navigation("Furnitures");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Players.PlayerEntity", b =>
                {
                    b.Navigation("SecurityTickets");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomEntity", b =>
                {
                    b.Navigation("RoomBans");

                    b.Navigation("RoomMutes");

                    b.Navigation("RoomRights");
                });
#pragma warning restore 612, 618
        }
    }
}