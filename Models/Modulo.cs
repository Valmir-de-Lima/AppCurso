using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppCurso.Models;

public class Modulo
{
    [DisplayName("Código")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public int Id { get; set; }

    [DisplayName("Título")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Titulo { get; set; } = "";

    [DisplayName("Descrição")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Descricao { get; set; } = "";

    [DisplayName("Ordem de exibição")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public int OrdemExibicao { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public List<Aula>? Aulas { get; set; }
}