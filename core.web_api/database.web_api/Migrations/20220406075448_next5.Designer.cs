﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using database.trading;

#nullable disable

namespace database.trading.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220406075448_next5")]
    partial class next5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.2.22153.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("database.trading.DB_Models.Kripto.ponuda", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ponude");
                });

            modelBuilder.Entity("database.trading.DB_Models.Kripto.valuta", b =>
                {
                    b.Property<int>("valuta_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("valuta_id"), 1L, 1);

                    b.Property<string>("datum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iternval")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("last_high")
                        .HasColumnType("float");

                    b.Property<string>("logo_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("oznaka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ponudaid")
                        .HasColumnType("int");

                    b.Property<double>("promjena")
                        .HasColumnType("float");

                    b.Property<int>("rank")
                        .HasColumnType("int");

                    b.Property<int>("total_suplay")
                        .HasColumnType("int");

                    b.Property<decimal>("vrijednost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("valuta_id");

                    b.HasIndex("ponudaid");

                    b.ToTable("valute");
                });

            modelBuilder.Entity("database.trading.DB_Models.Security.auth_user", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lozinka")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("id");

                    b.ToTable("auth_korisnik");
                });

            modelBuilder.Entity("database.trading.DB_Models.Security.token", b =>
                {
                    b.Property<int>("token_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("token_id"), 1L, 1);

                    b.Property<bool>("expired")
                        .HasColumnType("bit");

                    b.Property<DateTime>("expires")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("issued")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<bool>("valid")
                        .HasColumnType("bit");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("token_id");

                    b.HasIndex("userId");

                    b.ToTable("tokeni");
                });

            modelBuilder.Entity("database.trading.DB_Models.Security.user_confirmation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("confirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("timeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("user_confirmacije");
                });

            modelBuilder.Entity("database.trading.DB_Models.Trading.tipTransakcije", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("naziv")
                        .HasColumnType("int");

                    b.Property<int>("opis")
                        .HasColumnType("int");

                    b.Property<int>("tip")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("tipTransakcije");
                });

            modelBuilder.Entity("database.trading.DB_Models.Trading.transakcija", b =>
                {
                    b.Property<int>("transakcija_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("transakcija_id"), 1L, 1);

                    b.Property<int?>("iz_valutaId")
                        .HasColumnType("int");

                    b.Property<int>("tipTransakcijeID")
                        .HasColumnType("int");

                    b.Property<int?>("u_valutaId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<DateTime>("vrijeme_obavljanja")
                        .HasColumnType("datetime2");

                    b.HasKey("transakcija_id");

                    b.HasIndex("iz_valutaId");

                    b.HasIndex("tipTransakcijeID");

                    b.HasIndex("u_valutaId");

                    b.HasIndex("userId");

                    b.ToTable("transakcije");
                });

            modelBuilder.Entity("database.trading.DB_Models.User.kreditna", b =>
                {
                    b.Property<int>("kreditna_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("kreditna_id"), 1L, 1);

                    b.Property<string>("broj_kartice")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("datum_isteka")
                        .HasColumnType("datetime2");

                    b.Property<string>("naziv_izdavaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("kreditna_id");

                    b.ToTable("kreditneKartice");
                });

            modelBuilder.Entity("database.trading.DB_Models.User.user", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"), 1L, 1);

                    b.Property<int>("authUserId")
                        .HasColumnType("int");

                    b.Property<string>("broj_telefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datum_rodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("drzava")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime_prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("kreditnaId")
                        .HasColumnType("int");

                    b.Property<int>("spol")
                        .HasColumnType("int");

                    b.Property<double>("stanje_walleta")
                        .HasColumnType("float");

                    b.HasKey("user_id");

                    b.HasIndex("authUserId");

                    b.HasIndex("kreditnaId");

                    b.ToTable("korisnici");
                });

            modelBuilder.Entity("database.trading.DB_Models.Kripto.valuta", b =>
                {
                    b.HasOne("database.trading.DB_Models.Kripto.ponuda", null)
                        .WithMany("valute")
                        .HasForeignKey("ponudaid");
                });

            modelBuilder.Entity("database.trading.DB_Models.Security.token", b =>
                {
                    b.HasOne("database.trading.DB_Models.User.user", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("database.trading.DB_Models.Security.user_confirmation", b =>
                {
                    b.HasOne("database.trading.DB_Models.User.user", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("database.trading.DB_Models.Trading.transakcija", b =>
                {
                    b.HasOne("database.trading.DB_Models.Kripto.valuta", "iz_valuta")
                        .WithMany()
                        .HasForeignKey("iz_valutaId");

                    b.HasOne("database.trading.DB_Models.Trading.tipTransakcije", "tipTransakcije")
                        .WithMany()
                        .HasForeignKey("tipTransakcijeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("database.trading.DB_Models.Kripto.valuta", "u_valuta")
                        .WithMany()
                        .HasForeignKey("u_valutaId");

                    b.HasOne("database.trading.DB_Models.User.user", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("iz_valuta");

                    b.Navigation("tipTransakcije");

                    b.Navigation("u_valuta");

                    b.Navigation("user");
                });

            modelBuilder.Entity("database.trading.DB_Models.User.user", b =>
                {
                    b.HasOne("database.trading.DB_Models.Security.auth_user", "authUser")
                        .WithMany()
                        .HasForeignKey("authUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("database.trading.DB_Models.User.kreditna", "kartica")
                        .WithMany()
                        .HasForeignKey("kreditnaId");

                    b.Navigation("authUser");

                    b.Navigation("kartica");
                });

            modelBuilder.Entity("database.trading.DB_Models.Kripto.ponuda", b =>
                {
                    b.Navigation("valute");
                });
#pragma warning restore 612, 618
        }
    }
}
