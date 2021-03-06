// <auto-generated />
using System;
using Biuro_Podrozy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Biuro_Podrozy.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220125171418_Migracja")]
    partial class Migracja
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BiuroItemDepartureCity", b =>
                {
                    b.Property<int>("BiuroItemsId")
                        .HasColumnType("int");

                    b.Property<int>("DepartureCitiesDepartureCityId")
                        .HasColumnType("int");

                    b.HasKey("BiuroItemsId", "DepartureCitiesDepartureCityId");

                    b.HasIndex("DepartureCitiesDepartureCityId");

                    b.ToTable("BiuroItemDepartureCity");
                });

            modelBuilder.Entity("Biuro_Podrozy.Models.BiuroItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PhotosPhotoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<DateTime>("TravelDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TravelPlace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhotosPhotoId");

                    b.ToTable("Data");
                });

            modelBuilder.Entity("Biuro_Podrozy.Models.DepartureCity", b =>
                {
                    b.Property<int>("DepartureCityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartureCityId");

                    b.ToTable("Dc");
                });

            modelBuilder.Entity("Biuro_Podrozy.Models.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhotoName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhotoId");

                    b.ToTable("Ph");
                });

            modelBuilder.Entity("BiuroItemDepartureCity", b =>
                {
                    b.HasOne("Biuro_Podrozy.Models.BiuroItem", null)
                        .WithMany()
                        .HasForeignKey("BiuroItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biuro_Podrozy.Models.DepartureCity", null)
                        .WithMany()
                        .HasForeignKey("DepartureCitiesDepartureCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Biuro_Podrozy.Models.BiuroItem", b =>
                {
                    b.HasOne("Biuro_Podrozy.Models.Photo", "Photos")
                        .WithMany("BiuroItems")
                        .HasForeignKey("PhotosPhotoId");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Biuro_Podrozy.Models.Photo", b =>
                {
                    b.Navigation("BiuroItems");
                });
#pragma warning restore 612, 618
        }
    }
}
