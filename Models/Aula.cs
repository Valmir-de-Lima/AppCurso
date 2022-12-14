using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppCurso.Models;

public class Aula
{
    [DisplayName("Código")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public int Id { get; set; }

    [DisplayName("Aula")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Titulo { get; set; } = "";

    [DisplayName("Descrição")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Descricao { get; set; } = "";

    [DisplayName("URL do vídeo da aula")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string UrlVideoAula { get; set; } = "";

    [DisplayName("Módulo")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public int ModuloId { get; set; }
    public Modulo? Modulo { get; set; }
}
