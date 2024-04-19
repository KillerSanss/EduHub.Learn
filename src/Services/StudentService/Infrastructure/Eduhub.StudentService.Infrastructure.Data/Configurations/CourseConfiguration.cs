using Eduhub.StudentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eduhub.StudentService.Infrastructure.Data.Configurations;

/// <summary>
/// Класс конфигурации курса
/// </summary>
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    /// <summary>
    /// Конфигурация курса
    /// </summary>
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");

        builder.Property(c => c.Description)
            .HasColumnName("description");

        builder.Property(c => c.EducatorId)
            .IsRequired()
            .HasColumnName("educator_id");

        builder.HasOne<Educator>()
            .WithMany(e => e.Courses)
            .HasForeignKey(c => c.EducatorId);
    }
}