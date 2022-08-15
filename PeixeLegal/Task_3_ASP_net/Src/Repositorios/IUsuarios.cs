using System.Threading.Tasks;
using PeixeLegal.Src.Modelos;

namespace PeixeLegal.Src.Repositorios
{
    public interface IUsuarios
    {
        Task<Usuario> PegarUsuarioPeloEmailAsync(string email);
        Task NovoUsuarioAsync(Usuario usuario);

    }
}
