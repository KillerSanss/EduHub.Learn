using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Eduhub.StudentService.Infrastructure.Data.Context;

/// <summary>
/// Класс контекста
/// </summary>
public class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Educator> Educators { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new StudentConfiguration().Configure(modelBuilder.Entity<Student>());
        new CourseConfiguration().Configure(modelBuilder.Entity<Course>());
        new EducatorConfiguration().Configure(modelBuilder.Entity<Educator>());
        new EnrollmentConfiguration().Configure(modelBuilder.Entity<Enrollment>());
    }
}