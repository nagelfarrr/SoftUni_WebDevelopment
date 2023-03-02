namespace P01_StudentSystem.Data;
using Models;

using Microsoft.EntityFrameworkCore;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {
        
    }

    public StudentSystemContext(DbContextOptions options) 
        : base(options)
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
            optionsBuilder.UseSqlServer(
                @"Server=.\\SQLEXPRESS;Database=StudentSystemDemo;Trusted_Connection=True;Integrated Security = true;TrustServerCertificate = true;");
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //TODO: FLUENT API

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(s => s.PhoneNumber).IsUnicode(false);
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.Property(r => r.Url).IsUnicode(false);
        });

        modelBuilder.Entity<Homework>(entity =>
        {
            entity.Property(h => h.Content).IsUnicode(false);
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(sc => new
            {
                sc.StudentId,
                sc.CourseId
            });
        });
            
        base.OnModelCreating(modelBuilder);
    }
}

