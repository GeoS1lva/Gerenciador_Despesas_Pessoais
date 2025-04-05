using GerenciadorDespesasPessoais.Domain.Enums;

namespace GerenciadorDespesasPessoais.Domain.Interfaces
{
    public interface IDespesasRepository
    {
        public void InserirDespesa(Despesas despesa);
        public Task<List<Despesas>> VisualizarTodasAsDespesas();
        public Task<List<Despesas>> FiltrarData(DateOnly data);
        public Task<List<Despesas>> FiltrarPorMes(int mes);
        public Task<List<Despesas>> FiltrarPorTipo(TipoDespesa tipoDespesa);
    }
}
