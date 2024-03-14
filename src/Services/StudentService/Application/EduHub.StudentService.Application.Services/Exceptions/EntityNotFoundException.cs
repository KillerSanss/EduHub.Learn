namespace EduHub.StudentService.Application.Services.Exceptions;

public class EntityNotFoundException<T> : Exception, IEntityNotFoundException<T>
{
    public T EntityId { get; }

    public EntityNotFoundException(T entityId)
    {
        EntityId = entityId;
    }

    public EntityNotFoundException(T entityId, string message) : base(message)
    {
        EntityId = entityId;
    }
}