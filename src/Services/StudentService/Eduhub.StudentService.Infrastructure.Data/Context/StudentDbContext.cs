using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Eduhub.StudentService.Infrastructure.Data.Context;

/// <summary>
/// Класс контекста
/// </summary>
public class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; init; }
    public DbSet<Course> Courses { get; init; }
    public DbSet<Educator> Educators { get; init; }
    public DbSet<Enrollment> Enrollments { get; init; }

    public StudentDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Gender>();
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new EducatorConfiguration());
        modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
    }
}