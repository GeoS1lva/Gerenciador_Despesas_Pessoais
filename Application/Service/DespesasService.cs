using GerenciadorDespesasPessoais.Domain;
using GerenciadorDespesasPessoais.Domain.Interfaces;
using GerenciadorDespesasPessoais.DTOs;

namespace GerenciadorDespesasPessoais.Application.Service
{
    public class DespesasService(IUnitOfWork context) : IDespesasService
    {
        public async Task<DespesaSaidaModel> AdicionarDespesaService(DespesaModel despesaModel)
        {
            var NovaDespesa = new Despesas(despesaModel.Tipo, despesaModel.Valor, despesaModel.Data, despesaModel.Parcelado, despesaModel.QuantidadeParcela);

            context.DespesasRepository.InserirDespesa(NovaDespesa);

            await context.SaveChangesAsync();

            var despesaSaida = new DespesaSaidaModel(NovaDespesa.Tipo, NovaDespesa.Valor);

            return despesaSaida;
        }
    }
}
