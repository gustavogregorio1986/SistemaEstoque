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

        public async Task<ResponseModel<string>> AdicionarAsync(Produto produto)
        {
            ResponseModel<string> response = new ResponseModel<string>();

            try
            {

                var produtoBanco = new Produto
                {
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    CategoriaId = produto.CategoriaId,
                    Imagem = await ConverterImagem(produto.ImagemUpload),
                };

                _context.Produtos.Add(produtoBanco);
                await _context.SaveChangesAsync();

                response.Mensagem = "Produto adicionado com sucesso.";

                return response;

            }
            catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
        

        public async Task<ResponseModel<string>> AtualizarAsync(Produto produto)
        {
            ResponseModel<string> response = new ResponseModel<string>();

            try
            {
                var produtoBanco = await _context.Produtos.FindAsync(produto.Id);

                if(produtoBanco == null)
                {
                    response.Mensagem = "Produto não encontrado.";
                    response.Status = false;
                    return response;
                }

                produtoBanco.Nome = produto.Nome;
                produtoBanco.Descricao = produto.Descricao;
                produtoBanco.Preco = produto.Preco;
                produtoBanco.Quantidade = produto.Quantidade;
                produtoBanco.CategoriaId = produto.CategoriaId;

                if(produto.ImagemUpload != null)
                {
                    produtoBanco.Imagem = await ConverterImagem(produto.ImagemUpload);
                }

                _context.Produtos.Update(produtoBanco);
                await _context.SaveChangesAsync();

                response.Mensagem = "Produto atualizado com sucesso.";

                return response;
            }
            catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public Task<Produto> ObterPorIdAsync(int id) => _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<Produto>> ObterTodosAsync() => await _context.Produtos.Include(p => p.Categoria).ToListAsync();

        public async Task<ResponseModel<string>> RemoverAsync(int id)
        {
            ResponseModel<string> response = new ResponseModel<string>();   

            try
            {
                var produto = await _context.Produtos.FindAsync(id);

                if (produto == null)
                {
                    response.Mensagem = "Produto não encontrado.";
                    response.Status = false;
                    return response;
                }

                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();

                response.Mensagem = "Produto removido com sucesso.";
                return response;
            }
            catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        private async Task<byte[]> ConverterImagem(IFormFile imagem)
        {
            if (imagem == null) return null;

            using var memoryStream = new MemoryStream();
            await imagem.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
