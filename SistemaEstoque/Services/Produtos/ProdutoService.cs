using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Data;
using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Produtos
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<string>> AdicionarAsync(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<string>> AtualizarAsync(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> ObterPorIdAsync(int id) => _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<Produto>> ObterTodosAsync() => await _context.Produtos.Include(p => p.Categoria).ToListAsync();

        public Task<ResponseModel<string>> RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
