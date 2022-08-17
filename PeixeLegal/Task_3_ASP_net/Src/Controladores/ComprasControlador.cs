using PeixeLegal.Src.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using PeixeLegal.Src.Modelos;
using Microsoft.AspNetCore.Authorization;

namespace PeixeLegal.Src.Controladores
{
    [ApiController]
    [Route("api/Compras")]
    [Produces("application/json")]

    public class ComprasControlador : ControllerBase
    {
        #region Atributos
        private readonly ICompras _repositorio;
        #endregion

        #region Construtores
        public ComprasControlador(ICompras repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion

        #region Métodos
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> PegarTodasComprasAsync()
        {
            var lista = await _repositorio.PegarTodasComprasAsync();
            if (lista.Count < 1) return NoContent();
            return Ok(lista);
        }

        [HttpGet("id/{idCompras}")]
        [Authorize]
        public async Task<ActionResult> PegarComprasPeloIdAsync([FromRoute] int id_Compras)
        {
            try
            {
                return Ok(await _repositorio.PegarComprasPeloIdAsync(id_Compras));
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> NovaComprasAsync([FromBody] Compras compras)
        {
            await _repositorio.NovaComprasAsync(compras);
            return Created($"api/Compras", compras);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> AtualizarComprasAsync([FromBody] Compras compras)
        {
            try
            {
                await _repositorio.AtualizarComprasAsync(compras);
                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpDelete("deletar/{idCompras}")]
        [Authorize]
        public async Task<ActionResult> DeletarComprasAsync([FromRoute] int id_Compras)
        {
            try
            {
                await _repositorio.DeletarComprasAsync(id_Compras);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }
        #endregion
    }
}
