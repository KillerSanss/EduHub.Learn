namespace EduHub.StudentService.Application.Services.Exceptions;

/// <summary>
/// Исключение для не найденых объектов
/// </summary>
public class EntityNotFoundException<T> : Exception, IEntityNotFoundException<T>
{
    public T EntityId { get; }

    public EntityNotFoundException(T entityId, string message) : base(message)
    {
        EntityId = entityId;
    }
}