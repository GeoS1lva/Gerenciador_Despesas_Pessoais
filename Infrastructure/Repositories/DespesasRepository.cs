using GerenciadorDespesasPessoais.Domain;
using GerenciadorDespesasPessoais.Domain.Enums;
using GerenciadorDespesasPessoais.Domain.Interfaces;
using GerenciadorDespesasPessoais.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDespesasPessoais.Infrastructure.Repositories
{
    public class DespesasRepository(SqlServerDbContext context) : IDespesasRepository
    {
        private readonly SqlServerDbContext _context = context;

        public void InserirDespesa(Despesas despesa)
            => _context.Despesas.Add(despesa);

        public async Task<List<Despesas>> VisualizarTodasAsDespesas()
            => await _context.Despesas.ToListAsync();

        public async Task<List<Despesas>> FiltrarData(DateOnly data)
            => await _context.Despesas.Where(x => x.Data == data).ToListAsync();

        public async Task<List<Despesas>> FiltrarPorMes(int mes)
            => await _context.Despesas.Where(x => x.Data.Month == mes).ToListAsync();

        public async Task<List<Despesas>> FiltrarPorTipo(TipoDespesa tipoDespesa)
            => await _context.Despesas.Where(x => x.Tipo == tipoDespesa).ToListAsync();
    }
}
