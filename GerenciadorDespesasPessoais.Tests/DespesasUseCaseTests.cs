using System;
using GerenciadorDespesasPessoais.DTOs;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorDespesasPessoais.Domain.Enums;
using GerenciadorDespesasPessoais.Application.UseCase;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using GerenciadorDespesasPessoais.Domain;
using GerenciadorDespesasPessoais.Domain.Interfaces;
using Moq;
using GerenciadorDespesasPessoais.Application.Service;


namespace GerenciadorDespesasPessoais.Tests
{
    [TestFixture]
    internal class DespesasUseCaseTests
    {
        private Mock<IUnitOfWork> unitOfWork;
        private DespesasService despesasService;
        private DespesaUseCase despesaUseCase;

        [SetUp]
        public void Setup()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            despesasService = new DespesasService(unitOfWork.Object);
            despesaUseCase = new DespesaUseCase(despesasService);
        }

        [Test]
        public async Task AdicionarDespesa_MensagemErro_Se_TipoDespesa_For_Invalido()
        {
            var despesaModel = new DespesaModel
            {
                Tipo = "Mercado",
                Valor = 10.00,
                Data = new DateOnly(2025, 04, 30),
                Parcelado = OpcaoParcela.nao,
                QuantidadeParcela = 0
            };

            var actual = await despesaUseCase.AdicionarDespesa(despesaModel);

            actual.Error.Should().BeTrue();
            TestContext.WriteLine(actual.ErrorMessage);
        }

        [Test]
        public async Task AdicionarDespesa_MensagemErro_Se_Valor_Ser_Nulo()
        {
            var despesaModel = new DespesaModel
            {
                Tipo = "SuperMercado",
                Valor = 0.00,
                Data = new DateOnly(2025, 04, 30),
                Parcelado = OpcaoParcela.nao,
                QuantidadeParcela = 0
            };

            var actual = await despesaUseCase.AdicionarDespesa(despesaModel);

            actual.Error.Should().BeTrue();
            TestContext.WriteLine(actual.ErrorMessage);
        }

        //[Test]
        //public async Task AdicionarDespesa_MensagemErro_Se_Data_Ter_DiasInvalidos()
        //{
        //    var despesaModel = new DespesaModel
        //    {
        //        Tipo = "SuperMercado",
        //        Valor = 10.00,
        //        Data = new DateOnly(2025, 02, 30),
        //        Parcelado = OpcaoParcela.nao,
        //        QuantidadeParcela = 0
        //    };

        //    var actual = await despesaUseCase.AdicionarDespesa(despesaModel);

        //    actual.Error.Should().BeTrue();
        //    TestContext.WriteLine(actual.ErrorMessage);
        //}
    }
}
