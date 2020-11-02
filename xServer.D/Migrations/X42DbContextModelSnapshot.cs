﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using x42.Feature.Database.Context;

namespace x42.Migrations
{
    [DbContext(typeof(X42DbContext))]
    partial class X42DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("x42.Feature.Database.Tables.DictionaryData", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.HasIndex("Key")
                        .IsUnique();

                    b.ToTable("dictionary");
                });

            modelBuilder.Entity("x42.Feature.Database.Tables.PriceLockData", b =>
                {
                    b.Property<Guid>("PriceLockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DestinationAddress")
                        .HasColumnType("text");

                    b.Property<decimal>("DestinationAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("ExpireBlock")
                        .HasColumnType("integer");

                    b.Property<string>("FeeAddress")
                        .HasColumnType("text");

                    b.Property<decimal>("FeeAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("PayeeSignature")
                        .HasColumnType("text");

                    b.Property<string>("PriceLockSignature")
                        .HasColumnType("text");

                    b.Property<bool>("Relayed")
                        .HasColumnType("boolean");

                    b.Property<decimal>("RequestAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("RequestAmountPair")
                        .HasColumnType("integer");

                    b.Property<string>("SignAddress")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("TransactionId")
                        .HasColumnType("text");

                    b.HasKey("PriceLockId");

                    b.ToTable("pricelock");
                });

            modelBuilder.Entity("x42.Feature.Database.Tables.ProfileData", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("BlockConfirmed")
                        .HasColumnType("integer");

                    b.Property<string>("KeyAddress")
                        .HasColumnType("text");

                    b.Property<string>("PriceLockId")
                        .HasColumnType("text");

                    b.Property<bool>("Relayed")
                        .HasColumnType("boolean");

                    b.Property<string>("ReturnAddress")
                        .HasColumnType("text");

                    b.Property<string>("Signature")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.HasIndex("BlockConfirmed");

                    b.HasIndex("KeyAddress")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("profile");
                });

            modelBuilder.Entity("x42.Feature.Database.Tables.ProfileReservationData", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("KeyAddress")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PriceLockId")
                        .HasColumnType("text");

                    b.Property<bool>("Relayed")
                        .HasColumnType("boolean");

                    b.Property<int>("ReservationExpirationBlock")
                        .HasColumnType("integer");

                    b.Property<string>("ReturnAddress")
                        .HasColumnType("text");

                    b.Property<string>("Signature")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ReservationId");

                    b.ToTable("profilereservation");
                });

            modelBuilder.Entity("x42.Feature.Database.Tables.ServerNodeData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FeeAddress")
                        .HasColumnType("text");

                    b.Property<string>("KeyAddress")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastSeen")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NetworkAddress")
                        .HasColumnType("text");

                    b.Property<long>("NetworkPort")
                        .HasColumnType("bigint");

                    b.Property<int>("NetworkProtocol")
                        .HasColumnType("integer");

                    b.Property<long>("Priority")
                        .HasColumnType("bigint");

                    b.Property<string>("ProfileName")
                        .HasColumnType("text");

                    b.Property<bool>("Relayed")
                        .HasColumnType("boolean");

                    b.Property<string>("SignAddress")
                        .HasColumnType("text");

                    b.Property<string>("Signature")
                        .HasColumnType("text");

                    b.Property<int>("Tier")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProfileName")
                        .IsUnique();

                    b.ToTable("servernode");
                });
#pragma warning restore 612, 618
        }
    }
}
