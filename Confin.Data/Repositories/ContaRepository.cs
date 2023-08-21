using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Confin.Data.Interfaces;
using Confin.Domain.Entities;
using Dapper;

namespace Confin.Data.Repositories;

public class ContaRepository : IContaRepository
{
    private readonly DbSession dbSession;

    public ContaRepository(DbSession dbSession)
    {
        this.dbSession = dbSession;
    }
    
    public async Task<IEnumerable<Conta>> Get()
    {
        const string query = @"SELECT id
                                      ,descricao
                                      ,variabilidade
                                      ,observacoes
                                      ,diavencimento
                                      ,ativa
                                      FROM Conta";

        return await dbSession.Connection.QueryAsync<Conta>(query, null, dbSession.Transaction);
    }

    public async Task Save(Conta conta)
    {
        string query = $@"INSERT INTO Conta(
                                descricao
                                ,variabilidade
                                ,observacoes
                                ,diavencimento
                                ,dataCadastro
                                ,ativa) 
                            VALUES(
                                @Descricao,
                                @Variabilidade,
                                @Observacoes,
                                @DiaVencimento
                                ,@DataCadastro
                                ,@Ativa)";

        DynamicParameters parameters = new();
        parameters.Add("Descricao", conta.Descricao, DbType.String);
        parameters.Add("Variabilidade", conta.Variabilidade, DbType.Int16);
        parameters.Add("Observacoes", conta.Observacoes, DbType.String);
        parameters.Add("DiaVencimento", conta.DiaVencimento, DbType.DateTime);
        parameters.Add("DataCadastro", conta.DataCadastro, DbType.DateTime);
        parameters.Add("Ativa", conta.Ativa, DbType.Boolean);

        await dbSession.Connection.ExecuteAsync(query, parameters);
    }

    public async Task<IEnumerable<Conta>> GetAllActive()
    {
        const string query = @"SELECT id
                                      ,descricao
                                      ,variabilidade
                                      ,observacoes
                                      ,diavencimento
                                      ,ativa
                                      FROM Conta 
                                WHERE ativa 
                                    AND dataexpiracao IS null 
                                    OR dataexpiracao > current_date";

        return await dbSession.Connection.QueryAsync<Conta>(query, null, dbSession.Transaction);
    }
}