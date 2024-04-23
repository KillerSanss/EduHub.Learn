using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.Data.Extensions;
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

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.RegisterEnums();
        modelBuilder.ApplyAllConfigurations();
    }
}