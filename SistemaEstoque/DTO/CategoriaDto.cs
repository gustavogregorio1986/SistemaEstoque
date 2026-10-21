using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.DTO
{
    public class CategoriaDto
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }
    }
}
