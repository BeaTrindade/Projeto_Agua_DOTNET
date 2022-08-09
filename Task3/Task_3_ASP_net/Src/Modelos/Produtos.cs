using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_3_ASP_net.Src.Modelos {

     [Table("tb_Produtos")]
     public class Produtos
{
    #region Atributos
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id_Produto { get; set; }
    public string Produto { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }
    public string Valor { get; set; }
    public string Quantidade { get; set; }
    public string Url_Imagem { get; set; }
    #endregion
}

}
