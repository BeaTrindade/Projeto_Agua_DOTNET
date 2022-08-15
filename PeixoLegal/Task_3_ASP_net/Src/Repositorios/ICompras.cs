using System.Collections.Generic;
using System.Threading.Tasks;
using PeixeLegal.Src.Modelos;

namespace PeixeLegal.Src.Repositorios
{
    public interface ICompras
    {
        Task<List<Compras>> PegarTodasComprasAsync();
        Task<Compras> PegarComprasPeloIdAsync(int id);
        Task NovaComprasAsync(Compras compras);
        Task AtualizarComprasAsync(Compras compras);
        Task DeletarComprasAsync(int id);
    }
}
