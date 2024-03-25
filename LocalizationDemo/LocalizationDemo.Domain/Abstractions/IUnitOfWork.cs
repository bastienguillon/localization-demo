namespace LocalizationDemo.Domain.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken = default);
}