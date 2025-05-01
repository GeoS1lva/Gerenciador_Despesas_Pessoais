using GerenciadorDespesasPessoais.Domain;
using GerenciadorDespesasPessoais.Domain.Interfaces;
using GerenciadorDespesasPessoais.DTOs;

namespace GerenciadorDespesasPessoais.Application.Service
{
    public class DespesasService(IUnitOfWork context) : IDespesasService
    {
        public async Task<DespesaSaidaModel> AdicionarDespesaService(Despesas despesa)
        {
            context.DespesasRepository.InserirDespesa(despesa);

            await context.SaveChangesAsync();

            var despesaSaida = new DespesaSaidaModel(despesa.Tipo, despesa.Valor);

            return despesaSaida;
        }

        public async Task<List<DespesaModel>> TodasDespesas()
        {
            var Despesas = await context.DespesasRepository.VisualizarTodasAsDespesas();

            List<DespesaModel> retorno = Despesas.Select(a => new DespesaModel
            {
                Tipo = a.Tipo.ToString(),
                Valor = a.Valor,
                Data = a.Data,
                Parcelado = a.Parcelado,
                QuantidadeParcela = a.QuantidadeParcela,
                ValorParcela = a.ValorParcela
            }).ToList();

            return retorno;
        }
    }
}
