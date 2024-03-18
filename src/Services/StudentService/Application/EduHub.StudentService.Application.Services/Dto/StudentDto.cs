using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Application.Services.Dto;

/// <summary>
/// Dto класс для студента
/// </summary>
public class StudentDto
{
    /// <summary>
    /// Имя
    /// </summary>
    public FullName FullName { get; init; }

    /// <summary>
    /// Гендер
    /// </summary>
    public Gender Gender { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public Phone Phone { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; init; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public Email Email { get; init; }

    /// <summary>
    /// Адресс
    /// </summary>
    public FullAddress Address { get; init; }

    /// <summary>
    /// Аватар
    /// </summary>
    public string Avatar { get; init; }
}