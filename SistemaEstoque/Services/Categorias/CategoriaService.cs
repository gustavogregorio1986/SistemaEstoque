using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Data;
using SistemaEstoque.DTO;
using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Categorias
{
    public class CategoriaService : ICategoriaInterface
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<string>> AdicionarAsync(CategoriaDto categoriaDto)
        {
            ResponseModel<string> response = new ResponseModel<string>();

            try
            {
                Categoria categoriaBanco = new Categoria
                {
                    Descricao = categoriaDto.Descricao
                };

                _context.Add(categoriaBanco);
                await _context.SaveChangesAsync();

                response.Mensgame = "Categoria adicionada com sucesso!";

                return response;
            }
            catch(Exception ex)
            {
                response.Mensgame = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<Categoria> ObterPorIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<List<Categoria>> ObterTodosAsync()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
