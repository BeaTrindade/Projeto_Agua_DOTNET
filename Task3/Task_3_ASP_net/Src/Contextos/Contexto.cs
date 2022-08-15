using Microsoft.EntityFrameworkCore;
using PeixeLegal.Src.Modelos;

namespace PeixeLegal.Src.Contextos
{
    public class PeixeLegalContextos : DbContext
    {
        #region Atributos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        #endregion
        #region Construtores
        public PeixeLegalContextos(DbContextOptions<PeixeLegalContextos> opt) :
        base(opt)
        {
        }
        #endregion
    }
}

