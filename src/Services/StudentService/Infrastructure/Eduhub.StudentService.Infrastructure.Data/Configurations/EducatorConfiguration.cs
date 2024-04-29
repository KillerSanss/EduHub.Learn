using EduHub.StudentService.Application.Services.Constants;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
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

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.OwnsOne(e => e.FullName, fullName =>
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

        builder.Property(e => e.Gender)
            .IsRequired()
            .HasDefaultValue(Gender.None)
            .HasColumnName("gender");

        builder.OwnsOne(e => e.Phone, phone =>
        {
            phone.Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("phone");

            phone.HasIndex(s => s.Value)
                .IsUnique()
                .HasDatabaseName(IndexConstants.UniqueEducatorPhone);
        });

        builder.Property(e => e.WorkExperience)
            .IsRequired()
            .HasColumnName("work_experience");

        builder.Property(e => e.StartDate)
            .IsRequired()
            .HasColumnName("start_date")
            .HasColumnType("timestamp");

        builder.HasMany(e => e.Courses)
            .WithOne()
            .HasForeignKey(c => c.EducatorId);
    }
}