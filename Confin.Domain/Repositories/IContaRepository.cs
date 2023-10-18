using Confin.Domain.Entities;

namespace Confin.Domain.Repositories;

public interface IContaRepository : IRepositoryBase<Conta>
{
    public Task<IEnumerable<Conta>> GetAllActive();
}