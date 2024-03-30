using Eduhub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dtos.Educator;

/// <summary>
/// Базовое дто для преподавателя
/// </summary>
public abstract class BaseEducatorDto
{
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; init; }

    /// <summary>
    /// Гендер
    /// </summary>
    public Gender Gender { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; init; }

    /// <summary>
    /// Опыт работы
    /// </summary>
    public int WorkExperience { get; init; }

    /// <summary>
    /// Дата начала работы
    /// </summary>
    public DateTime StartDate { get; init; }
}