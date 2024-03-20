using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories;

/// <summary>
/// Интерфейс описывающий StudentRepository
/// </summary>
public interface IStudentRepository : IRepository<Student>
{
}