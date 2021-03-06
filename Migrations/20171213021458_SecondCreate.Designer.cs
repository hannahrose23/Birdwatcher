﻿// <auto-generated />
using Birdwatcher.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Birdwatcher.Migrations
{
    [DbContext(typeof(BirdwatcherContext))]
    [Migration("20171213021458_SecondCreate")]
    partial class SecondCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Birdwatcher.Models.Bird", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("ImageLocation");

                    b.Property<string>("Name");

                    b.Property<string>("Region");

                    b.HasKey("ID");

                    b.ToTable("Bird");
                });

            modelBuilder.Entity("Birdwatcher.Models.UsersBirds", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bird");

                    b.Property<DateTime>("DateSeen");

                    b.Property<string>("Description");

                    b.Property<string>("ImageLocation");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("UsersBirds");
                });
#pragma warning restore 612, 618
        }
    }
}
