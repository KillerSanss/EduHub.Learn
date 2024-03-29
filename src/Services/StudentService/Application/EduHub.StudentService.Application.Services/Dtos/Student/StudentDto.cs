using Eduhub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dtos.Student;

/// <summary>
/// Дто студента
/// </summary>
public record StudentDto : BaseStudentDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="surname">Фамилия.</param>
    /// <param name="firstName">Имя.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="gender">Гендер.</param>
    /// <param name="birthDate">День рождения</param>
    /// <param name="email">Электронная почта.</param>
    /// <param name="phone">Номер телефона.</param>
    /// <param name="city">Город.</param>
    /// <param name="street">Улица.</param>
    /// <param name="houseNumber">Номер дома.</param>
    /// <param name="avatar">Аватар.</param>
    public StudentDto(
        Guid id,
        string surname,
        string firstName,
        string patronymic,
        Gender gender,
        DateTime birthDate,
        string email,
        string phone,
        string city,
        string street,
        int houseNumber,
        string avatar)
        : base(
            surname,
            firstName,
            patronymic,
            gender,
            birthDate,
            email,
            phone,
            city,
            street,
            houseNumber,
            avatar)
    {
        Id = id;
    }
}