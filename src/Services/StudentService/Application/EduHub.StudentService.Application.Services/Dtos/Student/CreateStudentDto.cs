using Eduhub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dtos.Student;

/// <summary>
/// Дто для студента
/// </summary>
public record CreateStudentDto : BaseStudentDto
{
    /// <summary>
    /// Конструктор
    /// </summary>
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
    public CreateStudentDto(
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
    }
};