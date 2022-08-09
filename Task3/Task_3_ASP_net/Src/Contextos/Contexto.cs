using Microsoft.EntityFrameworkCore;

namespace Task_3_ASP_net.Src.Contextos
{
    public class Contexto : DbContext
    {
        #region Atributos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Compras> Temas { get; set; }
        public DbSet<Produtos> Postagens { get; set; }
        #endregion
        #region Construtores
        public Contexto(DbContextOptions<Contexto> opt) :
        base(opt)
        {
        }
        #endregion
    }
}

