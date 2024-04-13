using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
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
        builder.HasKey(s => s.Id);

        builder.OwnsOne(s => s.FullName, fullName =>
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

        builder.Property(s => s.Gender)
            .IsRequired()
            .HasDefaultValue(Gender.None)
            .HasConversion<int>();

        builder.Property(s => s.BirthDate)
            .IsRequired();

        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(s => s.Email)
            .IsUnique();

        builder.Property(s => s.Phone)
            .IsRequired();

        builder.HasIndex(s => s.Phone)
            .IsUnique();

        builder.OwnsOne(s => s.Address, address =>
        {
            address.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            address.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            address.Property(a => a.HouseNumber)
                .IsRequired();
        });

        builder.Property(s => s.Avatar)
            .IsRequired();

        builder.HasMany<Enrollment>()
            .WithOne()
            .HasForeignKey(e => e.StudentId);

        builder.Property(s => s.Phone)
            .HasConversion(
                p => p.ToString(),
                p => new Phone(p)
            );

        builder.Property(s => s.Email)
            .HasConversion(
                e => e.ToString(),
                e => new Email(e)
            );

        builder.Property(e => e.Gender)
            .HasConversion(g => g.ToString(),
                g => (Gender) Enum.Parse(typeof(Gender), g)
            );
    }
}