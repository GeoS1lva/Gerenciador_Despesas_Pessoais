using GerenciadorDespesasPessoais.Application.Service;
using GerenciadorDespesasPessoais.Domain;
using GerenciadorDespesasPessoais.Domain.Enums;
using GerenciadorDespesasPessoais.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorDespesasPessoais.Application.UseCase
{
    public class DespesaUseCase(IDespesasService despesasService) : IDespesaUseCase
    {
        public IDespesasService _despesasService = despesasService;

        private const string
            TIPO_NULO = "Tipo Despesa inválido!",
            VALOR_NULO_NEGATIVO = "Valor da Despesa não pode ser nulo ou negativo",
            DATA_NULO = "Insira uma data!",
            PARCELADO_NULO = "Insira a opção de parcelamento",
            QUANTIDADE_PARCELA = "Quantidade de parcelas não pode ser nula quando parcelado.",
            DATA_INVALIDA = "Data Inválida";

        private string erro = string.Empty;


        public async Task<ResultModel> AdicionarDespesa(DespesaModel despesaModel)
        {
            if (ValidarDespesa(despesaModel.Tipo) == false)
                return new(TIPO_NULO);

            if (despesaModel.Valor == null || despesaModel.Valor < 1)
                return new(VALOR_NULO_NEGATIVO);

            if (despesaModel.Data == null)
                return new(DATA_NULO);

            if (!ValidarData(despesaModel.Data))
                return new(erro);

            if (despesaModel.Parcelado == null)
                return new(PARCELADO_NULO);

            if (despesaModel.Parcelado == OpcaoParcela.sim && despesaModel.QuantidadeParcela == null)
                return new(QUANTIDADE_PARCELA);

            Enum.TryParse<TipoDespesa>(despesaModel.Tipo, true, out var tipoDespesa);

            var despesa = new Despesas(tipoDespesa, despesaModel.Valor, despesaModel.Data, despesaModel.Parcelado, despesaModel.QuantidadeParcela);

            var resultado = await _despesasService.AdicionarDespesaService(despesa);

            return new(resultado);
        }

        public async Task<ResultModel> RetornarTodasDespesas()
        {
            var resultado = _despesasService.TodasDespesas();

            if (resultado == null)
                return new("Sem despesas!");

            return new(resultado);
        }

        public bool ValidarDespesa(string tipo)
        {
            if(Enum.IsDefined(typeof(TipoDespesa), tipo) == false)
                return false;

            return true;
        }

        public bool ValidarData(DateOnly data)
        {
            int dia = data.Day;
            int mes = data.Month;
            int ano = data.Year;

            if (dia > 31 || dia < 1 || dia > 28 && mes == 2)
            {
                erro = DATA_INVALIDA;
                return false;
            }

            if (mes > 12)
            {
                erro = DATA_INVALIDA;
                return false;
            }

            if (ano < 2025)
            {
                erro = DATA_INVALIDA;
                return false;
            }

            return true;
        }
    }
}
