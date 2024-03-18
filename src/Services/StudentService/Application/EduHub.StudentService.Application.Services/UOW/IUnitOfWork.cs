namespace EduHub.StudentService.Application.Services.UOW;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken token);
}