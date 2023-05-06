using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationProject.Models;

public partial class EducationprojectContext : IdentityDbContext<ApplicationUser>
{
    public EducationprojectContext()
    {
        
    }

    public EducationprojectContext(DbContextOptions<EducationprojectContext> options)
       : base(options)
    {
    }

    public virtual DbSet<AssignmentsDone> AssignmentsDone { get; set; }

    public virtual DbSet<TbAssignmentLink> TbAssignmentLinks { get; set; }

    public virtual DbSet<TbCode> TbCodes { get; set; }

    public virtual DbSet<TbLevel> TbLevels { get; set; }

    public virtual DbSet<TbMatrial> TbMatrials { get; set; }

    public virtual DbSet<TbStudent> TbStudents { get; set; }

    public virtual DbSet<TbTeacher> TbTeachers { get; set; }

    public virtual DbSet<TbVideo> TbVideos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AssignmentsDone>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("PK_TbAssignments");

            entity.HasOne(d => d.Assignment).WithMany(p => p.TbAssignmentDones).HasConstraintName("FK_TbAssignmentDones_TbAssignmentLinks");

            entity.HasOne(d => d.Matrial).WithMany(p => p.TbAssignmentDones)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TbAssignment_TbMatrial");

            entity.HasOne(d => d.StudentUser).WithMany(p => p.AssignmentDones)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TbAssignment_TbStudent");
        });

        modelBuilder.Entity<TbAssignmentLink>(entity =>
        {
            entity.HasOne(d => d.Level).WithMany(p => p.TbAssignmentLinks).HasConstraintName("FK_TbAssignmentLinks_TbLevel");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TbAssignmentLinks).HasConstraintName("FK_TbAssignmentLinks_TbTeacher");
        });

        modelBuilder.Entity<TbCode>(entity =>
        {
            entity.HasOne(d => d.Level).WithMany(p => p.TbCodes).HasConstraintName("FK_TbCodes_TbLevel");

            entity.HasOne(d => d.Student).WithMany(p => p.TbCodes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbCodes_TbStudent");
        });

        modelBuilder.Entity<TbLevel>(entity =>
        {
            entity.Property(e => e.LevelId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TbMatrial>(entity =>
        {
            entity.HasOne(d => d.Level).WithMany(p => p.TbMatrials).HasConstraintName("FK_TbMatrial_TbLevel");
        });

        modelBuilder.Entity<TbStudent>(entity =>
        {
            entity.HasOne(d => d.Level).WithMany(p => p.TbStudents).HasConstraintName("FK_TbStudent_TbLevel");

            entity.HasMany(d => d.Matrial).WithMany(p => p.Student)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentMatrial",
                    r => r.HasOne<TbMatrial>().WithMany()
                        .HasForeignKey("MatrialId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StudentMatrial_TbMatrial"),
                    l => l.HasOne<TbStudent>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StudentMatrial_TbStudent"),
                    j =>
                    {
                        j.HasKey("StudentId", "MatrialId");
                        j.ToTable("StudentMatrial");
                        j.HasIndex(new[] { "MatrialId" }, "IX_StudentMatrial_MatrialID");
                        j.IndexerProperty<string>("StudentId").HasColumnName("StudentID");
                        j.IndexerProperty<int>("MatrialId").HasColumnName("MatrialID");
                    });
        });

        modelBuilder.Entity<TbTeacher>(entity =>
        {
            entity.HasOne(d => d.Matrial).WithMany(p => p.TbTeachers).HasConstraintName("FK_TbTeacher_TbMatrial");
        });

        modelBuilder.Entity<TbVideo>(entity =>
        {
            entity.HasOne(d => d.Level).WithMany(p => p.TbVideos).HasConstraintName("FK_TbVideos_TbLevel");

            entity.HasOne(d => d.Matrial).WithMany(p => p.TbVideos).HasConstraintName("FK_TbVideos_TbMatrial");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
