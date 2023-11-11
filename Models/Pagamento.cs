using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCurso.Models;

public class Pagamento
{
    [DisplayName("Código")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public int Id { get; set; }

    [DisplayName("Descrição")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Cliente { get; set; } = "";

    [DisplayName("Preço")]
    [Required(ErrorMessage = "Campo obrigatório")]
    [PrecoValido(ErrorMessage = "Formato inválido. Use um número com até duas casas decimais.")]
    public decimal Total { get; set; }

    [DisplayName("Pedido")]
    public int PedidoId { get; set; }
    public Pedido? Pedido { get; set; }
}
