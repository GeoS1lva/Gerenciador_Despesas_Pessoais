using GerenciadorDespesasPessoais.Application.UseCase;
using GerenciadorDespesasPessoais.Domain.Interfaces;
using GerenciadorDespesasPessoais.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDespesasPessoais.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TodasDespesasController(IDespesaUseCase despesaUseCase) : Controller
    {

        [HttpGet]
        [Route("Despesas")]
        public async Task<ResultModel> ReceberTodasDespesas()
        {
            var retorno = await despesaUseCase.RetornarTodasDespesas();

            return retorno;
        }
    }
}
