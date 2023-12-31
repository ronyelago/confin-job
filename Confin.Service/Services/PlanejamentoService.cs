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

        foreach (var conta in contas)
        {
            contasPagar.Add(new ContaPagar
            {
                CadastroContaId = conta.Id,
                Valor = 0,
                DataPagamento = null,
                DataVencimento = new DateTime(DateTime.Now.Year, DateTime.Now.Month, conta.DiaVencimento),
                Status = (StatusConta)0
            });
        }
    }
}