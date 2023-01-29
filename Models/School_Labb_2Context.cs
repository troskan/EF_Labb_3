using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF_Labb_3.Models
{
    public partial class School_Labb_2Context : DbContext
    {
        public School_Labb_2Context()
        {
        }

        public School_Labb_2Context(DbContextOptions<School_Labb_2Context> options)
            : base(options)
        {
        }
        public string ConnectServer { get; set; } = "DESKTOP-10QDP98";
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<StaffRole> StaffRoles { get; set; } = null!;
        public virtual DbSet<StuCourse> StuCourses { get; set; } = null!;
        public virtual DbSet<StuGrade> StuGrades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<staff> Staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($"Server={ConnectServer};Database=School_Labb_2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("CourseID");

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Courses_Roles");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeId)
                    .ValueGeneratedNever()
                    .HasColumnName("GradeID");

                entity.Property(e => e.GradeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<StaffRole>(entity =>
            {
                entity.Property(e => e.StaffRoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("StaffRoleID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.StaffRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffRoles_Roles");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.StaffRoles)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffRoles_Staff");
            });

            modelBuilder.Entity<StuCourse>(entity =>
            {
                entity.Property(e => e.StuCourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("StuCourseID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StuCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StuCourses_Courses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StuCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StuCourses_Students");
            });

            modelBuilder.Entity<StuGrade>(entity =>
            {
                entity.Property(e => e.StuGradeId)
                    .ValueGeneratedNever()
                    .HasColumnName("StuGradeID");

                entity.Property(e => e.GradeDate).HasColumnType("date");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.StuGrades)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StuGrades_Grades");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.StuGrades)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_StuGrades_Roles");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StuGrades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StuGrades_Students");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.Ssn).HasColumnName("SSN");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.Ssn).HasColumnName("SSN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
