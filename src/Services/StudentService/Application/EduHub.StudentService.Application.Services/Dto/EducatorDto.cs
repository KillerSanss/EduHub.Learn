using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Application.Services.Dto;

/// <summary>
/// Dto класс для преподавателя
/// </summary>
public class EducatorDto
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
    /// Опыт работы
    /// </summary>
    public int WorkExperience { get; init; }

    /// <summary>
    /// Дата начала работы
    /// </summary>
    public DateTime StartDate { get; init; }
}