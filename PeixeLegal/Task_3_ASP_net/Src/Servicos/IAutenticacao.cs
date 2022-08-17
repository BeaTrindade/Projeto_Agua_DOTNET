using System.Threading.Tasks;
using PeixeLegal.Src.Modelos;

namespace PeixeLegal.Src.Servicos
{
    public interface IAutenticacao
    {
        string CodificarSenha(string senha);
        Task CriarUsuarioSemDuplicarAsync(Usuario usuario);
        string GerarToken(Usuario usuario);
    }

}
