using SistemaEstoque.DTO;
using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Categorias
{
    public interface ICategoriaInterface
    {
        Task<List<Categoria>> ObterTodosAsync(); 

        Task<ResponseModel<string>> AdicionarAsync(CategoriaDto categoriaDto);

        Task<Categoria> ObterPorIdAsync(int id);
    }
}
