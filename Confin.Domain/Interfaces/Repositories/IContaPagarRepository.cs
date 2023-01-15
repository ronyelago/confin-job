using Confin.Domain.Entities;

namespace Confin.Domain.Interfaces.Repositories;

public interface IContaPagarRepository : IRepositoryBase<ContaPagar>
{
    Task SaveMany(List<ContaPagar> contasPagar);
}