using Eduhub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dtos.Educator;

/// <summary>
/// Дто класс для преподавателя
/// </summary>
public record UpdateEducatorDto : BaseEducatorDto
{
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="surname">Фамилия.</param>
    /// <param name="firstName">Имя.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="gender">Гендер.</param>
    /// <param name="phone">Телефон.</param>
    /// <param name="workExperience">Опыт работы.</param>
    /// <param name="startDate">Дата начала работы.</param>
    public UpdateEducatorDto(
        Guid id,
        string surname,
        string firstName,
        string patronymic,
        Gender gender,
        string phone,
        int workExperience,
        DateTime startDate) : base(surname, firstName, patronymic, gender, phone, workExperience, startDate)
    {
        Id = id;
    }
}