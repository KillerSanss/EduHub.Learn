namespace Eduhub.StudentService.Infrastructure.Data.DbIndexes;

/// <summary>
/// Класс описывающий индексы для базы данных
/// </summary>
public static class Indexes
{
    /// <summary>
    /// Индекс для электронной почты студента
    /// </summary>
    public const string StudentEmail = "IX_Student_Email";

    /// <summary>
    /// Индекс для телефона студента
    /// </summary>
    public const string StudentPhone = "IX_Student_Phone";

    /// <summary>
    /// Индекс для телефона преподавателя
    /// </summary>
    public const string EducatorPhone = "IX_Educator_Phone";
}