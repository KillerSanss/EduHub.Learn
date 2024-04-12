using Eduhub.StudentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eduhub.StudentService.Infrastructure.Data.Configurations;

/// <summary>
/// Класс конфигурации преподавателя
/// </summary>
public class EducatorConfiguration : IEntityTypeConfiguration<Educator>
{
    /// <summary>
    /// Конфигурация преподавателя
    /// </summary>
    public void Configure(EntityTypeBuilder<Educator> builder)
    {
        builder.Property(e => e.Id)
            .IsRequired();

        builder.OwnsOne(e => e.FullName, fullName =>
        {
            fullName.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(60)
                .HasAnnotation("RegularExpression", "\\p{L}'?$");

            fullName.Property(f => f.Surname)
                .IsRequired()
                .HasMaxLength(60)
                .HasAnnotation("RegularExpression", "\\p{L}'?$");

            fullName.Property(f => f.Patronymic)
                .IsRequired()
                .HasMaxLength(60)
                .HasAnnotation("RegularExpression", "\\p{L}'?$");
        });

        builder.Property(e => e.Gender)
            .IsRequired();

        builder.Property(e => e.Phone.Value)
            .IsRequired()
            .HasAnnotation("RegularExpression", @"^\+373\d{8}$");

        builder.Property(e => e.WorkExperience)
            .IsRequired()
            .HasAnnotation("CheckConstraint", "WorkExperience >= 0");

        builder.Property(e => e.StartDate)
            .IsRequired();

        builder.Property(e => e.Courses);

        builder.HasMany(e => e.Courses)
            .WithOne()
            .HasForeignKey(c => c.EducatorId);
    }
}