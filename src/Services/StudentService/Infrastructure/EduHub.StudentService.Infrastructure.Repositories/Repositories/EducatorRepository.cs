using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.Data.Context;
using EduHub.StudentService.Infrastructure.Repositories.Repositories.Base;

namespace EduHub.StudentService.Infrastructure.Repositories.Repositories;

/// <summary>
/// Рпозиторий преподавателя
/// </summary>
public class EducatorRepository : BaseRepository<Educator>, IEducatorRepository
{
    public EducatorRepository(StudentDbContext dbContext): base(dbContext)
    {
    }
}