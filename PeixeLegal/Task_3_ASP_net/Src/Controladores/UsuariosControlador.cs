using Microsoft.AspNetCore.Mvc;
using PeixeLegal.Src.Modelos;
using PeixeLegal.Src.Repositorios;
using System.Threading.Tasks;

namespace PeixeLegal.Src.Controladores
{
    [ApiController]
    [Route("api/Usuarios")]
    [Produces("application/json")]
    public class UsuarioControlador : ControllerBase
    {
        #region Atributos
        private readonly IUsuarios _repositorio;
        #endregion
        #region Construtores
        public UsuarioControlador(IUsuarios repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion
        #region Métodos
        [HttpGet("email/{emailUsuario}")]
        public async Task<ActionResult> PegarUsuarioPeloEmailAsync([FromRoute] string emailUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(emailUsuario);
            if (usuario == null) return NotFound(new { Mensagem = "Usuario não encontrado" });
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult> NovoUsuarioAsync([FromBody] Usuario usuario)
        {
            await _repositorio.NovoUsuarioAsync(usuario);
            return Created($"api/Usuarios/{usuario.Email}", usuario);
        }

        #endregion
    }
}
