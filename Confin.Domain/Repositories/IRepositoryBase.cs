namespace Confin.Domain.Repositories;

public interface IRepositoryBase<T>
{
    public Task<IEnumerable<T>> Get();
    public Task Save(T type);
}