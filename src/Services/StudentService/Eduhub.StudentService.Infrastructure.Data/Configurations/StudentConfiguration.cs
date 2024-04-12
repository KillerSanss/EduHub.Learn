using Eduhub.StudentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eduhub.StudentService.Infrastructure.Data.Configurations;

/// <summary>
/// Класс конфигурации студента
/// </summary>
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    /// <summary>
    /// Конфигурация студента
    /// </summary>
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(s => s.Id)
            .IsRequired();

        builder.OwnsOne(s => s.FullName, fullName =>
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

        builder.Property(s => s.Gender)
            .IsRequired();

        builder.Property(s => s.BirthDate)
            .IsRequired();

        builder.Property(s => s.Email.Value)
            .IsRequired()
            .HasMaxLength(255)
            .HasAnnotation("RegularExpression", @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");

        builder.Property(s => s.Phone.Value)
            .IsRequired()
            .HasAnnotation("RegularExpression", @"^\+373\d{8}$");

        builder.OwnsOne(s => s.Address, address =>
        {
            address.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            address.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            address.Property(a => a.HouseNumber)
                .IsRequired()
                .HasAnnotation("CheckConstraint", "HouseNumber >= 0");
        });

        builder.Property(s => s.Avatar)
            .IsRequired()
            .HasAnnotation("RegularExpression", @"^https?://.+\.(jpeg|png)$");

        builder.HasMany<Enrollment>()
            .WithOne()
            .HasForeignKey(e => e.StudentId);
    }
}