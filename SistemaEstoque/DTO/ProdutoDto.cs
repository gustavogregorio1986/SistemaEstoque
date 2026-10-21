using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaEstoque.Models;

namespace SistemaEstoque.DTO
{
    public class ProdutoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal? Preco { get; set; }

        public int? Quantidade { get; set; }

        public string Codigo { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public IFormFile? ImagemUpload { get; set; }

        public byte[]? Imagem { get; set; }

        public SelectList? Categorias { get; set; }
    }
}
