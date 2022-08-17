using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeixeLegal.Src.Contextos;
using PeixeLegal.Src.Modelos;
using Microsoft.EntityFrameworkCore;
namespace PeixeLegal.Src.Repositorios.Implementacoes
{

    public class ProdutosRepositorio : IProdutos
    {
        #region Atributos
        private readonly PeixeLegalContextos _contexto;
        #endregion Atributos
        #region Construtores
        public ProdutosRepositorio(PeixeLegalContextos contexto)
        {
            _contexto = contexto;
        }
        #endregion Construtores
        #region Métodos
        public async Task<List<Produtos>> PegarTodosProdutosAsync()
        {
            return await _contexto.Produtos.ToListAsync();
        }
        public async Task<Produtos> PegarProdutosPeloIdAsync(int id)
        {
            if (!ExisteId(id)) throw new Exception("Produto não encontrado");
            return await _contexto.Produtos.FirstOrDefaultAsync(t => t.Id_Produto == id);
            // funções auxiliares
            bool ExisteId(int id)
            {
                var auxiliar = _contexto.Produtos.FirstOrDefault(u => u.Id_Produto == id);
                return auxiliar != null;
            }
        }
        public async Task NovoProdutosAsync(Produtos produtos)
        {
            await _contexto.Produtos.AddAsync(
            new Produtos
            {
                Descricao = produtos.Descricao
            });
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarProdutosAsync(Produtos produtos)
        {
            var produtosExistente = await PegarProdutosPeloIdAsync(produtos.Id_Produto);
            produtosExistente.Descricao = produtos.Descricao;
            _contexto.Produtos.Update(produtosExistente);
            await _contexto.SaveChangesAsync();
        }
        public async Task DeletarProdutosAsync(int id)
        {
            _contexto.Produtos.Remove(await PegarProdutosPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }

        #endregion Métodos
    }
}