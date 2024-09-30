using System;
using System.Collections.Generic;
using Hope.DomainEntites.DbEntites;
using Microsoft.EntityFrameworkCore;

namespace Hope.DomainEntites;

public partial class HopeSchoolContext : DbContext
{
    public HopeSchoolContext()
    {
    }

    public HopeSchoolContext(DbContextOptions<HopeSchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SectionTable> SectionTables { get; set; }

    public virtual DbSet<StudentsTable> StudentsTables { get; set; }

    public virtual DbSet<TeachersTable> TeachersTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GWTC71427;Database=HopeSchool;Trusted_Connection=True;TrustServerCertificate=True; User Id=sa;password=12345;Integrated Security=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SectionTable>(entity =>
        {
            entity.HasKey(e => e.SectionId);

            entity.ToTable("SectionTable");

            entity.Property(e => e.SectionName).HasMaxLength(50);

            entity.HasOne(d => d.SectionTeacherNavigation).WithMany(p => p.SectionTables)
                .HasForeignKey(d => d.SectionTeacher)
                .HasConstraintName("FK_SectionTable_SectionTable1");
        });

        modelBuilder.Entity<StudentsTable>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("StudentsTable");

            entity.Property(e => e.FathersEducation).HasMaxLength(50);
            entity.Property(e => e.MothersEducation).HasMaxLength(50);
            entity.Property(e => e.StudentsAddress).HasMaxLength(50);
            entity.Property(e => e.StudentsEmail).HasMaxLength(50);
            entity.Property(e => e.StudentsEnrollmentDate).HasMaxLength(50);
            entity.Property(e => e.StudentsFirstName).HasMaxLength(50);
            entity.Property(e => e.StudentsLasttName).HasMaxLength(50);
            entity.Property(e => e.StudentsPhoneNumber).HasMaxLength(50);
            entity.Property(e => e.StudentsPictureUrl)
                .HasMaxLength(250)
                .HasColumnName("StudentsPictureURL");

            entity.HasOne(d => d.Section).WithMany(p => p.StudentsTables)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_StudentsTable_SectionTable");
        });

        modelBuilder.Entity<TeachersTable>(entity =>
        {
            entity.HasKey(e => e.TeachersId);

            entity.ToTable("TeachersTable");

            entity.Property(e => e.TeachersId).HasColumnName("TeachersID");
            entity.Property(e => e.Isactive)
                .HasMaxLength(50)
                .HasColumnName("ISACTIVE");
            entity.Property(e => e.TeachersAddress).HasMaxLength(50);
            entity.Property(e => e.TeachersDateOfBirth).HasMaxLength(50);
            entity.Property(e => e.TeachersEmail).HasMaxLength(50);
            entity.Property(e => e.TeachersFirstName).HasMaxLength(50);
            entity.Property(e => e.TeachersHireDate).HasMaxLength(50);
            entity.Property(e => e.TeachersLastName).HasMaxLength(50);
            entity.Property(e => e.TeachersPhoneNumber).HasMaxLength(50);
            entity.Property(e => e.TeachersPictureUrl)
                .HasMaxLength(250)
                .HasColumnName("TeachersPictureURL");
            entity.Property(e => e.TeachersSpecialization).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
