using Microsoft.AspNetCore.Mvc;
using Rotas.API.Application.UseCases.CalcularMelhorRota;
using Rotas.API.Application.UseCases.GerenciarRotas.AdicionarRotas;
using Rotas.API.Application.UseCases.GerenciarRotas.EditarRotas;
using Rotas.API.Application.UseCases.GerenciarRotas.ExcluirRota;
using Rotas.API.Application.UseCases.GerenciarRotas.ListarRotas;

namespace Rotas.API.Api.Controllers.Rotas
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotasController : ControllerBase
    {
        private readonly CalcularMelhorRotaUseCase _calcularMelhorRotaUseCase;
        private readonly AdicionarRotaUseCase _adicionarRotaUseCase;
        private readonly ListarRotasUseCase  _listarRotasUseCase;
        private readonly ExcluirRotaUseCase _excluirRotaUseCase;
        private readonly EditarRotaUseCase _editarRotaUseCase;

        public RotasController(CalcularMelhorRotaUseCase calcularMelhorRotaUseCase, AdicionarRotaUseCase adicionarRotaUseCase, ListarRotasUseCase listarRotasUseCase, ExcluirRotaUseCase excluirRotaUseCase, EditarRotaUseCase editarRotaUseCase)
        {
            _calcularMelhorRotaUseCase = calcularMelhorRotaUseCase;
            _adicionarRotaUseCase = adicionarRotaUseCase;
            _listarRotasUseCase = listarRotasUseCase;
            _excluirRotaUseCase = excluirRotaUseCase;
            _editarRotaUseCase = editarRotaUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> ListarRotas()
        {
            var response = await _listarRotasUseCase.ExecuteAsync(new ListarRotasRequest());
            return Ok(response.Rotas);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarRota([FromBody] AdicionarRotaRequest rota)
        {
            if (rota == null)
                return BadRequest("A rota não pode ser nula.");

            var respose = await _adicionarRotaUseCase.ExecuteAsync(rota);
            return CreatedAtAction(nameof(AdicionarRota), new { respose });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarRota(int id, [FromBody] EditarRotaRequest request)
        {
            try
            {
                request.RotaId = id;
                var response = await _editarRotaUseCase.ExecuteAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new {ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirRota(int id)
        {
            try
            {
                var request = new ExcluirRotaRequest { RotaId = id };
                var response = await _excluirRotaUseCase.ExecuteAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("calcular-melhor-rota/{origem}/{destino}")]
        public async Task<IActionResult> CalcularMelhorRota(string origem, string destino)
        {
            var response = await _calcularMelhorRotaUseCase.ExecuteAsync(new CalcularMelhorRotaRequest() { Destino = destino, Origem = origem });
            return Ok(response);
        }
    }
}
