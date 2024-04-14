using Eduhub.StudentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eduhub.StudentService.Infrastructure.Data.Configurations;

/// <summary>
/// Класс конфигурации зачисления
/// </summary>
public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    /// <summary>
    /// Конфигурация зачисления
    /// </summary>
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.StudentId)
            .IsRequired()
            .HasColumnName("student_id");

        builder.Property(e => e.CourseId)
            .IsRequired()
            .HasColumnName("course_id");

        builder.Property(e => e.StartDate)
            .IsRequired()
            .HasColumnName("start_date");

        builder.HasOne<Student>()
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);
    }
}