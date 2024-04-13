using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
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
        builder.HasKey(e => e.Id);

        builder.OwnsOne(e => e.FullName, fullName =>
        {
            fullName.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(60);

            fullName.Property(f => f.Surname)
                .IsRequired()
                .HasMaxLength(60);

            fullName.Property(f => f.Patronymic)
                .IsRequired()
                .HasMaxLength(60);
        });

        builder.Property(e => e.Gender)
            .IsRequired()
            .HasDefaultValue(Gender.None)
            .HasConversion<int>();

        builder.Property(e => e.Phone)
            .IsRequired();

        builder.HasIndex(e => e.Phone)
            .IsUnique();

        builder.Property(e => e.WorkExperience)
            .IsRequired();

        builder.Property(e => e.StartDate)
            .IsRequired();

        builder.HasMany(e => e.Courses)
            .WithOne()
            .HasForeignKey(c => c.EducatorId);

        builder.Property(e => e.Phone)
            .HasConversion(
                p => p.ToString(),
                p => new Phone(p)
            );

        builder.Property(e => e.Gender)
            .HasConversion(g => g.ToString(),
                g => (Gender) Enum.Parse(typeof(Gender), g)
            );
    }
}