using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
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

        builder.Property(s => s.Id)
            .HasColumnName("id");

        builder.OwnsOne(s => s.FullName, fullName =>
        {
            fullName.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("first_name");

            fullName.Property(f => f.Surname)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("surname");

            fullName.Property(f => f.Patronymic)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("patronymic");
        });

        builder.Property(s => s.Gender)
            .IsRequired()
            .HasDefaultValue(Gender.None)
            .HasColumnName("gender");

        builder.Property(s => s.BirthDate)
            .IsRequired()
            .HasColumnName("birth_date");

        builder.OwnsOne(s => s.Phone, phone =>
        {
            phone.Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("phone");

            builder.HasIndex(s => s.Phone)
                .IsUnique()
                .HasDatabaseName("IX_Student_Phone");
        });

        builder.OwnsOne(s => s.Email, email =>
        {
            email.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("email");

            builder.HasIndex(s => s.Email)
                .IsUnique()
                .HasDatabaseName("IX_Student_Email");
        });

        builder.OwnsOne(s => s.Address, address =>
        {
            address.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("city");

            address.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("street");

            address.Property(a => a.HouseNumber)
                .IsRequired()
                .HasColumnName("house_number");
        });

        builder.Property(s => s.Avatar)
            .IsRequired()
            .HasColumnName("avatar");

        builder.HasMany<Enrollment>()
            .WithOne()
            .HasForeignKey(e => e.StudentId);
    }
}