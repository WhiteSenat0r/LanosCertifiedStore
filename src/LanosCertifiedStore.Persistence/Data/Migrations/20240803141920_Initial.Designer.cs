﻿// <auto-generated />
using System;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LanosCertifiedStore.Persistence.Data.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    [Migration("20240803141920_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.UserRelated.Permission", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Code");

                    b.ToTable("Permissions", "identity");

                    b.HasData(
                        new
                        {
                            Code = "users:read"
                        },
                        new
                        {
                            Code = "users:list"
                        },
                        new
                        {
                            Code = "users:create"
                        },
                        new
                        {
                            Code = "users:update"
                        },
                        new
                        {
                            Code = "users:change-role"
                        },
                        new
                        {
                            Code = "vehicles:create"
                        },
                        new
                        {
                            Code = "vehicles:update"
                        },
                        new
                        {
                            Code = "vehicles:delete"
                        },
                        new
                        {
                            Code = "brands:create"
                        },
                        new
                        {
                            Code = "brands:update"
                        },
                        new
                        {
                            Code = "models:create"
                        },
                        new
                        {
                            Code = "models:update"
                        });
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.UserRelated.RolePermission", b =>
                {
                    b.Property<string>("PermissionCode")
                        .HasColumnType("character varying(64)");

                    b.Property<string>("UserRoleName")
                        .HasColumnType("character varying(64)");

                    b.HasKey("PermissionCode", "UserRoleName");

                    b.HasIndex("UserRoleName");

                    b.ToTable("RolePermissions", "identity");

                    b.HasData(
                        new
                        {
                            PermissionCode = "users:read",
                            UserRoleName = "User"
                        },
                        new
                        {
                            PermissionCode = "vehicles:create",
                            UserRoleName = "User"
                        },
                        new
                        {
                            PermissionCode = "users:read",
                            UserRoleName = "Manager"
                        },
                        new
                        {
                            PermissionCode = "users:list",
                            UserRoleName = "Manager"
                        },
                        new
                        {
                            PermissionCode = "users:create",
                            UserRoleName = "Manager"
                        },
                        new
                        {
                            PermissionCode = "users:update",
                            UserRoleName = "Manager"
                        },
                        new
                        {
                            PermissionCode = "vehicles:create",
                            UserRoleName = "Manager"
                        },
                        new
                        {
                            PermissionCode = "vehicles:update",
                            UserRoleName = "Manager"
                        },
                        new
                        {
                            PermissionCode = "brands:create",
                            UserRoleName = "Manager"
                        },
                        new
                        {
                            PermissionCode = "brands:update",
                            UserRoleName = "Manager"
                        },
                        new
                        {
                            PermissionCode = "models:create",
                            UserRoleName = "Manager"
                        },
                        new
                        {
                            PermissionCode = "models:update",
                            UserRoleName = "Manager"
                        },
                        new
                        {
                            PermissionCode = "users:read",
                            UserRoleName = "Administrator"
                        },
                        new
                        {
                            PermissionCode = "users:list",
                            UserRoleName = "Administrator"
                        },
                        new
                        {
                            PermissionCode = "users:create",
                            UserRoleName = "Administrator"
                        },
                        new
                        {
                            PermissionCode = "users:update",
                            UserRoleName = "Administrator"
                        },
                        new
                        {
                            PermissionCode = "users:change-role",
                            UserRoleName = "Administrator"
                        },
                        new
                        {
                            PermissionCode = "vehicles:create",
                            UserRoleName = "Administrator"
                        },
                        new
                        {
                            PermissionCode = "vehicles:update",
                            UserRoleName = "Administrator"
                        },
                        new
                        {
                            PermissionCode = "brands:create",
                            UserRoleName = "Administrator"
                        },
                        new
                        {
                            PermissionCode = "brands:update",
                            UserRoleName = "Administrator"
                        },
                        new
                        {
                            PermissionCode = "models:create",
                            UserRoleName = "Administrator"
                        },
                        new
                        {
                            PermissionCode = "models:update",
                            UserRoleName = "Administrator"
                        });
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.UserRelated.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("UserRoleName")
                        .IsRequired()
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleName");

                    b.ToTable("Users", "identity");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.UserRelated.UserRole", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Name");

                    b.ToTable("UserRoles", "identity");

                    b.HasData(
                        new
                        {
                            Name = "User"
                        },
                        new
                        {
                            Name = "Manager"
                        },
                        new
                        {
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationArea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocationRegionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("LocationRegionId");

                    b.HasIndex("Name");

                    b.ToTable("VehicleLocationAreas", "locations");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationRegion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("VehicleLocationRegions", "locations");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationTown", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocationAreaId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocationRegionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocationTownTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("LocationAreaId");

                    b.HasIndex("LocationRegionId");

                    b.HasIndex("LocationTownTypeId");

                    b.ToTable("VehicleLocationTowns", "locations");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationTownType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("VehicleLocationTownTypes", "locations");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleBodyType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("VehicleBodyTypes", "vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleDrivetrainType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("VehicleDrivetrainTypes", "vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleEngineType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("VehicleEngineTypes", "vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleTransmissionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("VehicleTransmissionTypes", "vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("VehicleTypes", "vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BodyTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ColorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<double>("Displacement")
                        .HasColumnType("double precision");

                    b.Property<Guid>("DrivetrainTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EngineTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocationTownId")
                        .HasColumnType("uuid");

                    b.Property<int>("Mileage")
                        .HasColumnType("integer");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("integer");

                    b.Property<Guid>("TransmissionTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VehicleTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BodyTypeId");

                    b.HasIndex("BrandId");

                    b.HasIndex("ColorId");

                    b.HasIndex("DrivetrainTypeId");

                    b.HasIndex("EngineTypeId");

                    b.HasIndex("LocationTownId");

                    b.HasIndex("ModelId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TransmissionTypeId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicles", "vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleBrand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("VehicleBrands", "vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleColor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("HexValue")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("VehicleColors", "vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CloudImageId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsMainImage")
                        .HasColumnType("boolean");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleImages", "vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("MaximumProductionYear")
                        .HasColumnType("integer");

                    b.Property<int>("MinimalProductionYear")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<Guid>("VehicleBrandId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VehicleTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VehicleBrandId");

                    b.HasIndex("VehicleTypeId");

                    b.HasIndex("Name", "VehicleBrandId")
                        .IsUnique();

                    b.ToTable("VehicleModels", "vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehiclePrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehiclePrices", "vehicles");
                });

            modelBuilder.Entity("VehicleBodyTypeVehicleModel", b =>
                {
                    b.Property<Guid>("AvailableBodyTypesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModelsId")
                        .HasColumnType("uuid");

                    b.HasKey("AvailableBodyTypesId", "ModelsId");

                    b.HasIndex("ModelsId");

                    b.ToTable("VehicleBodyTypesVehicleModels", "vehicles");
                });

            modelBuilder.Entity("VehicleDrivetrainTypeVehicleModel", b =>
                {
                    b.Property<Guid>("AvailableDrivetrainTypesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModelsId")
                        .HasColumnType("uuid");

                    b.HasKey("AvailableDrivetrainTypesId", "ModelsId");

                    b.HasIndex("ModelsId");

                    b.ToTable("VehicleDrivetrainTypesVehicleModels", "vehicles");
                });

            modelBuilder.Entity("VehicleEngineTypeVehicleModel", b =>
                {
                    b.Property<Guid>("AvailableEngineTypesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModelsId")
                        .HasColumnType("uuid");

                    b.HasKey("AvailableEngineTypesId", "ModelsId");

                    b.HasIndex("ModelsId");

                    b.ToTable("VehicleEngineTypesVehicleModels", "vehicles");
                });

            modelBuilder.Entity("VehicleModelVehicleTransmissionType", b =>
                {
                    b.Property<Guid>("AvailableTransmissionTypesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModelsId")
                        .HasColumnType("uuid");

                    b.HasKey("AvailableTransmissionTypesId", "ModelsId");

                    b.HasIndex("ModelsId");

                    b.ToTable("VehicleTransmissionTypesVehicleModels", "vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.UserRelated.RolePermission", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.UserRelated.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.UserRelated.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.UserRelated.User", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.UserRelated.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationArea", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationRegion", "LocationRegion")
                        .WithMany("RelatedAreas")
                        .HasForeignKey("LocationRegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocationRegion");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationTown", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationArea", "LocationArea")
                        .WithMany("RelatedTowns")
                        .HasForeignKey("LocationAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationRegion", "LocationRegion")
                        .WithMany("RelatedTowns")
                        .HasForeignKey("LocationRegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationTownType", "LocationTownType")
                        .WithMany("Towns")
                        .HasForeignKey("LocationTownTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocationArea");

                    b.Navigation("LocationRegion");

                    b.Navigation("LocationTownType");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.Vehicle", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleBodyType", "BodyType")
                        .WithMany("Vehicles")
                        .HasForeignKey("BodyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleBrand", "Brand")
                        .WithMany("Vehicles")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleColor", "Color")
                        .WithMany("Vehicles")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleDrivetrainType", "DrivetrainType")
                        .WithMany("Vehicles")
                        .HasForeignKey("DrivetrainTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleEngineType", "EngineType")
                        .WithMany("Vehicles")
                        .HasForeignKey("EngineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationTown", "LocationTown")
                        .WithMany()
                        .HasForeignKey("LocationTownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleModel", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.UserRelated.User", "Owner")
                        .WithMany("Vehicles")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleTransmissionType", "TransmissionType")
                        .WithMany("Vehicles")
                        .HasForeignKey("TransmissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BodyType");

                    b.Navigation("Brand");

                    b.Navigation("Color");

                    b.Navigation("DrivetrainType");

                    b.Navigation("EngineType");

                    b.Navigation("LocationTown");

                    b.Navigation("Model");

                    b.Navigation("Owner");

                    b.Navigation("TransmissionType");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleImage", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.Vehicle", "Vehicle")
                        .WithMany("Images")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleModel", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleBrand", "VehicleBrand")
                        .WithMany("Models")
                        .HasForeignKey("VehicleBrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleType", "VehicleType")
                        .WithMany("Models")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleBrand");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehiclePrice", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.Vehicle", "Vehicle")
                        .WithMany("Prices")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehicleBodyTypeVehicleModel", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleBodyType", null)
                        .WithMany()
                        .HasForeignKey("AvailableBodyTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleModel", null)
                        .WithMany()
                        .HasForeignKey("ModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VehicleDrivetrainTypeVehicleModel", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleDrivetrainType", null)
                        .WithMany()
                        .HasForeignKey("AvailableDrivetrainTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleModel", null)
                        .WithMany()
                        .HasForeignKey("ModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VehicleEngineTypeVehicleModel", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleEngineType", null)
                        .WithMany()
                        .HasForeignKey("AvailableEngineTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleModel", null)
                        .WithMany()
                        .HasForeignKey("ModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VehicleModelVehicleTransmissionType", b =>
                {
                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleTransmissionType", null)
                        .WithMany()
                        .HasForeignKey("AvailableTransmissionTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleModel", null)
                        .WithMany()
                        .HasForeignKey("ModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.UserRelated.User", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.UserRelated.UserRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationArea", b =>
                {
                    b.Navigation("RelatedTowns");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationRegion", b =>
                {
                    b.Navigation("RelatedAreas");

                    b.Navigation("RelatedTowns");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated.VehicleLocationTownType", b =>
                {
                    b.Navigation("Towns");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleBodyType", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleDrivetrainType", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleEngineType", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleTransmissionType", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated.VehicleType", b =>
                {
                    b.Navigation("Models");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.Vehicle", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleBrand", b =>
                {
                    b.Navigation("Models");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleColor", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("LanosCertifiedStore.Domain.Entities.VehicleRelated.VehicleModel", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}