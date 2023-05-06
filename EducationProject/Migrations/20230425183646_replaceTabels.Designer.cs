﻿// <auto-generated />
using System;
using EducationProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EducationProject.Migrations
{
    [DbContext(typeof(EducationprojectContext))]
    [Migration("20230425183646_replaceTabels")]
    partial class replaceTabels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EducationProject.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LevelId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Subscribe")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("EducationProject.Models.TbAssignmentLink", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"));

                    b.Property<string>("AssignmentTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("MatrialId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("LevelId");

                    b.HasIndex("MatrialId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TbAssignmentLinks");
                });

            modelBuilder.Entity("EducationProject.Models.TbCode", b =>
                {
                    b.Property<int>("CodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("StudentID");

                    b.HasKey("CodeId");

                    b.HasIndex(new[] { "LevelId" }, "IX_TbCodes_LevelId");

                    b.HasIndex(new[] { "StudentId" }, "IX_TbCodes_StudentID");

                    b.ToTable("TbCodes");
                });

            modelBuilder.Entity("EducationProject.Models.TbLevel", b =>
                {
                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("YearLevel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LevelId");

                    b.ToTable("TbLevel");
                });

            modelBuilder.Entity("EducationProject.Models.TbMatrial", b =>
                {
                    b.Property<int>("MatrialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MatrialID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatrialId"));

                    b.Property<int?>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("MatrialName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MatrialId");

                    b.HasIndex(new[] { "LevelId" }, "IX_TbMatrial_LevelId");

                    b.ToTable("TbMatrial");
                });

            modelBuilder.Entity("EducationProject.Models.TbStudent", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("StudentID");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("StudentFullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("subscribe")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("StudentId");

                    b.HasIndex(new[] { "LevelId" }, "IX_TbStudent_LevelId");

                    b.ToTable("TbStudent");
                });

            modelBuilder.Entity("EducationProject.Models.TbTeacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<int?>("MatrialId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TeacherId");

                    b.HasIndex("MatrialId");

                    b.ToTable("TbTeacher");
                });

            modelBuilder.Entity("EducationProject.Models.TbVideo", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VideoID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VideoId"));

                    b.Property<string>("Chapter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Chapter");

                    b.Property<string>("Lesson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Lesson");

                    b.Property<int?>("LevelId")
                        .HasColumnType("int");

                    b.Property<int?>("MatrialId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<string>("Url")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("URL");

                    b.Property<int>("semester")
                        .HasColumnType("int");

                    b.HasKey("VideoId");

                    b.HasIndex("MatrialId");

                    b.HasIndex(new[] { "LevelId" }, "IX_TbVideos_LevelId");

                    b.HasIndex(new[] { "TeacherId" }, "IX_TbVideos_TeacherId");

                    b.ToTable("TbVideos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StudentMatrial", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("StudentID");

                    b.Property<int>("MatrialId")
                        .HasColumnType("int")
                        .HasColumnName("MatrialID");

                    b.HasKey("StudentId", "MatrialId");

                    b.HasIndex(new[] { "MatrialId" }, "IX_StudentMatrial_MatrialID");

                    b.ToTable("StudentMatrial", (string)null);
                });

            modelBuilder.Entity("TbMatrialTbStudent", b =>
                {
                    b.Property<int>("MatrialId")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MatrialId", "StudentId");

                    b.ToTable("TbMatrialTbStudent");
                });

            modelBuilder.Entity("EducationProject.Models.ApplicationUser", b =>
                {
                    b.HasOne("EducationProject.Models.TbLevel", "Level")
                        .WithMany("AppUser")
                        .HasForeignKey("LevelId");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("EducationProject.Models.TbAssignmentLink", b =>
                {
                    b.HasOne("EducationProject.Models.TbLevel", "Level")
                        .WithMany("TbAssignmentLinks")
                        .HasForeignKey("LevelId")
                        .HasConstraintName("FK_TbAssignmentLinks_TbLevel");

                    b.HasOne("EducationProject.Models.TbMatrial", "Matrial")
                        .WithMany("TbAssignmentLinks")
                        .HasForeignKey("MatrialId");

                    b.HasOne("EducationProject.Models.TbTeacher", "Teacher")
                        .WithMany("TbAssignmentLinks")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("FK_TbAssignmentLinks_TbTeacher");

                    b.Navigation("Level");

                    b.Navigation("Matrial");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EducationProject.Models.TbCode", b =>
                {
                    b.HasOne("EducationProject.Models.TbLevel", "Level")
                        .WithMany("TbCodes")
                        .HasForeignKey("LevelId")
                        .HasConstraintName("FK_TbCodes_TbLevel");

                    b.HasOne("EducationProject.Models.TbStudent", "Student")
                        .WithMany("TbCodes")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_TbCodes_TbStudent");

                    b.Navigation("Level");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EducationProject.Models.TbMatrial", b =>
                {
                    b.HasOne("EducationProject.Models.TbLevel", "Level")
                        .WithMany("TbMatrials")
                        .HasForeignKey("LevelId")
                        .HasConstraintName("FK_TbMatrial_TbLevel");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("EducationProject.Models.TbStudent", b =>
                {
                    b.HasOne("EducationProject.Models.TbLevel", "Level")
                        .WithMany("TbStudents")
                        .HasForeignKey("LevelId")
                        .HasConstraintName("FK_TbStudent_TbLevel");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("EducationProject.Models.TbTeacher", b =>
                {
                    b.HasOne("EducationProject.Models.TbMatrial", "Matrial")
                        .WithMany("TbTeachers")
                        .HasForeignKey("MatrialId")
                        .HasConstraintName("FK_TbTeacher_TbMatrial");

                    b.Navigation("Matrial");
                });

            modelBuilder.Entity("EducationProject.Models.TbVideo", b =>
                {
                    b.HasOne("EducationProject.Models.TbLevel", "Level")
                        .WithMany("TbVideos")
                        .HasForeignKey("LevelId")
                        .HasConstraintName("FK_TbVideos_TbLevel");

                    b.HasOne("EducationProject.Models.TbMatrial", "Matrial")
                        .WithMany("TbVideos")
                        .HasForeignKey("MatrialId")
                        .HasConstraintName("FK_TbVideos_TbMatrial");

                    b.HasOne("EducationProject.Models.TbTeacher", "Teacher")
                        .WithMany("TbVideos")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Level");

                    b.Navigation("Matrial");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EducationProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EducationProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EducationProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentMatrial", b =>
                {
                    b.HasOne("EducationProject.Models.TbMatrial", null)
                        .WithMany()
                        .HasForeignKey("MatrialId")
                        .IsRequired()
                        .HasConstraintName("FK_StudentMatrial_TbMatrial");

                    b.HasOne("EducationProject.Models.TbStudent", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_StudentMatrial_TbStudent");
                });

            modelBuilder.Entity("EducationProject.Models.TbLevel", b =>
                {
                    b.Navigation("AppUser");

                    b.Navigation("TbAssignmentLinks");

                    b.Navigation("TbCodes");

                    b.Navigation("TbMatrials");

                    b.Navigation("TbStudents");

                    b.Navigation("TbVideos");
                });

            modelBuilder.Entity("EducationProject.Models.TbMatrial", b =>
                {
                    b.Navigation("TbAssignmentLinks");

                    b.Navigation("TbTeachers");

                    b.Navigation("TbVideos");
                });

            modelBuilder.Entity("EducationProject.Models.TbStudent", b =>
                {
                    b.Navigation("TbCodes");
                });

            modelBuilder.Entity("EducationProject.Models.TbTeacher", b =>
                {
                    b.Navigation("TbAssignmentLinks");

                    b.Navigation("TbVideos");
                });
#pragma warning restore 612, 618
        }
    }
}
