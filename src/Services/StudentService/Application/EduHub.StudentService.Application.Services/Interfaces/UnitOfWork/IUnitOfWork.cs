namespace EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;

/// <summary>
/// Интерфейс описывающий UnitOfWork
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Сохранение изменений
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Кол-во измененных записей.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}