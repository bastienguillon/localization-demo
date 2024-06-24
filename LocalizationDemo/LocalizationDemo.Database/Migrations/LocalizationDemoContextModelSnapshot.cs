﻿// <auto-generated />
using System;
using LocalizationDemo.Database.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocalizationDemo.Database.Migrations
{
    [DbContext(typeof(LocalizationDemoContext))]
    partial class LocalizationDemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.FormElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FormElementDiscriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("FormElementStructureDiscriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReferenceCulture")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FormElement", (string)null);

                    b.HasDiscriminator<string>("FormElementDiscriminator").HasValue("FormElement");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.FormElementStructure", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FormElementStructureDiscriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FormElement", null, t =>
                        {
                            t.Property("FormElementStructureDiscriminator")
                                .HasColumnName("FormElementStructureDiscriminator1");
                        });

                    b.HasDiscriminator<string>("FormElementStructureDiscriminator").HasValue("FormElementStructure");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.I18nFormElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CultureCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FormElementId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FormElementId");

                    b.ToTable("I18nFormElement", (string)null);
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.I18nListFormElementStructure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CultureCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FormElementId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FormElementId");

                    b.ToTable("I18nListFormElementStructure", (string)null);
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.I18nRangeFormElementStructure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CultureCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FormElementId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MaxLabel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MinLabel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FormElementId");

                    b.ToTable("I18nRangeFormElementStructure", (string)null);
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Products.LocalizedProduct", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Category");

                    b.Property<string>("CultureCode")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("TEXT")
                        .HasColumnName("CultureCode");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<decimal>("UsdPrice")
                        .HasColumnType("TEXT")
                        .HasColumnName("UsdPrice");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.ToView("LocalizedProducts", (string)null);
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Category");

                    b.Property<decimal>("UsdPrice")
                        .HasColumnType("TEXT")
                        .HasColumnName("UsdPrice");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.ShoppingCarts.LocalizedShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.ToView("ShoppingCarts", (string)null);
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.ShoppingCarts.ShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCarts", (string)null);
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.FeedbackFormElement", b =>
                {
                    b.HasBaseType("LocalizationDemo.Domain.Models.Forms.FormElement");

                    b.HasDiscriminator().HasValue("feedback");
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.ReviewFormElement", b =>
                {
                    b.HasBaseType("LocalizationDemo.Domain.Models.Forms.FormElement");

                    b.HasDiscriminator().HasValue("review");
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.ListFormElementStructure", b =>
                {
                    b.HasBaseType("LocalizationDemo.Domain.Models.Forms.FormElementStructure");

                    b.Property<string>("ReferenceCulture")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("FormElement", t =>
                        {
                            t.Property("FormElementStructureDiscriminator")
                                .HasColumnName("FormElementStructureDiscriminator1");

                            t.Property("ReferenceCulture")
                                .HasColumnName("ListFormElementStructure_ReferenceCulture");
                        });

                    b.HasDiscriminator().HasValue("list");
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.RangeFormElementStructure", b =>
                {
                    b.HasBaseType("LocalizationDemo.Domain.Models.Forms.FormElementStructure");

                    b.Property<string>("ReferenceCulture")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("FormElement", t =>
                        {
                            t.Property("FormElementStructureDiscriminator")
                                .HasColumnName("FormElementStructureDiscriminator1");

                            t.Property("ReferenceCulture")
                                .HasColumnName("RangeFormElementStructure_ReferenceCulture");
                        });

                    b.HasDiscriminator().HasValue("range");
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.FormElementStructure", b =>
                {
                    b.HasOne("LocalizationDemo.Domain.Models.Forms.FormElement", null)
                        .WithOne("FormElementStructure")
                        .HasForeignKey("LocalizationDemo.Domain.Models.Forms.FormElementStructure", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.I18nFormElement", b =>
                {
                    b.HasOne("LocalizationDemo.Domain.Models.Forms.FormElement", null)
                        .WithMany("Translations")
                        .HasForeignKey("FormElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.I18nListFormElementStructure", b =>
                {
                    b.HasOne("LocalizationDemo.Domain.Models.Forms.ListFormElementStructure", null)
                        .WithMany("Translations")
                        .HasForeignKey("FormElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.I18nRangeFormElementStructure", b =>
                {
                    b.HasOne("LocalizationDemo.Domain.Models.Forms.RangeFormElementStructure", null)
                        .WithMany("Translations")
                        .HasForeignKey("FormElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Products.Product", b =>
                {
                    b.OwnsMany("LocalizationDemo.Domain.Models.Products.Product+ProductTranslation", "Translations", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("CultureCode")
                                .HasMaxLength(16)
                                .HasColumnType("TEXT")
                                .HasColumnName("CultureCode");

                            b1.Property<string>("Description")
                                .HasColumnType("TEXT")
                                .HasColumnName("Description");

                            b1.Property<bool>("IsDefault")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bit")
                                .HasDefaultValue(false)
                                .HasColumnName("IsDefault");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("Name");

                            b1.HasKey("ProductId", "CultureCode");

                            b1.HasIndex("ProductId", "IsDefault")
                                .IsUnique()
                                .HasFilter("[IsDefault] = 1");

                            b1.ToTable("ProductTranslations", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Translations");
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.ShoppingCarts.LocalizedShoppingCart", b =>
                {
                    b.OwnsMany("LocalizationDemo.Domain.Models.ShoppingCarts.LocalizedShoppingCart+LocalizedShoppingCartProduct", "Products", b1 =>
                        {
                            b1.Property<Guid>("ShoppingCartId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("ProductId")
                                .HasColumnType("INTEGER");

                            b1.HasKey("ShoppingCartId", "ProductId");

                            b1.HasIndex("ProductId");

                            b1.ToTable((string)null);

                            b1.ToView("ShoppingCartProducts", (string)null);

                            b1.HasOne("LocalizationDemo.Domain.Models.Products.LocalizedProduct", "Product")
                                .WithMany()
                                .HasForeignKey("ProductId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner("ShoppingCart")
                                .HasForeignKey("ShoppingCartId");

                            b1.Navigation("Product");

                            b1.Navigation("ShoppingCart");
                        });

                    b.Navigation("Products");
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.ShoppingCarts.ShoppingCart", b =>
                {
                    b.OwnsMany("LocalizationDemo.Domain.Models.ShoppingCarts.ShoppingCart+ShoppingCartProduct", "Products", b1 =>
                        {
                            b1.Property<Guid>("ShoppingCartId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("ProductId")
                                .HasColumnType("INTEGER");

                            b1.HasKey("ShoppingCartId", "ProductId");

                            b1.HasIndex("ProductId");

                            b1.ToTable("ShoppingCartProducts", (string)null);

                            b1.HasOne("LocalizationDemo.Domain.Models.Products.Product", "Product")
                                .WithMany()
                                .HasForeignKey("ProductId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner("ShoppingCart")
                                .HasForeignKey("ShoppingCartId");

                            b1.Navigation("Product");

                            b1.Navigation("ShoppingCart");
                        });

                    b.Navigation("Products");
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.FormElement", b =>
                {
                    b.Navigation("FormElementStructure")
                        .IsRequired();

                    b.Navigation("Translations");
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.ListFormElementStructure", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("LocalizationDemo.Domain.Models.Forms.RangeFormElementStructure", b =>
                {
                    b.Navigation("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}
