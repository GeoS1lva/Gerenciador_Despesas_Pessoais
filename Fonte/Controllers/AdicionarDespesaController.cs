using GerenciadorDespesasPessoais.Application.UseCase;
using GerenciadorDespesasPessoais.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDespesasPessoais.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdicionarDespesaController(IDespesaUseCase despesaUseCase) : ControllerBase
    {
        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] DespesaModel request)
        {
            var retorno = await despesaUseCase.AdicionarDespesa(request);

            if(retorno.Error)
                return BadRequest(retorno.ErrorMessage);

            return Ok(retorno);
        }
    }
}
