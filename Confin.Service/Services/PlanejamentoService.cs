using Confin.Data;
using Confin.Data.Interfaces;
using Confin.Data.Repositories;
using Confin.Domain.Services.Interfaces;

namespace Confin.Service.Services;

public class PlanejamentoService : IPlanejamentoService
{
    public async Task GerarPlanejamento()
    {
        IContaRepository contaRepository = new ContaRepository(new DbSession());
        var contas = contaRepository.GetAllActive().Result;
    }
}