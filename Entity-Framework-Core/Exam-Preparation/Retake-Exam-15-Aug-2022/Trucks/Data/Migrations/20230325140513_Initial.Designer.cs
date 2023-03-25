﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trucks.Data;

#nullable disable

namespace Trucks.Migrations
{
    [DbContext(typeof(TrucksContext))]
    [Migration("20230325140513_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Trucks.Data.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Trucks.Data.Models.ClientTruck", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("ClientId", "TruckId");

                    b.HasIndex("TruckId");

                    b.ToTable("ClientsTrucks");
                });

            modelBuilder.Entity("Trucks.Data.Models.Despatcher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Despatchers");
                });

            modelBuilder.Entity("Trucks.Data.Models.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CargoCapacity")
                        .HasColumnType("int");

                    b.Property<int>("CategoryType")
                        .HasColumnType("int");

                    b.Property<int>("DespatcherId")
                        .HasColumnType("int");

                    b.Property<int>("MakeType")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TankCapacity")
                        .HasColumnType("int");

                    b.Property<string>("VinNumber")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.HasKey("Id");

                    b.HasIndex("DespatcherId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("Trucks.Data.Models.ClientTruck", b =>
                {
                    b.HasOne("Trucks.Data.Models.Client", "Client")
                        .WithMany("ClientsTrucks")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trucks.Data.Models.Truck", "Truck")
                        .WithMany("ClientsTrucks")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("Trucks.Data.Models.Truck", b =>
                {
                    b.HasOne("Trucks.Data.Models.Despatcher", "Despatcher")
                        .WithMany("Trucks")
                        .HasForeignKey("DespatcherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Despatcher");
                });

            modelBuilder.Entity("Trucks.Data.Models.Client", b =>
                {
                    b.Navigation("ClientsTrucks");
                });

            modelBuilder.Entity("Trucks.Data.Models.Despatcher", b =>
                {
                    b.Navigation("Trucks");
                });

            modelBuilder.Entity("Trucks.Data.Models.Truck", b =>
                {
                    b.Navigation("ClientsTrucks");
                });
#pragma warning restore 612, 618
        }
    }
}
