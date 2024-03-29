
using Eduhub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dtos.Educator;

/// <summary>
/// Дто класс для преподавателя
/// </summary>
public record CreateEducatorDto : BaseEducatorDto
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="surname">Фамилия.</param>
    /// <param name="firstName">Имя.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="gender">Гендер.</param>
    /// <param name="phone">Телефон.</param>
    /// <param name="workExperience">Опыт работы.</param>
    /// <param name="startDate">Дата начала работы.</param>
    public CreateEducatorDto(
        string surname,
        string firstName,
        string patronymic,
        Gender gender,
        string phone,
        int workExperience,
        DateTime startDate) : base(surname, firstName, patronymic, gender, phone, workExperience, startDate)
    {
    }
};