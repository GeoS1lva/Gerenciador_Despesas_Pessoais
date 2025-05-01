using GerenciadorDespesasPessoais.Domain;
using GerenciadorDespesasPessoais.DTOs;

namespace GerenciadorDespesasPessoais.Application.Service
{
    public interface IDespesasService
    {
        public Task<DespesaSaidaModel> AdicionarDespesaService(Despesas despesa);
        public Task<List<DespesaModel>> TodasDespesas();
    }
}
