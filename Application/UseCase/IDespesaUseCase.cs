using GerenciadorDespesasPessoais.DTOs;

namespace GerenciadorDespesasPessoais.Application.UseCase
{
    public interface IDespesaUseCase
    {
        Task<ResultModel> AdicionarDespesa(DespesaModel despesaModel);
    }
}
