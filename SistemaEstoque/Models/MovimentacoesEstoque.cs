namespace SistemaEstoque.Models
{
    public class MovimentacoesEstoque
    {
        public int Id { get; set; }

        public  DateTime Data { get; set; }

        public string Tipo { get; set; }

        public int? Quantidade { get; set; }

        public string? Usuario { get; set; }

        public string Observacao { get; set; }

        public Produto Produto { get; set; }

        public int? ProdutoId { get; set; }

        public ICollection<MovimentacoesEstoque> Movimentacoes { get; set; }
    }
}
