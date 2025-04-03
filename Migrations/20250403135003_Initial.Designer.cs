﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RssReader.Data;

#nullable disable

namespace RssReader.Migrations
{
    [DbContext(typeof(AppDatabaseContext))]
    [Migration("20250403135003_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("RssReader.Models.ChannelImageModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ChannelId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SiteLink")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<uint>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId")
                        .IsUnique();

                    b.ToTable("ChannelImages");
                });

            modelBuilder.Entity("RssReader.Models.ChannelModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.PrimitiveCollection<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Copyright")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Docs")
                        .HasColumnType("TEXT");

                    b.Property<string>("Generator")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastBuildDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ManagingDirector")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProxyLastBuildDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProxyPublishedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PublishedDate")
                        .HasColumnType("TEXT");

                    b.Property<uint?>("Rating")
                        .HasColumnType("INTEGER");

                    b.PrimitiveCollection<string>("SkipDays")
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("SkipHours")
                        .HasColumnType("TEXT");

                    b.Property<uint?>("TimeToLive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WebMaster")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("RssReader.Models.EnclosureModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Enclosures");
                });

            modelBuilder.Entity("RssReader.Models.ItemModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Categories")
                        .HasColumnType("TEXT");

                    b.Property<long>("ChannelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Guid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PubDateProxy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("RssReader.Models.ChannelImageModel", b =>
                {
                    b.HasOne("RssReader.Models.ChannelModel", null)
                        .WithOne()
                        .HasForeignKey("RssReader.Models.ChannelImageModel", "ChannelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RssReader.Models.EnclosureModel", b =>
                {
                    b.HasOne("RssReader.Models.ItemModel", null)
                        .WithOne("Enclosure")
                        .HasForeignKey("RssReader.Models.EnclosureModel", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RssReader.Models.ItemModel", b =>
                {
                    b.HasOne("RssReader.Models.ChannelModel", null)
                        .WithMany("Items")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RssReader.Models.ChannelModel", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("RssReader.Models.ItemModel", b =>
                {
                    b.Navigation("Enclosure");
                });
#pragma warning restore 612, 618
        }
    }
}
