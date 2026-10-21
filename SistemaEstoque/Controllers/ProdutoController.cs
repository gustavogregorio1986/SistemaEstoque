using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Services.Categorias;
using SistemaEstoque.Services.Produtos;

namespace SistemaEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ICategoriaInterface _categoriaInterface;
        private readonly IProdutoInterface _produtoInterface;

        public ProdutoController(ICategoriaInterface categoriaInterface, IProdutoInterface produtoInterface)
        {
            _categoriaInterface = categoriaInterface;
            _produtoInterface = produtoInterface;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoInterface.ObterTodosAsync();
            return View(produtos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoInterface.ObterPorIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
    }
}
