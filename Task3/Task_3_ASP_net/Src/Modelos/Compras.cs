using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_3_ASP_net.Src.Modelos
{
    [Table("tb_Compras")]
    public class Compras
    {
        #region Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Compra { get; set; }
        public string DataHora { get; set; }
        [ForeignKey("fk_Usuario")]
        public Usuario Criador { get; set; }
        [ForeignKey("fk_Produto")]
        public Produtos Produto { get; set; }
        #endregion
    }

}
