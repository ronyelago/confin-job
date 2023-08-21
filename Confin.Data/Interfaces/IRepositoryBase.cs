using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confin.Data.Interfaces;

public interface IRepositoryBase<T>
{
    public Task<IEnumerable<T>> Get();
    public Task Save(T type);
}