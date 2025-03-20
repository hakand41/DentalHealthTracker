﻿// <auto-generated />
using System;
using DentalHealthTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DentalHealthTracker.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250320122627_SeedHealthSuggestionsUpdate")]
    partial class SeedHealthSuggestionsUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DentalHealthTracker.Core.Entities.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Importance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("DentalHealthTracker.Core.Entities.HealthRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("FlossingCount")
                        .HasColumnType("int");

                    b.Property<int>("GoalId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("MouthwashUsage")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("RecordTime")
                        .HasColumnType("time");

                    b.Property<int>("ToothBrushingCount")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoalId");

                    b.HasIndex("UserId");

                    b.ToTable("HealthRecords");
                });

            modelBuilder.Entity("DentalHealthTracker.Core.Entities.HealthSuggestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("HealthSuggestions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Dişlerinizi günde en az 2 kez fırçalayın.",
                            CreatedAt = new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true
                        },
                        new
                        {
                            Id = 2,
                            Content = "Şekerli yiyeceklerden kaçının.",
                            CreatedAt = new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true
                        },
                        new
                        {
                            Id = 3,
                            Content = "Diş ipi kullanmayı ihmal etmeyin.",
                            CreatedAt = new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true
                        },
                        new
                        {
                            Id = 4,
                            Content = "Diş hekiminize düzenli olarak görünün.",
                            CreatedAt = new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true
                        },
                        new
                        {
                            Id = 5,
                            Content = "Sigara ve alkol tüketimini azaltın.",
                            CreatedAt = new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true
                        },
                        new
                        {
                            Id = 6,
                            Content = "Ağız çalkalama suyu kullanın.",
                            CreatedAt = new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true
                        },
                        new
                        {
                            Id = 7,
                            Content = "Sağlıklı beslenme diş sağlığınızı korur.",
                            CreatedAt = new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true
                        },
                        new
                        {
                            Id = 8,
                            Content = "Aşırı sert diş fırçalamaktan kaçının.",
                            CreatedAt = new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true
                        },
                        new
                        {
                            Id = 9,
                            Content = "Dişlerinizi yatmadan önce mutlaka fırçalayın.",
                            CreatedAt = new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true
                        },
                        new
                        {
                            Id = 10,
                            Content = "Asitli içecekleri sınırlayın.",
                            CreatedAt = new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true
                        });
                });

            modelBuilder.Entity("DentalHealthTracker.Core.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("DentalHealthTracker.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DentalHealthTracker.Core.Entities.Goal", b =>
                {
                    b.HasOne("DentalHealthTracker.Core.Entities.User", "User")
                        .WithMany("Goals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DentalHealthTracker.Core.Entities.HealthRecord", b =>
                {
                    b.HasOne("DentalHealthTracker.Core.Entities.Goal", "Goal")
                        .WithMany("HealthRecords")
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DentalHealthTracker.Core.Entities.User", "User")
                        .WithMany("HealthRecords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Goal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DentalHealthTracker.Core.Entities.Note", b =>
                {
                    b.HasOne("DentalHealthTracker.Core.Entities.User", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DentalHealthTracker.Core.Entities.Goal", b =>
                {
                    b.Navigation("HealthRecords");
                });

            modelBuilder.Entity("DentalHealthTracker.Core.Entities.User", b =>
                {
                    b.Navigation("Goals");

                    b.Navigation("HealthRecords");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
