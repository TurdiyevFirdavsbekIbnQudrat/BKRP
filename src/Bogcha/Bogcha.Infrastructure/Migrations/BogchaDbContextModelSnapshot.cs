﻿// <auto-generated />
using Bogcha.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bogcha.Infrastructure.Migrations
{
    [DbContext(typeof(BogchaDbContext))]
    partial class BogchaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bogcha.Domain.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("Adminlar", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "Admin",
                            Role = "Admin",
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "Tarbiyachi",
                            Role = "Tarbiyachi",
                            UserName = "Tarbiyachi"
                        });
                });

            modelBuilder.Entity("Bogcha.Domain.Entities.Bola", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Familiya")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Familiya");

                    b.Property<int>("GuruhId")
                        .HasColumnType("int")
                        .HasColumnName("GuruhId");

                    b.Property<string>("Ism")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Ism");

                    b.HasKey("Id");

                    b.HasIndex("GuruhId");

                    b.ToTable("Bola", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Familiya = "Turdiyev",
                            GuruhId = 1,
                            Ism = "Yusuf"
                        },
                        new
                        {
                            Id = 2,
                            Familiya = "Usmonov",
                            GuruhId = 2,
                            Ism = "Sardor"
                        },
                        new
                        {
                            Id = 3,
                            Familiya = "Rustamova",
                            GuruhId = 1,
                            Ism = "Iymona"
                        },
                        new
                        {
                            Id = 4,
                            Familiya = "Xoldorxonov",
                            GuruhId = 2,
                            Ism = "Po'latXo'ja"
                        });
                });

            modelBuilder.Entity("Bogcha.Domain.Entities.Davomat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BolaId")
                        .HasColumnType("int")
                        .HasColumnName("BolaId");

                    b.Property<int>("TarbiyachId")
                        .HasColumnType("int")
                        .HasColumnName("TarbiyachId");

                    b.Property<int>("ishtirok")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("Ishtirok");

                    b.HasKey("Id");

                    b.HasIndex("BolaId");

                    b.HasIndex("TarbiyachId");

                    b.ToTable("Davomat", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BolaId = 1,
                            TarbiyachId = 1,
                            ishtirok = 1
                        },
                        new
                        {
                            Id = 2,
                            BolaId = 2,
                            TarbiyachId = 1,
                            ishtirok = 1
                        },
                        new
                        {
                            Id = 3,
                            BolaId = 3,
                            TarbiyachId = 2,
                            ishtirok = 1
                        },
                        new
                        {
                            Id = 4,
                            BolaId = 4,
                            TarbiyachId = 2,
                            ishtirok = 0
                        });
                });

            modelBuilder.Entity("Bogcha.Domain.Entities.Guruh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GuruhName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("GuruhName");

                    b.HasKey("Id");

                    b.ToTable("Guruh", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GuruhName = "Kamalak"
                        },
                        new
                        {
                            Id = 2,
                            GuruhName = "Kapalak"
                        });
                });

            modelBuilder.Entity("Bogcha.Domain.Entities.Tarbiyachi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Familiya")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Familiya");

                    b.Property<int>("GuruhId")
                        .HasColumnType("int")
                        .HasColumnName("GuruhId");

                    b.Property<string>("Ism")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Ism");

                    b.HasKey("Id");

                    b.HasIndex("GuruhId");

                    b.ToTable("Tarbiyachi", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Familiya = "Xolmatov",
                            GuruhId = 1,
                            Ism = "Asilbek"
                        },
                        new
                        {
                            Id = 2,
                            Familiya = "Xajiqurbonov",
                            GuruhId = 2,
                            Ism = "Azizbek"
                        },
                        new
                        {
                            Id = 3,
                            Familiya = "Turdiyeva",
                            GuruhId = 1,
                            Ism = "E'zoza"
                        },
                        new
                        {
                            Id = 4,
                            Familiya = "Matqosimova",
                            GuruhId = 2,
                            Ism = "Mohigul"
                        });
                });

            modelBuilder.Entity("Bogcha.Domain.Entities.Bola", b =>
                {
                    b.HasOne("Bogcha.Domain.Entities.Guruh", "guruh")
                        .WithMany("bola")
                        .HasForeignKey("GuruhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("guruh");
                });

            modelBuilder.Entity("Bogcha.Domain.Entities.Davomat", b =>
                {
                    b.HasOne("Bogcha.Domain.Entities.Bola", "bola")
                        .WithMany("davomat")
                        .HasForeignKey("BolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bogcha.Domain.Entities.Tarbiyachi", "tarbiyachi")
                        .WithMany("davomat")
                        .HasForeignKey("TarbiyachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bola");

                    b.Navigation("tarbiyachi");
                });

            modelBuilder.Entity("Bogcha.Domain.Entities.Tarbiyachi", b =>
                {
                    b.HasOne("Bogcha.Domain.Entities.Guruh", "guruh")
                        .WithMany("tarbiyachi")
                        .HasForeignKey("GuruhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("guruh");
                });

            modelBuilder.Entity("Bogcha.Domain.Entities.Bola", b =>
                {
                    b.Navigation("davomat");
                });

            modelBuilder.Entity("Bogcha.Domain.Entities.Guruh", b =>
                {
                    b.Navigation("bola");

                    b.Navigation("tarbiyachi");
                });

            modelBuilder.Entity("Bogcha.Domain.Entities.Tarbiyachi", b =>
                {
                    b.Navigation("davomat");
                });
#pragma warning restore 612, 618
        }
    }
}