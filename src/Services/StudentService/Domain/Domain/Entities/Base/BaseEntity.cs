using Ardalis.GuardClauses;

namespace Domain.Entities.Base;

/// <summary>
/// Базовый класс общих полей сущностей
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Метод установки значения Id
    /// </summary>
    protected void SetId(Guid id)
    {
        Id = Guard.Against.Default(id);
    }
}