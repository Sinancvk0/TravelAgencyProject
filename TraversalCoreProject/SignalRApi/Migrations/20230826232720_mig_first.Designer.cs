﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SignalRApi.Dal;

namespace SignalRApi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230826232720_mig_first")]
    partial class mig_first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SignalRApi.Dal.Visitor", b =>
                {
                    b.Property<int>("VisitorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("City")
                        .HasColumnType("integer");

                    b.Property<int>("CityVisitCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("VisitorID");

                    b.ToTable("Visitors");
                });
#pragma warning restore 612, 618
        }
    }
}
