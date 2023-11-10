using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCurso.Models;

public class Pedido
{
    [DisplayName("Pedido")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public int Id { get; set; }

    [DisplayName("Cliente")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Cliente { get; set; } = "";

    [DisplayName("Produto")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public int ProdutoId { get; set; }

    [DisplayName("Descrição")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Descricao { get; set; } = "";

    [DisplayName("Preço")]
    [Required(ErrorMessage = "Campo obrigatório")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Preco { get; set; }
}
