using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Produtos
{
    public class ProdutoService : IProdutoInterface
    {
        public Task<ResponseModel<string>> AdicionarAsync(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<string>> AtualizarAsync(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetProdutoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Produto>> GetProdutosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<string>> RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
