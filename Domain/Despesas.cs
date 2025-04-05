using GerenciadorDespesasPessoais.Domain.Enums;

namespace GerenciadorDespesasPessoais.Domain
{
    public sealed class Despesas
    {
        public int Id { get; set; }
        public TipoDespesa Tipo { get; set; }
        public double Valor { get; set; }
        public DateOnly Data { get; set; }
        public OpcaoParcela Parcelado { get; set; }
        public int? QuantidadeParcela { get; set; } = 0;
        public double? ValorParcela { get; set; } = 0.0;

        public Despesas(TipoDespesa tipo, double valor, DateOnly data,OpcaoParcela parcelado, int? quantidadeParcela)
        {
            Tipo = tipo;
            Valor = valor;
            Data = data;
            Parcelado = parcelado;
            QuantidadeParcela = quantidadeParcela;

            if (Parcelado == OpcaoParcela.sim)
                ValorParcela = Valor / QuantidadeParcela;
            else
                ValorParcela = 0.0;
        }
    }
}
