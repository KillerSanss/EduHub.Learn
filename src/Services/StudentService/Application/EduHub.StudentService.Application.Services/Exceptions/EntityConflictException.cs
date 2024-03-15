namespace EduHub.StudentService.Application.Services.Exceptions;

/// <summary>
/// Исключение для конфликтов
/// </summary>
public class EntityConflictException<T> : Exception, IEntityConflictException<T>
{
    public T EntityId { get; }

    public EntityConflictException(T entityId, string message) : base(message)
    {
        EntityId = entityId;
    }
}