namespace EduHub.StudentService.Application.Services.Exceptions;

public interface IEntityConflictException<out T>
{
    T EntityId { get; }
}