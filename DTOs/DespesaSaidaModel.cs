using System.Text.Json.Serialization;
using GerenciadorDespesasPessoais.Domain.Enums;

namespace GerenciadorDespesasPessoais.DTOs
{
    public class DespesaSaidaModel
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoDespesa Tipo { get; set; }
        public double Valor { get; set; }


        public DespesaSaidaModel(TipoDespesa tipo, double valor)
        {
            Tipo = tipo;
            Valor = valor;
        }
    }
}
