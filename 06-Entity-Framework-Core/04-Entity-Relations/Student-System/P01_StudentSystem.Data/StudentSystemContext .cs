namespace P01_StudentSystem.Data;

using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models;
using System.Globalization;

public class StudentSystemContext : DbContext
{
	public StudentSystemContext()
	{

	}

	public StudentSystemContext(DbContextOptions options) : base(options) 
	{

	}

    public DbSet<Student> Students { get; set; } = null!;

    public DbSet<Course> Courses { get; set; } = null!;

    public DbSet<Resource> Resources { get; set; } = null!;

    public DbSet<Homework> Homeworks { get; set; } = null!;

    public DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(s => s.StudentId);

            entity.Property(s => s.Name).HasMaxLength(100).IsUnicode().IsRequired();

            entity.Property(s=>s.PhoneNumber).HasMaxLength(10).IsFixedLength().IsUnicode(false).IsRequired(false);

            entity.Property(s=>s.Birthday).IsRequired(false);

        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(c => c.CourseId);
            
            entity.Property(c=>c.Name).HasMaxLength(80).IsUnicode().IsRequired();

            entity.Property(c=>c.Description).IsUnicode().IsRequired(false);

        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(r => r.ResourceId);

            entity.HasOne(r=>r.Course)
            .WithMany(c=>c.Resources)
            .HasForeignKey(r=>r.CourseId);

            entity.Property(r => r.Name)
            .HasMaxLength(50)
            .IsUnicode();

            entity.Property(r => r.Url)
            .IsUnicode(false);

        });

        modelBuilder.Entity<Homework>(entity =>
        {
            entity.HasKey(h => h.HomeworkId);

            entity.HasOne(h => h.Student)
            .WithMany(s => s.Homeworks)
            .HasForeignKey(h => h.StudentId);

            entity.HasOne(h=>h.Course)
            .WithMany(c=>c.Homeworks)
            .HasForeignKey(h=>h.CourseId);

            entity.Property(h => h.Content)
            .IsUnicode(false);
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(sc => new
            {
                sc.StudentId,
                sc.CourseId
            });

            entity.HasOne(sc => sc.Course)
            .WithMany(c => c.StudentsCourses)
            .HasForeignKey(sc => sc.CourseId);

            entity.HasOne(sc => sc.Student)
            .WithMany(s => s.StudentsCourses)
            .HasForeignKey(sc => sc.StudentId);

        });

    }
}