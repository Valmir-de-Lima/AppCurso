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

    [ForeignKey("ProdutoId")]
    public Produto Produto { get; set; } = new();
}
