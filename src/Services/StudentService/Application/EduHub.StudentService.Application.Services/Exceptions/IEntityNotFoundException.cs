namespace EduHub.StudentService.Application.Services.Exceptions;

public interface IEntityNotFoundException<out T>
{
    T EntityId { get; }
}