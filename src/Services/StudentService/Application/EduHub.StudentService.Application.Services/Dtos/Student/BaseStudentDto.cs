using Eduhub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dtos.Student;

/// <summary>
/// Базовое дто для студента
/// </summary>
public abstract class BaseStudentDto
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
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; init; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; init; }

    /// <summary>
    /// Город
    /// </summary>
    public string City { get; init; }

    /// <summary>
    /// Улица
    /// </summary>
    public string Street { get; init; }

    /// <summary>
    /// Номер дома
    /// </summary>
    public int HouseNumber { get; init; }

    /// <summary>
    /// Аватар
    /// </summary>
    public string Avatar { get; init; }
}