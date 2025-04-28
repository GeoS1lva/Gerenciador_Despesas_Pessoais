using GerenciadorDespesasPessoais.DTOs;

namespace GerenciadorDespesasPessoais.Application.UseCase
{
    public interface IDespesaUseCase
    {
        public Task<ResultModel> AdicionarDespesa(DespesaModel despesaModel);
        public Task<ResultModel> RetornarTodasDespesas();
    }
}
