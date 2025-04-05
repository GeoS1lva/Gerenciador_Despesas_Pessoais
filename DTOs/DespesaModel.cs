using System.Globalization;
using System.Text.Json.Serialization;
using GerenciadorDespesasPessoais.Domain.Enums;

namespace GerenciadorDespesasPessoais.DTOs
{
    public class DespesaModel
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoDespesa Tipo { get; set; }

        public double Valor { get; set; }
        public DateOnly Data { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OpcaoParcela Parcelado { get; set; }
        public int? QuantidadeParcela { get; set; }
        public double? ValorParcela { get; set; }
    }
}
