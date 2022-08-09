using Microsoft.EntityFrameworkCore;
using Task_3_ASP_net.Src.Modelos;

namespace Task_3_ASP_net.Src.Contextos
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

