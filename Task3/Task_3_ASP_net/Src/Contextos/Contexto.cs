using Microsoft.EntityFrameworkCore;
using PeixeLegal.Src.Modelos;

namespace PeixeLegal.Src.Contextos
{
    public class Contexto : DbContext
    {
        #region Atributos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        #endregion
        #region Construtores
        public Contexto(DbContextOptions<Contexto> opt) :
        base(opt)
        {
        }
        #endregion
    }
}

