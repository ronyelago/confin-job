using Confin.Data;
using Confin.Data.Repositories;
using Confin.Domain.Entities;
using Confin.Domain.Interfaces.Repositories;
using Confin.Domain.Interfaces.Services;

namespace Confin.Service.Services;

public class PlanejamentoService : IPlanejamentoService
{
    public async Task GerarPlanejamento()
    {
        IContaRepository contaRepository = new ContaRepository(new DbSession());
        var contas = contaRepository.GetAllActive().Result;

        var contasPagar = new List<ContaPagar>();
    }
}