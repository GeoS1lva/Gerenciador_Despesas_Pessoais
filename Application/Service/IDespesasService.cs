using GerenciadorDespesasPessoais.Domain;
using GerenciadorDespesasPessoais.DTOs;

namespace GerenciadorDespesasPessoais.Application.Service
{
    public interface IDespesasService
    {
        public Task<DespesaSaidaModel> AdicionarDespesaService(DespesaModel despesaModel);
        public Task<List<DespesaModel?>> TodasDespesas();
    }
}
