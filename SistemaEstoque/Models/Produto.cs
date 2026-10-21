using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal? Preco { get; set; }

        public int Quantidade { get; set; }

        public byte[] Imagem { get; set; }

        [NotMapped] // IMPORTANTE: Diz pro EF Core ignorar isso no banco de dados
        public IFormFile ImagemUpload { get; set; } // Recebe o arquivo da t

        public Categoria Categoria { get; set; }

        public int CategoriaId { get; set; }

        public ICollection<MovimentacoesEstoque> Movimentacoes { get; set; }
    }
}
