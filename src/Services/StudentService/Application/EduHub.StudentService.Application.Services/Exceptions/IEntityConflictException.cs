namespace EduHub.StudentService.Application.Services.Exceptions;

/// <summary>
/// Интерфейс описывающий EntityConflictException
/// </summary>
public interface IEntityConflictException<out T>
{
    T EntityId { get; }
}