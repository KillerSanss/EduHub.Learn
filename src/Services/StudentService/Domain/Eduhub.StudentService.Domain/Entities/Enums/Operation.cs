namespace Eduhub.StudentService.Domain.Entities.Enums;

/// <summary>
/// Перечисление для операций сравнения
/// </summary>
public enum Operation
{
    None = 0,
    LessThan = 1,
    LessThanOrEqual = 2,
    GreaterThan = 3,
    GreaterThanOrEqual = 4,
    Equal = 5
}