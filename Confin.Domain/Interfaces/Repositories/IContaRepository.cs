using Confin.Domain.Entities;

namespace Confin.Domain.Interfaces.Repositories;

public interface IContaRepository : IRepositoryBase<Conta>
{
    public Task<IEnumerable<Conta>> GetAllActive();
}