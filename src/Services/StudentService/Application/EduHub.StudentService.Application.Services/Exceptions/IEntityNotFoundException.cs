namespace EduHub.StudentService.Application.Services.Exceptions;

/// <summary>
/// Интерфейс описывающий EntityNotFoundException
/// </summary>
public interface IEntityNotFoundException<out T>
{
    T EntityId { get; }
}
