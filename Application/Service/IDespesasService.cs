using GerenciadorDespesasPessoais.DTOs;

namespace GerenciadorDespesasPessoais.Application.Service
{
    public interface IDespesasService
    {
        Task<DespesaSaidaModel> AdicionarDespesaService(DespesaModel despesaModel);
    }
}
