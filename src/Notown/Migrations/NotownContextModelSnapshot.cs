﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Notown.Data;

namespace Notown.Migrations
{
    [DbContext(typeof(NotownContext))]
    partial class NotownContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Notown.Models.Album", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CopyrightDate");

                    b.Property<int>("MusicianID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("Speed");

                    b.HasKey("ID");

                    b.HasIndex("MusicianID");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Notown.Models.Instrument", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("Instrument");
                });

            modelBuilder.Entity("Notown.Models.Musician", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InstrumentID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("PlaceID");

                    b.Property<string>("Ssn")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.HasKey("ID");

                    b.HasIndex("InstrumentID");

                    b.HasIndex("PlaceID");

                    b.HasIndex("Ssn")
                        .IsUnique();

                    b.ToTable("Musician");
                });

            modelBuilder.Entity("Notown.Models.Place", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.HasIndex("TelephoneNumber")
                        .IsUnique();

                    b.ToTable("Place");
                });

            modelBuilder.Entity("Notown.Models.Song", b =>
                {
                    b.Property<int>("SongID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumID")
                        .IsRequired();

                    b.Property<int>("MusicianID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("SongID");

                    b.HasIndex("AlbumID");

                    b.HasIndex("MusicianID");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("Notown.Models.Telephone", b =>
                {
                    b.Property<string>("Number")
                        .HasMaxLength(10);

                    b.HasKey("Number");

                    b.ToTable("Telephone");
                });

            modelBuilder.Entity("Notown.Models.Album", b =>
                {
                    b.HasOne("Notown.Models.Musician", "Musician")
                        .WithMany("Albums")
                        .HasForeignKey("MusicianID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Notown.Models.Musician", b =>
                {
                    b.HasOne("Notown.Models.Instrument", "Instrument")
                        .WithMany("Musicians")
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Notown.Models.Place", "Place")
                        .WithMany("Musicians")
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Notown.Models.Place", b =>
                {
                    b.HasOne("Notown.Models.Telephone", "Telephone")
                        .WithOne("Place")
                        .HasForeignKey("Notown.Models.Place", "TelephoneNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Notown.Models.Song", b =>
                {
                    b.HasOne("Notown.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Notown.Models.Musician", "Musician")
                        .WithMany("Songs")
                        .HasForeignKey("MusicianID");
                });
        }
    }
}
