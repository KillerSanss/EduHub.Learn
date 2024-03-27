using Eduhub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dtos.Student;

/// <summary>
/// Дто для студента
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Surname">Фамилия.</param>
/// <param name="FirstName">Имя.</param>
/// <param name="Patronymic">Отчество.</param>
/// <param name="Gender">Гендер.</param>
/// <param name="BirthDate">День рождения</param>
/// <param name="Email">Электронная почта.</param>
/// <param name="Phone">Номер телефона.</param>
/// <param name="City">Город.</param>
/// <param name="Street">Улица.</param>
/// <param name="HouseNumber">Номер дома.</param>
/// <param name="Avatar">Аватар.</param>
public record UpdateStudentDto(
    Guid Id,
    string Surname,
    string FirstName,
    string Patronymic,
    Gender Gender,
    DateTime BirthDate,
    string Email,
    string Phone,
    string City,
    string Street,
    int HouseNumber,
    string Avatar);