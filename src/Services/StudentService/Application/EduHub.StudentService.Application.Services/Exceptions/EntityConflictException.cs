namespace EduHub.StudentService.Application.Services.Exceptions;

public class EntityConflictException<T> : Exception, IEntityConflictException<T>
{
    public T EntityId { get; }

    public EntityConflictException(T entityId)
    {
        EntityId = entityId;
    }

    public EntityConflictException(T entityId, string message) : base(message)
    {
        EntityId = entityId;
    }
}