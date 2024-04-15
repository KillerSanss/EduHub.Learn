using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.Data.Context;
using EduHub.StudentService.Infrastructure.Repositories.Repositories.Base;

namespace EduHub.StudentService.Infrastructure.Repositories.Repositories;

/// <summary>
/// Репозиторий студента
/// </summary>
public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(StudentDbContext dbContext) : base(dbContext)
    {
    }
}