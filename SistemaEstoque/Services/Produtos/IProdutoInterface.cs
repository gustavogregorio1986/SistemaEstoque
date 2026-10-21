using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Produtos
{
    public interface IProdutoInterface
    {
        Task<List<Produto>> GetProdutosAsync();

        Task<Produto> GetProdutoByIdAsync(int id);
        Task<ResponseModel<string>> AdicionarAsync(Produto produto);

        Task<ResponseModel<string>> AtualizarAsync(Produto produto);
        Task<ResponseModel<string>> RemoverAsync(int id);
    }
}
