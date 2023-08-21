using System.Collections.Generic;
using System.Threading.Tasks;
using Confin.Domain.Entities;

namespace Confin.Data.Interfaces;

public interface IContaRepository : IRepositoryBase<Conta>
{
    public Task<IEnumerable<Conta>> GetAllActive();
}